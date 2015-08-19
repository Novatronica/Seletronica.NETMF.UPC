using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    /// <summary>
    /// Oggetto sonda di temperatura NTC
    /// </summary>
    public class Ntc : ITemperatureSensor
    {
        /// <summary>
        /// Canale analogico su cui è collegata la sonda
        /// </summary>
        private readonly AnalogIn _ai;

        /// <summary>
        /// Il Vref del convertitore A/D (in Volt)
        /// </summary>
        private readonly double _vref;

        /// <summary>
        /// Il valore della resistenza a temperatura infinita
        /// </summary>
        private readonly double _rinf;

        /// <summary>
        /// Il valore della resistenza utilizzata come partitore di tensione con l'NTC (in Ohm)
        /// </summary>
        private readonly double _rb;

        /// <summary>
        /// Parametro beta del termistore (l'equazione di Steinhart-Hart con c=0)
        /// </summary>
        private readonly double _beta;

        /// <summary>
        /// Resistenza in Ohm dell'NTC alla temperatura T0
        /// Part number NTCLE203E3502SB0 o NTCLE203E3502JB0
        /// </summary>
        private readonly double _r0;

        /// <summary>
        /// Temperatura a cui è definito il parametro R0 (in gradi Kelvin)
        /// </summary>
        private const double T0 = 25 + 273.15; // 25 °C == 298.15 °K

        /// <summary>
        /// Costruttore
        /// </summary>
      /// <param name="r0">Resistenza nominale a 25 gradi centigradi espressa in Ohm</param>
        /// <param name="beta">Coefficiente specifico della sonda (normalmente quello indicato nell'intervallo di temperatura 25-85 gradi centigradi)</param>
        public Ntc(int r0, int beta) : this(r0,  1000, beta, 2.5) { }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Numero del canale analogico su cui è collegata la sonda</param>
        /// <param name="scale">Valore di scalatura del valore letto dal canale analogico</param>
        /// <param name="offset">Offset aggiunto sul valore letto dal canale analogico</param>
        /// <param name="r0">Resistenza nominale a 25 gradi centigradi espressa in Ohm</param>
        /// <param name="rb">Il valore della resistenza utilizzata come partitore di tensione verso massa con l'NTC (in Ohm)</param>
        /// <param name="beta">Coefficiente specifico della sonda (normalmente quello indicato nell'intervallo di temperatura 25-85 gradi centigradi)</param>
        /// <param name="vref">Il Vref del convertitore A/D (in Volt)</param>
        public Ntc(ADC res, double scale, double offset, int r0, double rb, int beta, double vref) : this(res, scale, offset, 1, r0, rb, beta, vref)
        {
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Numero del canale analogico su cui è collegata la sonda</param>
        /// <param name="scale">Valore di scalatura del valore letto dal canale analogico</param>
        /// <param name="offset">Offset aggiunto sul valore letto dal canale analogico</param>
        /// <param name="movingAverageSize">Dimensione del buffer per calcolo media</param>
        /// <param name="r0">Resistenza nominale a 25 gradi centigradi espressa in Ohm</param>
        /// <param name="rb">Il valore della resistenza utilizzata come partitore di tensione verso massa con l'NTC (in Ohm)</param>
        /// <param name="beta">Coefficiente specifico della sonda (normalmente quello indicato nell'intervallo di temperatura 25-85 gradi centigradi)</param>
        /// <param name="vref">Il Vref del convertitore A/D (in Volt)</param>
        public Ntc(ADC res, double scale, double offset, int movingAverageSize, int r0, double rb, int beta, double vref) : this(r0, rb, beta, vref)
        {
            _ai = new AnalogIn(res, movingAverageSize) {Scale = scale, Offset = offset};
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="r0">Resistenza nominale a 25 gradi centigradi espressa in Ohm</param>
        /// <param name="beta">Coefficiente specifico della sonda (normalmente quello indicato nell'intervallo di temperatura 25-85 gradi centigradi)</param>
        /// <param name="rb">Il valore della resistenza utilizzata come partitore di tensione verso massa con l'NTC (in Ohm)</param>
        /// <param name="vref">Il Vref del convertitore A/D (in Volt)</param>
        public Ntc(int r0,  double rb, int beta, double vref)
        {
            _r0 = r0;
            _beta = beta;
            _vref = vref;
            _rb = rb;
            _rinf = _r0 * System.Math.Exp(-_beta / T0);
        }

        /// <summary>
        /// La temperatura letta in gradi Celsius
        /// </summary>
        public double Temperature()
        {
            // Lettura del canale analogico
            return Temperature(_ai.Read());
        }

        /// <summary>
        /// La temperatura letta in gradi Celsius
        /// </summary>
        /// <param name="volt">Il valore di tensione letto dal canale analogico su cui è collegata la sonda</param>
        public double Temperature(double volt)
        {
            // Dalla lettura in volt del convertitore, la funzione inversa del partitore di tensione, calcolo la resistenza dell'NTC (in Ohm)
            double r = _rb * volt / (_vref - volt);

            // T = Beta / ln(R/Rinf) in Kelvin
            return _beta / System.Math.Log(r / _rinf) - 273.15;
        }
    }
}
