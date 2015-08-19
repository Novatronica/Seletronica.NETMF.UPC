using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Seletronica.NETMF.UPC.Enums;

/*
  SearchROM = 0xF0,
  ReadROM = 0x33,
  MatchROM = 0x55,
  SkipROM = 0xCC,
  AlarmSearch = 0xEC,
  StartTemperatureConversion = 0x44,
  ReadScratchPad = 0xBE,
  WriteScratchPad = 0x4E,
  CopySratchPad = 0x48,
  RecallEEPROM = 0xB8,
  ReadPowerSupply = 0xB4,
 */

namespace Seletronica.NETMF.UPC
{
    public abstract class OneWireDevice
    {
        protected OneWire Ow;
        private const byte ReadROM = 0x33;

        /// <summary>
        /// L'elenco delle cifre esadecimali
        /// </summary>
        private const string HexDigits = "0123456789ABCDEF";

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del canale 1-Wire</param>
        protected OneWireDevice(OW_Pin res)
        {
            Ow = new OneWire(new OutputPort((Cpu.Pin)res, false));
        }

        protected static string ByteArrayToHexString(byte[] bytes, int offset, int count)
        {
            char[] c = new char[count * 2];
            ByteArrayToHexString(bytes, offset, count, ref c);
            return new string(c);
        }

        protected static void ByteArrayToHexString(byte[] bytes, int offset, int count, ref char[] destination)
        {
            if (destination == null) throw new ArgumentNullException("destination", "non può essere null");
            if (destination.Length < count * 2) throw new ArgumentNullException("destination", "La dimensione del vettore deve essere almeno di " + count*2 + " elementi");
            
            for (int i = offset, x = 0; i < offset + count; i++)
            {
                destination[x++] = HexDigits[(bytes[i] & 0xF0) >> 4];
                destination[x++] = HexDigits[bytes[i] & 0x0F];
            }
        }

        /// <summary>
        /// Lettura del codice ROM di identificazione
        /// </summary>
        public string GetRomCode(bool checkCrc = true)
        {
            byte[] code = new byte[8];
            
            try
            {
                // verifico se sul bus è presente un dispositivo 1-Wire
                if (Ow.TouchReset() > 0)
                {
                    // invio comando lettura codice ROM
                    Ow.WriteByte(ReadROM);

                    // Ricezione del codice ROM composto da 8 byte
                    for (int i = 0; i < 8; i++)
                    {
                        code[i] = (byte)Ow.TouchByte(0xFF);
                    }

                    // Verifico se è un codice valido
                    if(checkCrc)
                    {
                        if (OnewireUtil.ComputeCrc(code, 0, 7) == code[7])
                        {
                            // Chiave valida
                            return ByteArrayToHexString(code, 0, 8);
                        }
                        return "";
                    }
                    if (code[0] != 0)
                    {
                        return ByteArrayToHexString(code, 0, 8);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return "";
        }
    }

    
}
