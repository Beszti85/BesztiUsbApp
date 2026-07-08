using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SerialPortTool
{
    public partial class PcSerialTool
    {
        // Action command dictionary: command name and byte ID
        private readonly Dictionary<string, uint> ActCmdCodes = new Dictionary<string, uint>
        {
            { "FLASH_READ",      1 },
            { "FLASH_WRITE",     2 },
            { "FLASH_ERASE",     3 },
            { "DS1307_START",    4 },
            { "LED_TOGGLE",      5 },
            { "LED_PWM_CTRL",    6 },
            { "DS1307_SQW",     17 },
            { "NRF24_READ_1B",  21 },
            { "NRF24_WRITE_1B", 22 },
        };
        // Read command dictionary: command name and byte ID with response data length (without ID)
        private readonly Dictionary<string, byte[]> ReadCodes = new Dictionary<string, byte[]>
        {
            { "BOARD_ID",    new byte[] { 0, 22 } },
            { "BME280_THP",  new byte[] { 1, 24 } },
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
        // NRF24L01 register ID dictionary
        private readonly Dictionary<string, byte> NRF24Registers = new Dictionary<string, byte>
        {
            { "CONFIG",    0 }, 
            { "EN_AA",     1 },
            { "EN_RXADDR", 2 },
            { "SETUP_AW",  3 },
            { "SETUP_RETR", 4 },
            { "RF_CH", 5 },
            { "RF_SETUP", 6 },
            { "STATUS", 7 },
            { "OBSERVE_TX", 8 },
            { "RPD", 9 },
            { "RX_PW_P0", 10 },
            { "RX_PW_P1", 11 },
            { "RX_PW_P2", 12 },
            { "RX_PW_P3", 13 },
            { "RX_PW_P5", 14 },
            { "FIFO_STATUS", 15 },
            { "DYNPD", 16 }
        };
        public bool ProcessCommandAndRead(byte[] txBuffer, int txLength, int rxLength)
        {
            bool result = false;

            serialPort.DiscardInBuffer();
            AppLogger.Debug("Sending command: " + SerialProtocol.FormatHexRows(txBuffer, txLength));
            serialPort.Write(txBuffer, 0, txLength);
            while (serialPort.BytesToRead != rxLength) ;
            serialPort.Read(RxBuffer, 0, serialPort.BytesToRead);
            AppLogger.Debug("Received data: " + SerialProtocol.FormatHexRows(RxBuffer, rxLength));
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
