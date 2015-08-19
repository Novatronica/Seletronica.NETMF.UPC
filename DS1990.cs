using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    public class DS1990 : OneWireDevice
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del canale 1-Wire</param>
        public DS1990(OW_Pin res) : base(res)
        {
        }

    }
}
