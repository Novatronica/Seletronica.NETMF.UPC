using System;
using System.Threading;
using Microsoft.SPOT.Hardware;
using GHI.OSHW.Hardware.LowLevel;

namespace Seletronica.NETMF.UPC 
{
    public class SoftPWM
    {
        const uint PERIPH_BASE = 0x40000000;
        const uint AHB1PERIPH_BASE = (PERIPH_BASE + 0x00020000);
        const uint GPIOA_BASE = (AHB1PERIPH_BASE + 0x0000);
        const uint GPIOB_BASE = (AHB1PERIPH_BASE + 0x0400);
        const uint GPIOC_BASE = (AHB1PERIPH_BASE + 0x0800);

        const uint GPIOx_ODR_OFFSET = 0x14;
        const uint GPIOx_IDR_OFFSET = 0x10;

        /// <summary>
        /// Numero di PWM reali utilizzabili
        /// </summary>
        /// <remarks>Questo numero è il numero di elementi del vettore RealPWM</remarks>
        private const int RealPWMCount = 2;

        /* 0    PC.06 = MOD7_CHC     non utilizzabile
         * 1    PA.07 = MOD5_CHB     non utilizzabile
         * 2    PC.07 = MOD2_CHC     non utilizzabile
         * 3    PC.08 = SD_DAT0      non utilizzabile
         * 4    PB.00 = MOD6_CHA     utilizzabile da PWM hardware
         * 5    PB.01 = MOD6_CHB     utilizzabile da PWM hardware
         * 6    PB.05 = MOD12_CHC    non utilizzabile
         * 7    PB.04 = JTAG_RESET   non utilizzabile
         * 8    PB.03 = JTAG_TD0     non utilizzabile
         * 9    PB.11 = MOD1_CHB     non utilizzabile
         * 10   PB.10 = MOD1_CHA     utilizzabile da PWM hardware
         * 11   PA.10 = USB_ID       non utilizzabile
         * 12   PA.09 = USB_+VBus    non utilizzabile 
         * 13   PA.15 = JTAG_TDI     disponibile (il JTAG è stato tolto e questo segnale non è usato)
         * 14   PB.08 = MOD2_CHB     disponibile (non disponibile solo se JP2A cpu in posizione 2)
         * 15   PB.09 = MOD2_CHA     disponibile ma non usabile perchè influenzato da PB.08 (non disponibile solo se JP2B cpu in posizione 2)
         * 
         * Nota:
         * Abbiamo riscontrato che i canali PB.00-PB01 si influenzano tra di loro... usarne solo uno dei 2
         * anche i canali PB.08-PB09 si influenzano tra di loro... usarne solo uno dei 2
         * 
        */
        //private static readonly Cpu.PWMChannel[] RealPWM = new[] {(Cpu.PWMChannel)4, (Cpu.PWMChannel)14};
        private static readonly Cpu.PWMChannel[] RealPWM = new[] { (Cpu.PWMChannel)13, (Cpu.PWMChannel)14 };

        private static readonly Register _regGPIOA_IDR = new Register(GPIOA_BASE + GPIOx_IDR_OFFSET);
        private static readonly Register _regGPIOB_IDR = new Register(GPIOB_BASE + GPIOx_IDR_OFFSET);
        private static readonly Register _regGPIOC_IDR = new Register(GPIOC_BASE + GPIOx_IDR_OFFSET);

        private static readonly PWM[] Sources = new PWM[RealPWMCount];
        private static readonly OutputPort[] Destinations = new OutputPort[RealPWMCount];
        private static readonly int[] SourcePorts = new int[RealPWMCount];
        private static readonly uint[] SourceBits = new uint[RealPWMCount];
        private static readonly int[] DestinationPorts = new int[RealPWMCount];
        private static readonly uint[] DestinationBits = new uint[RealPWMCount];

        private static Thread _updateThread;

        private static int _allocatedCount;
        private static bool _running;

        /// <summary>
        /// Indice dell'istanza
        /// </summary>
        private readonly int _index;

        public double DutyCycle
        {
            get
            {
                return Sources[_index].DutyCycle;
            }
            set
            {
                if (value < 0) Sources[_index].DutyCycle = 0;
                else if (value > 1) Sources[_index].DutyCycle = 1;
                else Sources[_index].DutyCycle = value;
            }
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="destination"></param>
        public SoftPWM(int frequency, Cpu.Pin destination)
        {
            if (_allocatedCount >= RealPWMCount)
                throw new ArgumentOutOfRangeException("Impossibile allocare un nuovo canale PWM");

            _index = _allocatedCount;
            Destinations[_index] = new OutputPort((Cpu.Pin)destination, false);
            Sources[_index] = new PWM(RealPWM[_index], frequency, 0.0, false);

            int port = (int)Sources[_index].Pin / 16; // porta A(0), B(1) o C(2)
            int bit = (int)Sources[_index].Pin % 16; // bit nel range [0,15]

            SourcePorts[_index] = port;
            SourceBits[_index] = (uint)(1 << bit);
            
            port = (int)destination/16; // porta A(0), B(1) o C(2)
            bit = (int) destination%16; // bit nel range [0,15]

            DestinationPorts[_index] = port;
            DestinationBits[_index] = (uint)(1 << bit);

            _allocatedCount++;
        }

        /// <summary>
        /// Thread di aggiornamento delle uscite
        /// </summary>
        private static void UpdateOutputs()
        {
            uint[] idr = new uint[3];

            while (_running)
            {
                // Leggo i registri
                idr[0] = _regGPIOA_IDR.Read();
                idr[1] = _regGPIOB_IDR.Read();
                idr[2] = _regGPIOC_IDR.Read();

                for (int i = 0; i < _allocatedCount; i++)
                {
                    Destinations[i].Write((idr[SourcePorts[i]] & SourceBits[i]) != 0);
                }
            }
        }

        public static void Start()
        {
            if (_running) return;

            if (_updateThread == null)
            {
                for (int i = 0; i < _allocatedCount; i++)
                {
                    Sources[i].DutyCycle = 0;
                    Sources[i].Start();
                }
                _updateThread = new Thread(UpdateOutputs);
                _running = true;
                _updateThread.Start();
            }
        }

        public static void Stop()
        {
            if (!_running) return;

            if (_updateThread != null)
            {
                for (int i = 0; i < _allocatedCount; i++)
                {
                    Sources[i].Stop();
                }
                _running = false;
                if(!_updateThread.Join(100))
                {
                    _updateThread.Abort();
                }
                _updateThread = null;
            }
        }
    }

}