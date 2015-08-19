using Microsoft.SPOT.Hardware;

namespace Seletronica.NETMF.UPC
{
    /// <summary>
    /// Definizione dei pin del processore STM32F407
    /// </summary>
    public class Pin
    {
        private const int PA = 0;
        private const int PB = 16;
        private const int PC = 32;
        private const int PD = 48;
        private const int PE = 64;
        private const int PF = 80;
        private const int PG = 96;
        private const int PH = 112;

        public const Cpu.Pin PA0 = (PA + 0);
        public const Cpu.Pin PA1 = (Cpu.Pin)(PA + 1);
        public const Cpu.Pin PA2 = (Cpu.Pin)(PA + 2);
        public const Cpu.Pin PA3 = (Cpu.Pin)(PA + 3);
        public const Cpu.Pin PA4 = (Cpu.Pin)(PA + 4);
        public const Cpu.Pin PA5 = (Cpu.Pin)(PA + 5);
        public const Cpu.Pin PA6 = (Cpu.Pin)(PA + 6);
        public const Cpu.Pin PA7 = (Cpu.Pin)(PA + 7);
        public const Cpu.Pin PA8 = (Cpu.Pin)(PA + 8);
        public const Cpu.Pin PA9 = (Cpu.Pin)(PA + 9);
        public const Cpu.Pin PA10 = (Cpu.Pin)(PA + 10);
        public const Cpu.Pin PA11 = (Cpu.Pin)(PA + 11);
        public const Cpu.Pin PA12 = (Cpu.Pin)(PA + 12);
        public const Cpu.Pin PA13 = (Cpu.Pin)(PA + 13);
        public const Cpu.Pin PA14 = (Cpu.Pin)(PA + 14);
        public const Cpu.Pin PA15 = (Cpu.Pin)(PA + 15);

        public const Cpu.Pin PB0 = (Cpu.Pin)(PB + 0);
        public const Cpu.Pin PB1 = (Cpu.Pin)(PB + 1);
        public const Cpu.Pin PB2 = (Cpu.Pin)(PB + 2);
        public const Cpu.Pin PB3 = (Cpu.Pin)(PB + 3);
        public const Cpu.Pin PB4 = (Cpu.Pin)(PB + 4);
        public const Cpu.Pin PB5 = (Cpu.Pin)(PB + 5);
        public const Cpu.Pin PB6 = (Cpu.Pin)(PB + 6);
        public const Cpu.Pin PB7 = (Cpu.Pin)(PB + 7);
        public const Cpu.Pin PB8 = (Cpu.Pin)(PB + 8);
        public const Cpu.Pin PB9 = (Cpu.Pin)(PB + 9);
        public const Cpu.Pin PB10 = (Cpu.Pin)(PB + 10);
        public const Cpu.Pin PB11 = (Cpu.Pin)(PB + 11);
        public const Cpu.Pin PB12 = (Cpu.Pin)(PB + 12);
        public const Cpu.Pin PB13 = (Cpu.Pin)(PB + 13);
        public const Cpu.Pin PB14 = (Cpu.Pin)(PB + 14);
        public const Cpu.Pin PB15 = (Cpu.Pin)(PB + 15);

        public const Cpu.Pin PC0 = (Cpu.Pin)(PC + 0);
        public const Cpu.Pin PC1 = (Cpu.Pin)(PC + 1);
        public const Cpu.Pin PC2 = (Cpu.Pin)(PC + 2);
        public const Cpu.Pin PC3 = (Cpu.Pin)(PC + 3);
        public const Cpu.Pin PC4 = (Cpu.Pin)(PC + 4);
        public const Cpu.Pin PC5 = (Cpu.Pin)(PC + 5);
        public const Cpu.Pin PC6 = (Cpu.Pin)(PC + 6);
        public const Cpu.Pin PC7 = (Cpu.Pin)(PC + 7);
        public const Cpu.Pin PC8 = (Cpu.Pin)(PC + 8);
        public const Cpu.Pin PC9 = (Cpu.Pin)(PC + 9);
        public const Cpu.Pin PC10 = (Cpu.Pin)(PC + 10);
        public const Cpu.Pin PC11 = (Cpu.Pin)(PC + 11);
        public const Cpu.Pin PC12 = (Cpu.Pin)(PC + 12);
        public const Cpu.Pin PC13 = (Cpu.Pin)(PC + 13);
        public const Cpu.Pin PC14 = (Cpu.Pin)(PC + 14);
        public const Cpu.Pin PC15 = (Cpu.Pin)(PC + 15);

        public const Cpu.Pin PD0 = (Cpu.Pin)(PD + 0);
        public const Cpu.Pin PD1 = (Cpu.Pin)(PD + 1);
        public const Cpu.Pin PD2 = (Cpu.Pin)(PD + 2);
        public const Cpu.Pin PD3 = (Cpu.Pin)(PD + 3);
        public const Cpu.Pin PD4 = (Cpu.Pin)(PD + 4);
        public const Cpu.Pin PD5 = (Cpu.Pin)(PD + 5);
        public const Cpu.Pin PD6 = (Cpu.Pin)(PD + 6);
        public const Cpu.Pin PD7 = (Cpu.Pin)(PD + 7);
        public const Cpu.Pin PD8 = (Cpu.Pin)(PD + 8);
        public const Cpu.Pin PD9 = (Cpu.Pin)(PD + 9);
        public const Cpu.Pin PD10 = (Cpu.Pin)(PD + 10);
        public const Cpu.Pin PD11 = (Cpu.Pin)(PD + 11);
        public const Cpu.Pin PD12 = (Cpu.Pin)(PD + 12);
        public const Cpu.Pin PD13 = (Cpu.Pin)(PD + 13);
        public const Cpu.Pin PD14 = (Cpu.Pin)(PD + 14);
        public const Cpu.Pin PD15 = (Cpu.Pin)(PD + 15);

