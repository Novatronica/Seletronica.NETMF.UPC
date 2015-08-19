using System;
using Microsoft.SPOT.Hardware;
using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    public class UniversalIO
    {
        private UIOMode _uioMode;
        protected DigitalInput DigitalIn;
        protected DigitalOutput DigitalOut;
        protected AnalogIn AnalogIn;
        protected UIOSelector SelPort;
        private SoftPWM _softPwm;
        private PWM _realPwm;
        private DigitalOutput _pwmSel;
        private MovingAverageCalculator _avg;
        private double _value;

        public double Value
        {
            get
            {
                if (_uioMode == UIOMode.UIOModeSoftPwm || _uioMode == UIOMode.UIOModeSoftDac)
                {
                    return _softPwm.DutyCycle;
                }
                if (_uioMode == UIOMode.UIOModeRealPwm || _uioMode == UIOMode.UIOModeRealDac)
                {
                    return _realPwm.DutyCycle;
                }
                if (_uioMode == UIOMode.UIOModeAnalogInput)
                {
                    return _value;
                }
                throw new ArgumentException("La modalità di funzionamento selezionata non è valida");
            }
            set
            {
                if (_uioMode == UIOMode.UIOModeSoftPwm || _uioMode == UIOMode.UIOModeSoftDac)
                {
                    if (value < 0) _softPwm.DutyCycle = 0;
                    else if (value > 1) _softPwm.DutyCycle = 1;
                    else _softPwm.DutyCycle = value;
                }
                else if (_uioMode == UIOMode.UIOModeRealPwm || _uioMode == UIOMode.UIOModeRealDac)
                {
                    if (value < 0) _realPwm.DutyCycle = 0;
                    else if (value > 1) _realPwm.DutyCycle = 1;
                    else _realPwm.DutyCycle = value;
                }
                else
                {
                    throw new ArgumentException("La modalità di funzionamento selezionata non è del tipo PWM o DAC");
                }
            }


        }
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome dell'uscita digitale</param>
        public UniversalIO(UIODigitalOutput res)
        {
            switch (res)
            {
                case UIODigitalOutput.UIO_OUT_1:
                    SelPort = UIOSelector.OUT_SEL_1;
                    break;
                case UIODigitalOutput.UIO_OUT_2:
                    SelPort = UIOSelector.OUT_SEL_2;
                    break;
                case UIODigitalOutput.UIO_OUT_3:
                    SelPort = UIOSelector.OUT_SEL_3;
                    break;
                case UIODigitalOutput.UIO_OUT_4:
                    SelPort = UIOSelector.OUT_SEL_4;
                    break;
                case UIODigitalOutput.UIO_OUT_5:
                    SelPort = UIOSelector.OUT_SEL_5;
                    break;
                case UIODigitalOutput.UIO_OUT_6:
                    SelPort = UIOSelector.OUT_SEL_6;
                    break;
                case UIODigitalOutput.UIO_OUT_7:
                    SelPort = UIOSelector.OUT_SEL_7;
                    break;
                case UIODigitalOutput.UIO_OUT_8:
                    SelPort = UIOSelector.OUT_SEL_8;
                    break;
                case UIODigitalOutput.UIO_OUT_9:
                    SelPort = UIOSelector.OUT_SEL_9;
                    break;
                case UIODigitalOutput.UIO_OUT_10:
                    SelPort = UIOSelector.OUT_SEL_10;
                    break;
                case UIODigitalOutput.UIO_OUT_11:
                    SelPort = UIOSelector.OUT_SEL_11;
                    break;
                case UIODigitalOutput.UIO_OUT_12:
                    SelPort = UIOSelector.OUT_SEL_12;
                    break;
                default:
                    throw new ArgumentException("Uscita non valida", "res");
            }
            Initialize(UIOMode.UIOModeDigitalOutput, (int)SelPort, (int)res, 0, true, 0, 0);           
  
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="ch">Nome del canale analogico</param>
        /// <param name="scale">Valore di scalatura del valore letto dal canale analogico</param>
        /// <param name="offset">Offset aggiunto sul valore letto dal canale analogico</param>
        public UniversalIO(UIO_ADC ch, double scale, double offset)
            : this(ch, scale, offset, 1)
        {
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="ch">Nome del canale analogico</param>
        /// <param name="scale">Valore di scalatura del valore letto dal canale analogico</param>
        /// <param name="offset">Offset aggiunto sul valore letto dal canale analogico</param>
        /// <param name="movingAverageSize">Dimensione del buffer per calcolo media</param>
        public UniversalIO(UIO_ADC ch, double scale, double offset, int movingAverageSize)
        {
            UIODigitalOutput cha;

            switch (ch)
            {
                case UIO_ADC.UIO_ADC_3:
                    SelPort = UIOSelector.OUT_SEL_3;
                    cha = UIODigitalOutput.UIO_OUT_3;
                    break;
                case UIO_ADC.UIO_ADC_4:
                    SelPort = UIOSelector.OUT_SEL_4;
                    cha = UIODigitalOutput.UIO_OUT_4;
                    break;
                case UIO_ADC.UIO_ADC_6:
                    SelPort = UIOSelector.OUT_SEL_6;
                    cha = UIODigitalOutput.UIO_OUT_6;
                    break;
                case UIO_ADC.UIO_ADC_7:
                    SelPort = UIOSelector.OUT_SEL_7;
                    cha = UIODigitalOutput.UIO_OUT_7;
                    break;
                case UIO_ADC.UIO_ADC_8:
                    SelPort = UIOSelector.OUT_SEL_8;
                    cha = UIODigitalOutput.UIO_OUT_8;
                    break;
                default:
                    throw new ArgumentException("ADC non valido", "ch");
            }
            // spengo mosfet per non influenzare lettura ADC
            DigitalOut = new DigitalOutput((Output)cha);
            DigitalOut.Write(false);

            Initialize(UIOMode.UIOModeAnalogInput, (int)SelPort, (int)ch, movingAverageSize, true, scale, offset);
                  
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="freq">Frequenza del PWM</param>    
        /// <param name="res">Nome dell'uscita digitale</param>
        public UniversalIO(UIOSoftPWM res, int freq)
        {
            switch(res)
            {
                case UIOSoftPWM.SPWM_2:
                    SelPort = UIOSelector.OUT_SEL_2;
                    break;
                case UIOSoftPWM.SPWM_3:
                    SelPort = UIOSelector.OUT_SEL_3;
                    break;
                case UIOSoftPWM.SPWM_4:
                    SelPort = UIOSelector.OUT_SEL_4;
                    break;
                case UIOSoftPWM.SPWM_5:
                    SelPort = UIOSelector.OUT_SEL_5;
                    break;
                case UIOSoftPWM.SPWM_7:
                    SelPort = UIOSelector.OUT_SEL_7;
                    break;
                case UIOSoftPWM.SPWM_8:
                    SelPort = UIOSelector.OUT_SEL_8;
                    break;
                case UIOSoftPWM.SPWM_9:
                    SelPort = UIOSelector.OUT_SEL_9;
                    break;
                case UIOSoftPWM.SPWM_10:
                    SelPort = UIOSelector.OUT_SEL_10;
                    break;
                case UIOSoftPWM.SPWM_11:
                    SelPort = UIOSelector.OUT_SEL_11;
                    break;
                case UIOSoftPWM.SPWM_12:
                    SelPort = UIOSelector.OUT_SEL_12;
                    break;
                default:
                    throw new ArgumentException("PWM non valido", "res");
            }

            Initialize(UIOMode.UIOModeSoftPwm, (int)SelPort, (int)res, freq, true, 0 , 0);
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="freq">Frequenza del PWM</param>    
        /// <param name="res">Nome dell'uscita digitale</param>
        public UniversalIO(UIORealPWM res, int freq)
        {
            switch (res)
            {
                case UIORealPWM.RPWM_1:
                    SelPort = UIOSelector.OUT_SEL_1;
                    break;
                case UIORealPWM.RPWM_6:
                    SelPort = UIOSelector.OUT_SEL_6;
                    break;
                default:
                    throw new ArgumentException("PWM non valido", "res");
            }

            Initialize(UIOMode.UIOModeRealPwm,  (int)SelPort, (int)res, freq, true, 0 , 0);

        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="freq">Frequenza del PWM</param>    
        /// <param name="res">Nome dell'uscita digitale</param>
        public UniversalIO(UIOSoftDAC res, int freq)
        {
            switch (res)
            {
                case UIOSoftDAC.DAC_SPWM_2:
                    SelPort = UIOSelector.OUT_SEL_2;
                    break;
                case UIOSoftDAC.DAC_SPWM_3:
                    SelPort = UIOSelector.OUT_SEL_3;
                    break;
                case UIOSoftDAC.DAC_SPWM_4:
                    SelPort = UIOSelector.OUT_SEL_4;
                    break;
                case UIOSoftDAC.DAC_SPWM_5:
                    SelPort = UIOSelector.OUT_SEL_5;
                    break;
                case UIOSoftDAC.DAC_SPWM_7:
                    SelPort = UIOSelector.OUT_SEL_7;
                    break;
                case UIOSoftDAC.DAC_SPWM_8:
                    SelPort = UIOSelector.OUT_SEL_8;
                    break;
                case UIOSoftDAC.DAC_SPWM_9:
                    SelPort = UIOSelector.OUT_SEL_9;
                    break;
                case UIOSoftDAC.DAC_SPWM_10:
                    SelPort = UIOSelector.OUT_SEL_10;
                    break;
                case UIOSoftDAC.DAC_SPWM_11:
                    SelPort = UIOSelector.OUT_SEL_11;
                    break;
                case UIOSoftDAC.DAC_SPWM_12:
                    SelPort = UIOSelector.OUT_SEL_12;
                    break;
                default:
                    throw new ArgumentException("DAC non valido", "res");
            }

            Initialize(UIOMode.UIOModeSoftDac, (int)SelPort, (int)res, freq, false, 0, 0);
        }


        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="freq">Frequenza del PWM</param>    
        /// <param name="res">Nome dell'uscita digitale</param>
        public UniversalIO(UIORealDAC res, int freq)
        {
            switch (res)
            {
                case UIORealDAC.DAC_RPWM_1:
                    SelPort = UIOSelector.OUT_SEL_1;
                    break;
                case UIORealDAC.DAC_RPWM_6:
                    SelPort = UIOSelector.OUT_SEL_6;
                    break;
                default:
                    throw new ArgumentException("DAC non valido", "res");
            }

            Initialize(UIOMode.UIOModeRealDac, (int)SelPort, (int)res, freq, false, 0, 0);
        }


        private void Initialize(UIOMode mode, int select, int hwres, int intParam, bool isDigital, double scale, double offset)
        {
            _uioMode = mode;
            SelPort = (UIOSelector)select;

            switch (mode)
            {
                case UIOMode.UIOModeDigitalInput:
                    break;
                case UIOMode.UIOModeDigitalOutput:
                    DigitalOut = new DigitalOutput((Output)hwres);
                    break;
                case UIOMode.UIOModeAnalogInput:
                    _avg = new MovingAverageCalculator(intParam);
                    AnalogIn = new AnalogIn((ADC)hwres, scale, offset, intParam) {Scale = scale, Offset = offset};
                    break;
                case UIOMode.UIOModeSoftPwm:
                    if (intParam < 1 || intParam > 1000)
                        throw new ArgumentOutOfRangeException("Il valore deve essere compreso nel range 1...1000 Hz", "freq");
                    //creo ed avvio il PWM software
                    _softPwm = new SoftPWM(intParam, (Cpu.Pin)hwres);
                    SoftPWM.Start();
                    break;
                case UIOMode.UIOModeRealPwm:
                    if (intParam < 1 || intParam > 1000000)
                        throw new ArgumentOutOfRangeException("Il valore deve essere compreso nel range 1...1 MHz", "freq");
                    //creo ed avvio il PWM hardware
                    _realPwm = new PWM((Cpu.PWMChannel)hwres, intParam, 0, false);
                    _realPwm.Start();
                    break;
                case UIOMode.UIOModeSoftDac:
                    if (intParam < 1 || intParam > 1000)
                        throw new ArgumentOutOfRangeException("Il valore deve essere compreso nel range 1...1000 Hz", "freq");
                    //creo ed avvio il PWM software
                    _softPwm = new SoftPWM(intParam, (Cpu.Pin)hwres);
                    SoftPWM.Start();
                    break;
                case UIOMode.UIOModeRealDac:
                    if (intParam < 1 || intParam > 1000000)
                        throw new ArgumentOutOfRangeException("Il valore deve essere compreso nel range 1...1 MHz", "freq");
                    //creo ed avvio il PWM hardware
                    _realPwm = new PWM((Cpu.PWMChannel)hwres, intParam, 0, false);
                    _realPwm.Start();
                    break;
                default:
                    break;
            }

            //seleziono sul modulo il tipo di uscita DAC/PWM
            _pwmSel = new DigitalOutput((Output)SelPort);
            _pwmSel.Write(isDigital);

        }

        public void On()
        {
            if(_uioMode != UIOMode.UIOModeDigitalOutput) 
                throw new ArgumentException("L'oggetto deve essere del tipo UIODigitalOutput");
            DigitalOut.Write(true);
        }

        public void Off()
        {
            if (_uioMode != UIOMode.UIOModeDigitalOutput)
                throw new ArgumentException("L'oggetto deve essere del tipo UIODigitalOutput");
            DigitalOut.Write(false);
        }

        public void Toggle()
        {
            if (_uioMode != UIOMode.UIOModeDigitalOutput)
                throw new ArgumentException("L'oggetto deve essere del tipo UIODigitalOutput");
            DigitalOut.Write(!DigitalOut.Read());
        }

        public double Read()
        {
            double val = AnalogIn.Read();
            _value =  _avg.Calculate(val);
            return _value;
        }
    }
}