using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    /// <summary>
    /// Oggetto sonda di temperatura PRT (Platinum Resistance Thermometers)
    /// </summary>
    public class Prt : ITemperatureSensor
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
        /// Il valore della resistenza utilizzata come partitore di tensione con l'PRT (in Ohm)
        /// </summary>
        private readonly double _rb;

        /// <summary>
        /// Resistenza in Ohm dell'PRT alla temperatura T0
        /// </summary>
        private readonly double _r0;

        /// <summary>
        /// coefficente A per la scala ITS-90
        /// </summary>1
        private const double A = 3.9083E-3;

        /// <summary>
        /// coefficente B per la scala ITS-90
        /// </summary>
        private const double B = -5.775E-7;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="r0">Resistenza in Ohm dell'PRT alla temperatura T0</param>
        public Prt(int r0) : this(r0, 1000, 2.5) { }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="r0">Resistenza in Ohm dell'PRT alla temperatura T0</param>
        /// <param name="rb">Il valore della resistenza utilizzata come partitore di tensione verso massa con l'PRT (in Ohm)</param>
        /// <param name="vref">Il Vref del convertitore A/D (in Volt)</param>
        public Prt(int r0, double rb, double vref)
        {
            _r0 = r0;
            _rb = rb;
            _vref = vref;
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Numero del canale analogico su cui è collegata la sonda</param>
        /// <param name="scale">Valore di scalatura del valore letto dal canale analogico</param>
        /// <param name="offset">Offset aggiunto sul valore letto dal canale analogico</param>
        /// <param name="r0">Resistenza in Ohm dell'PRT alla temperatura T0</param>
        /// <param name="rb">Il valore della resistenza utilizzata come partitore di tensione verso massa con l'PRT (in Ohm)</param>
        /// <param name="vref">Il Vref del convertitore A/D (in Volt)</param>
        public Prt(ADC res, double scale, double offset,  int r0, double rb, double vref) : this(res, scale, offset, 1,r0, rb, vref)
        {
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Numero del canale analogico su cui è collegata la sonda</param>
        /// <param name="scale">Valore di scalatura del valore letto dal canale analogico</param>
        /// <param name="offset">Offset aggiunto sul valore letto dal canale analogico</param>
        /// <param name="movingAverageSize">Dimensione del buffer per calcolo media</param>
        /// <param name="r0">Resistenza in Ohm dell'PRT alla temperatura T0</param>
        /// <param name="rb">Il valore della resistenza utilizzata come partitore di tensione verso massa con l'PRT (in Ohm)</param>
        /// <param name="vref">Il Vref del convertitore A/D (in Volt)</param>
        public Prt(ADC res, double scale, double offset, int movingAverageSize, int r0, double rb, double vref) : this(r0, rb, vref)
        {
            _ai = new AnalogIn(res, movingAverageSize) {Scale = scale, Offset = offset};
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
            // Dalla lettura in volt del convertitore, la funzione inversa del partitore di tensione, calcolo la resistenza dell'PRT (in Ohm)
            double r = _rb * volt / (_vref - volt);

            // Calcolo della temperatura in base al valore in ohm della sonda
            double sqrtTerm = A * A * _r0 * _r0 - 4 * B * _r0 * _r0 + 4 * B * r * _r0;
            // Verifico se fuori scala
            if (sqrtTerm < 0) return 850;
            double t = -(A * _r0 - System.Math.Sqrt(sqrtTerm)) / (2 * B * _r0);
            return t;
        }
    }
}
