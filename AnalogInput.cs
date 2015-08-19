using System;
using Microsoft.SPOT.Hardware;
using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    public class AnalogIn : AnalogInput
    {
        private readonly MovingAverageCalculator _avg;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del canale analogico</param>
        public AnalogIn(ADC res)
            : this(res, 1, 0, 1)
        {
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del canale analogico</param>
        /// <param name="movingAverageSize">Dimensione del buffer per calcolo media</param>
        public AnalogIn(ADC res, int movingAverageSize)
            : this(res, 1, 0, movingAverageSize)
        {
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del canale analogico</param>
        /// <param name="scale">Valore di scalatura del valore letto dal canale analogico</param>
        /// <param name="offset">Offset aggiunto sul valore letto dal canale analogico</param> 
        public AnalogIn(ADC res, double scale, double offset)
            : this(res, scale, offset, 1)
        {
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del canale analogico</param>
        /// <param name="scale">Valore di scalatura del valore letto dal canale analogico</param>
        /// <param name="offset">Offset aggiunto sul valore letto dal canale analogico</param>
        /// <param name="movingAverageSize">Dimensione del buffer per calcolo media</param>
        public AnalogIn(ADC res, double scale, double offset, int movingAverageSize)
            : base((Cpu.AnalogChannel)res)
        {
            _avg = new MovingAverageCalculator(movingAverageSize);
            Scale = scale;
            Offset = offset;
        }

        public double Read()
        {
            double val = base.Read();
            return _avg.Calculate(val);
        }

    }

    public class MovingAverageCalculator
    {
        private readonly double[] _array;
        private readonly int _arraySize;
        private int _index;
        private int _sample;
        private double _total;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="arraySize">Dimensione del buffer per calcolo media</param>
        public MovingAverageCalculator(int arraySize)
        {
            if (arraySize < 1)
                throw new ArgumentOutOfRangeException("arraySize", "Il parametro deve essere maggiore di 0");

            _arraySize = arraySize;
            _array = new double[_arraySize];

            Reset();
        }

        // Calcolo della Moving Average
        public double Calculate(double newValue)
        {
            if (_arraySize == 1) return newValue;

            if (_sample < _arraySize)
                _sample++;
 
            //rimuovo dal totalizzatore il valore più vecchio
            _total -= _array[_index];

            //aggiungo al totalizzatore il nuovo valore 
            _total += newValue;

            //salvo nell'array il nuovo valore
            _array[_index] = newValue;

            _index++;

            if (_index == _arraySize)
                _index = 0;

            return _total / _sample;
        }

        public bool IsFull
        {
            get { return _sample == _arraySize; }
        }

        public void Reset()
        {
            _sample = 0;
            _index = 0;
            _total = 0;
        }
    }

}
