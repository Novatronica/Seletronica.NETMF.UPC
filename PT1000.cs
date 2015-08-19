using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    /// <summary>
    /// Oggetto sonda di temperatura PRT (Platinum Resistance Thermometers)
    /// </summary>
    public class PT1000 : Prt 
    {
 
        /// <summary>
        /// Costruttore
        /// </summary>
       public PT1000() : base(1000, 1000, 2.5) { }

       /// <summary>
       /// Costruttore
       /// </summary>
       /// <param name="res">Numero del canale analogico su cui è collegata la sonda</param>
       /// <param name="scale">Valore di scalatura del valore letto dal canale analogico</param>
       /// <param name="offset">Offset aggiunto sul valore letto dal canale analogico</param>
       public PT1000(ADC res, double scale, double offset) : base(res, scale, offset, 1000, 1000, 2.5) { }

       /// <summary>
       /// Costruttore
       /// </summary>
       /// <param name="res">Numero del canale analogico su cui è collegata la sonda</param>
       /// <param name="scale">Valore di scalatura del valore letto dal canale analogico</param>
       /// <param name="offset">Offset aggiunto sul valore letto dal canale analogico</param>
       /// <param name=" movingAverageSize">Dimensione del buffer per calcolo media</param>
       public PT1000(ADC res, double scale, double offset, int movingAverageSize) : base(res, scale, offset, movingAverageSize, 1000, 1000, 2.5) { }

        /// <summary>
        /// Costruttore
        /// </summary>
         /// <param name="rb">Il valore della resistenza utilizzata come partitore di tensione verso massa con l'PRT (in Ohm)</param>
         /// <param name="vref">Il Vref del convertitore A/D (in Volt)</param>
       public PT1000(double rb, double vref) : base(1000, rb, vref) { }

    }
}
