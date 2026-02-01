using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortTool
{
    public static class SerialProtocol
    {
        public static int ResponseLength { get; set; }
        // Calculate simple CRC8
        public static byte CalcCrc8(byte[] data, byte start, byte length)
        {
            byte crc = start;

            for(int i = 0; i < length; i++)
            {
                crc += data[i];
            }
            return crc;
        }

        // Send DataRead Request
        public static byte[] DataRead(byte readId)
        {
            byte[] request = new byte[8];
            AddHeaderAndFooter(request, 2);
            request[4] = 1;
            request[5] = readId;
            byte[] crcdata = {1, readId};
            request[6] = CalcCrc8(crcdata, 0, 2);

            return request;
        }

        private static void AddHeaderAndFooter(byte[] buffer, byte length)
        {
            buffer[0] = 0xBE;
            buffer[1] = length;
            buffer[2] = buffer[1];
            buffer[3] = buffer[0];
            buffer[buffer.Length - 1] = 0x27;
        }

        public static string FormatHexRows(byte[] data, int perLine = 16)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                if ( (i % perLine == 0) && (i != 0) )
                {
                    sb.AppendLine();
                }
                sb.Append(data[i].ToString("X2")).Append(' ');
            }
            return sb.ToString().TrimEnd();
        }

        public static bool GetDataField(byte[] inBuffer, byte[] dataBuffer, int length)
        {
            bool retval = false;
            Array.Reverse(inBuffer, 0, length);
            // Check the response integrity
            // Byte0 and Byte3 - 0xBE
            // Byte1 and Byte2 - response length
            // Las byte: 0x27
            if (   (inBuffer[0] == 0xBE)
                && (inBuffer[0] == inBuffer[3])
                && (inBuffer[1]  == inBuffer[2])
                && (inBuffer[4 + inBuffer[1] + 1] == 0x27) )
            {
                // Save response length
                ResponseLength = inBuffer[1];
                // Check CRC
                Array.Copy(inBuffer, 4, dataBuffer, 0, ResponseLength);

                int calcCrc = CalcCrc8(dataBuffer, 0, inBuffer[1]);
                if ( inBuffer[4 + inBuffer[1]] == calcCrc )
                {
                    retval = true;
                }
            }
            return retval;
        }
    }
}
