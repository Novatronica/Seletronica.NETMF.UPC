using System;
using System.IO.Ports;
using System.Text;
using Microsoft.SPOT.Hardware;
using System.Threading;
using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    public abstract class UartBase : SerialPort
    {
        protected UartBase(string port, int baudRate)
            : base(port, baudRate)
        {
        }

        /// <summary>
        /// Scrittura di una stringa sulla porta seriale
        /// l'invio della stringa viene completato con l'invio dei caratteri CR e LF
        /// </summary>
        /// <param name="message">Testo da inviare sulla porta seriale</param>
        public void WriteLine(string message)
        {
            Write(message + "\r\n");
        }

        /// <summary>
        /// Scrittura di una stringa sulla porta seriale
        /// </summary>
        /// <param name="message">Testo da inviare sulla porta seriale</param>
        public void Write(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Lettura di una stringa sulla porta seriale senza timeout
        /// </summary>
        public string ReadLine()
        {
            return ReadLine(-1);
        }

        /// <summary>
        /// Lettura di una stringa sulla porta seriale con timeout
        /// la stringa ricevuta dove essere terminata con i caratteri CR + LF
        /// </summary>
        public string ReadLine(int timeout)
        {
            DateTime receiveTime = DateTime.Now;
            bool lineReceived = false;
            StringBuilder sb = new StringBuilder();

            while (!lineReceived)
            {
                if (BytesToRead > 0)
                {
                    int c = ReadByte();
                    if (c >= 0)
                    {
                        // Ho ricevuto un carattere valido
                        // ignoro tutti i CR o LF che si trovano all'inizio di una stringa
                        // mentre considero la stringa terminata se ho ricevuto CR o LF e ho già qualche cosa nel buffer
                        if (c == '\r' || c == '\n')
                        {
                            if (sb.Length>0)
                            {
                                 lineReceived = true;
                            }
                        }
                        else sb.Append((char)c);
                        receiveTime = DateTime.Now;
                    }
                }
                else
                {
                    if (timeout > 0 && (DateTime.Now - receiveTime).Ticks / TimeSpan.TicksPerMillisecond > timeout)
                    {
                        return null;
                    }
                    Thread.Sleep(10);
                }
            }
            return sb.ToString();
        }
    }

    public class Rs232 : UartBase
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="port">Nome della porta di comunicazione</param>
        /// <param name="baudRate">Velocità di comunicazione</param>
        public Rs232(RS232 port, int baudRate)
            : base("COM" + ((int)port), baudRate)
        {
        }

    }

    public class Rs485 : UartBase
    {
        const int TxDelay = 10; // ms
        readonly OutputPort _txEnable;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="port">Nome della porta di comunicazione</param>
        /// <param name="baudRate">Velocità di comunicazione</param>
        public Rs485(RS485 port, int baudRate)
            : base("COM" + ((int)port), baudRate)
        {
            Cpu.Pin txEnablePin;
            switch (port)
            {
                case RS485.RS485_1:
                    txEnablePin = (Cpu.Pin)TxEnable.TX_ENABLE_1;
                    break;
                case RS485.RS485_2:
                    txEnablePin = (Cpu.Pin)TxEnable.TX_ENABLE_2;
                    break;
                default:
                    throw new ArgumentException("Porta non Valida", "port");
            }
            _txEnable = new OutputPort(txEnablePin, false);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _txEnable.Write(true);
            Thread.Sleep(TxDelay);

            base.Write(buffer, offset, count);
            while (BytesToWrite > 0)
            {
                Thread.Sleep(10);
            }

            Thread.Sleep(TxDelay);
            _txEnable.Write(false);
        }
    }
}