        public const Cpu.Pin PE0 = (Cpu.Pin)(PE + 0);
        public const Cpu.Pin PE1 = (Cpu.Pin)(PE + 1);
        public const Cpu.Pin PE2 = (Cpu.Pin)(PE + 2);
        public const Cpu.Pin PE3 = (Cpu.Pin)(PE + 3);
        public const Cpu.Pin PE4 = (Cpu.Pin)(PE + 4);
        public const Cpu.Pin PE5 = (Cpu.Pin)(PE + 5);
        public const Cpu.Pin PE6 = (Cpu.Pin)(PE + 6);
        public const Cpu.Pin PE7 = (Cpu.Pin)(PE + 7);
        public const Cpu.Pin PE8 = (Cpu.Pin)(PE + 8);
        public const Cpu.Pin PE9 = (Cpu.Pin)(PE + 9);
        public const Cpu.Pin PE10 = (Cpu.Pin)(PE + 10);
        public const Cpu.Pin PE11 = (Cpu.Pin)(PE + 11);
        public const Cpu.Pin PE12 = (Cpu.Pin)(PE + 12);
        public const Cpu.Pin PE13 = (Cpu.Pin)(PE + 13);
        public const Cpu.Pin PE14 = (Cpu.Pin)(PE + 14);
        public const Cpu.Pin PE15 = (Cpu.Pin)(PE + 15);

        public const Cpu.Pin PF0 = (Cpu.Pin)(PF + 0);
        public const Cpu.Pin PF1 = (Cpu.Pin)(PF + 1);
        public const Cpu.Pin PF2 = (Cpu.Pin)(PF + 2);
        public const Cpu.Pin PF3 = (Cpu.Pin)(PF + 3);
        public const Cpu.Pin PF4 = (Cpu.Pin)(PF + 4);
        public const Cpu.Pin PF5 = (Cpu.Pin)(PF + 5);
        public const Cpu.Pin PF6 = (Cpu.Pin)(PF + 6);
        public const Cpu.Pin PF7 = (Cpu.Pin)(PF + 7);
        public const Cpu.Pin PF8 = (Cpu.Pin)(PF + 8);
        public const Cpu.Pin PF9 = (Cpu.Pin)(PF + 9);
        public const Cpu.Pin PF10 = (Cpu.Pin)(PF + 10);
        public const Cpu.Pin PF11 = (Cpu.Pin)(PF + 11);
        public const Cpu.Pin PF12 = (Cpu.Pin)(PF + 12);
        public const Cpu.Pin PF13 = (Cpu.Pin)(PF + 13);
        public const Cpu.Pin PF14 = (Cpu.Pin)(PF + 14);
        public const Cpu.Pin PF15 = (Cpu.Pin)(PF + 15);

        public const Cpu.Pin PG0 = (Cpu.Pin)(PG + 0);
        public const Cpu.Pin PG1 = (Cpu.Pin)(PG + 1);
        public const Cpu.Pin PG2 = (Cpu.Pin)(PG + 2);
        public const Cpu.Pin PG3 = (Cpu.Pin)(PG + 3);
        public const Cpu.Pin PG4 = (Cpu.Pin)(PG + 4);
        public const Cpu.Pin PG5 = (Cpu.Pin)(PG + 5);
        public const Cpu.Pin PG6 = (Cpu.Pin)(PG + 6);
        public const Cpu.Pin PG7 = (Cpu.Pin)(PG + 7);
        public const Cpu.Pin PG8 = (Cpu.Pin)(PG + 8);
        public const Cpu.Pin PG9 = (Cpu.Pin)(PG + 9);
        public const Cpu.Pin PG10 = (Cpu.Pin)(PG + 10);
        public const Cpu.Pin PG11 = (Cpu.Pin)(PG + 11);
        public const Cpu.Pin PG12 = (Cpu.Pin)(PG + 12);
        public const Cpu.Pin PG13 = (Cpu.Pin)(PG + 13);
        public const Cpu.Pin PG14 = (Cpu.Pin)(PG + 14);
        public const Cpu.Pin PG15 = (Cpu.Pin)(PG + 15);

        public const Cpu.Pin PH0 = (Cpu.Pin)(PH + 0);
        public const Cpu.Pin PH1 = (Cpu.Pin)(PH + 1);
        public const Cpu.Pin PH2 = (Cpu.Pin)(PH + 2);
        public const Cpu.Pin PH3 = (Cpu.Pin)(PH + 3);
        public const Cpu.Pin PH4 = (Cpu.Pin)(PH + 4);
        public const Cpu.Pin PH5 = (Cpu.Pin)(PH + 5);
        public const Cpu.Pin PH6 = (Cpu.Pin)(PH + 6);
        public const Cpu.Pin PH7 = (Cpu.Pin)(PH + 7);
        public const Cpu.Pin PH8 = (Cpu.Pin)(PH + 8);
        public const Cpu.Pin PH9 = (Cpu.Pin)(PH + 9);
        public const Cpu.Pin PH10 = (Cpu.Pin)(PH + 10);
        public const Cpu.Pin PH11 = (Cpu.Pin)(PH + 11);
        public const Cpu.Pin PH12 = (Cpu.Pin)(PH + 12);
        public const Cpu.Pin PH13 = (Cpu.Pin)(PH + 13);
        public const Cpu.Pin PH14 = (Cpu.Pin)(PH + 14);
        public const Cpu.Pin PH15 = (Cpu.Pin)(PH + 15);
    }
}


