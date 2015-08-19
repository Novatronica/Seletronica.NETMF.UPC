using Microsoft.SPOT.Hardware;
using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    public class DigitalOutput : OutputPort
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome dell'uscita</param>
        public DigitalOutput(Output res)
            : base((Cpu.Pin)res, false)
        {
        }

        public void On(){
            Write(false);
        }

        public void Off()
        {
            Write(true);
        }

        public void Toggle()
        {
            Write(!Read());
        }

    }
}
