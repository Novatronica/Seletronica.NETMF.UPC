namespace Seletronica.NETMF.UPC
{
    class OnewireUtil
    {
        /// <summary>
        /// Calcola il CRC8 (Dallas) di un buffer
        /// </summary>
        /// <param name="buf">il buffer contenente i dati</param>
        /// <param name="offset">l'indice di partenza</param>
        /// <param name="len">il numero di byte da prendere in considerazione</param>
        /// <returns></returns>
        public static byte ComputeCrc(byte[] buf, int offset, int len)
        {
            byte crc = 0;

            for (int i = offset; i < offset + len; i++)
            {
                byte inbyte = buf[i];
                for (int j = 8; j != 0; j--)
                {
                    byte mix = (byte)((byte)(crc ^ inbyte) & 0x01);
                    crc >>= 1;
                    if (mix != 0) crc ^= 0x8C;
                    inbyte >>= 1;
                }
            }

            return crc;
        }
    }
}