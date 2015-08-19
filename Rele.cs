using System;
using System.Threading;
using Microsoft.SPOT.Hardware;
using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    /// <summary>
    /// Oggetto relè
    /// </summary>
    public class Relay : OutputPort
    {
        /// <summary>
        /// Periodo monostabile in ms
        /// </summary>
        private int _interval;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del relè</param>
        public Relay(Relays res)
            : base((Cpu.Pin)res, false)
        {
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del relè</param>
        public Relay(DualRelaysModule res)
            : base((Cpu.Pin)res, false)
        {
        }

        /// <summary>
        /// Accensione
        /// </summary>
        public void On(){
            Write(false);
        }

        /// <summary>
        /// Accensione monostabile
        /// </summary>
        /// <param name="millis">Tempo in cui l'uscità resterà on in milli secondi</param>
        public void On(int millis)
        {
            _interval = millis > 0 ? millis : 0;
            new Thread(MonostableThread).Start();
        }

        /// <summary>
        /// Spegnimento
        /// </summary>
        public void Off()
        {
            Write(true);
        }

        /// <summary>
        /// Inversione di stato
        /// </summary>
        public void Toggle(){
            Write(!Read());
        }

        private static long TotalMilliseconds(long startTickCounter)
        {
            return ((DateTime.Now.Ticks - startTickCounter) / TimeSpan.TicksPerMillisecond);
        }

        private void MonostableThread()
        {
            Write(false);
            if(_interval > 0)
            {
                long startTickCounter = DateTime.Now.Ticks;
                while(TotalMilliseconds(startTickCounter) < _interval)
                {
                    Thread.Sleep(10);
                }
                Write(true);
            }
            
        }
    }
}
