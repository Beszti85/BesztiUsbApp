using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortTool
{
    public partial class PcSerialTool
    {
        // Action command dictionary: command name and byte ID
        private readonly Dictionary<string, uint> ActCmdCodes = new Dictionary<string, uint>
        {
            { "FLASH_READ",   1 },
            { "FLASH_WRITE",  2 },
            { "FLASH_ERASE",  3 },
            { "DS1307_START", 4 },
            { "LED_TOGGLE",   5 },
            { "LED_PWM_CTRL", 6 },
        };
        // Read command dictionary: command name and byte ID with response data length (without ID)
        private readonly Dictionary<string, byte[]> ReadCodes = new Dictionary<string, byte[]>
        {
            { "BOARD_ID",    new byte[] { 0, 22 } },
            { "BME280_THP",  new byte[] { 1, 12 } },
            { "ADC_VOLTAGE", new byte[] { 2, 20 } },
            { "FLASH_ID",    new byte[] { 3, 1  } },
            { "LED_PWM",     new byte[] { 4, 4  } },
            { "FLASH_READ",  new byte[] { 5, 4  } },
            { "DAC_VOLTAGE", new byte[] { 6, 2  } }
        };
        // Flash type dictionary
        private readonly Dictionary<byte, string> FlashTypes = new Dictionary<byte, string>
        {
            { 0, "UNKNOWN"     },
            { 1, "W25Q64_M"    },
            { 2, "W25Q32JV_IQ" },
            { 3, "W25Q32JV_IM" },
            { 255, "NO FLASH"  },
        };
        public bool ProcessCommandAndRead(byte[] txBuffer, int txLength, int rxLength)
        {
            bool result = false;

            serialPort.DiscardInBuffer();
            serialPort.Write(txBuffer, 0, txLength);
            while (serialPort.BytesToRead != rxLength) ;
            serialPort.Read(RxBuffer, 0, serialPort.BytesToRead);
            result = SerialProtocol.GetDataField(RxBuffer, RespBuffer, rxLength);

            return result;
        }

        public void ProcessCommand(byte[] txBuffer, int txLength)
        {
            serialPort.DiscardInBuffer();
            serialPort.Write(txBuffer, 0, txLength);
        }
    }
}
