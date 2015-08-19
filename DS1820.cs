using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    public class DS1820 : OneWireDevice, ITemperatureSensor 
	{
        private const byte SkipROM = 0xCC;
        private const byte StartTemperatureConversion = 0x44;
        private const byte ReadScratchPad = 0xBE;
 
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="res">Nome del canale 1-Wire</param>
        public DS1820(OW_Pin res) : base(res)
        {
        }

        public bool StartConversion()
        {
            // if reset finds no devices, just return 0
            if (Ow.TouchReset() == 0)
                return false;

            // address the device
            Ow.WriteByte(SkipROM);

            // tell the device to start temp conversion
            Ow.WriteByte(StartTemperatureConversion);

            return true;
        }

        public double Temperature()
        {
            // reset the bus
            Ow.TouchReset();

            // address the device
            Ow.WriteByte(SkipROM);

            // read the data from the sensor
            Ow.WriteByte(ReadScratchPad);

            // read the two bytes of data

            short data = (short)Ow.ReadByte();
            //data |= (ushort)(Ow.ReadByte() << 8); // MSB
            data += (short)(((short)Ow.ReadByte()) << 8);

            // reset the bus, we don't want more data than that
            Ow.TouchReset();

            // returns °C
            return data / 2.0;
        }
	}
}
