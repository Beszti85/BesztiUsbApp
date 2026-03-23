using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortTool
{
    public partial class PcSerialTool
    {
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
