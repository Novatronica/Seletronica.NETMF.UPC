using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    /// <summary>
    /// Interfaccia sonda di temperatura
    /// </summary>
    public interface ITemperatureSensor
    {
        /// <summary>
        /// La temperatura letta in gradi Celsius
        /// </summary>
        double Temperature();
    }
}
