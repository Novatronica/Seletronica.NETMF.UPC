using Microsoft.SPOT.Hardware;
using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    
    public class AnalogOut : AnalogOutput
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del canale analogico</param>
        public AnalogOut(DAC res)
            : this(res, 1, 0)
        {
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del canale analogico</param>
        /// <param name="scale">Valore di scalatura (gain) del valore scritto dal canale analogico</param>
        /// <param name="offset">Offset aggiunto sul valore scritto dal canale analogico</param>
        public AnalogOut(DAC res, double scale, double offset)
            : base((Cpu.AnalogOutputChannel)res)
        {
            Scale = scale;
            Offset = offset;
        }

    }

}
