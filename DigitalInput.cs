using Microsoft.SPOT.Hardware;
using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    public class DigitalInput : InputPort
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome dell'ingresso digitale</param>
        public DigitalInput(Opto res)
            : base((Cpu.Pin)res, true, ResistorMode.Disabled)
        {
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome dell'ingresso digitale</param>
        public DigitalInput(Input res)
            : base((Cpu.Pin)res, true, ResistorMode.Disabled)
        {
        }

        public bool IsOn()
        {
            return Read() == false;
        }

        public bool IsOff()
        {
            return Read();
        }

    }
}
