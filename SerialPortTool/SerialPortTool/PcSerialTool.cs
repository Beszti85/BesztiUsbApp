using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace SerialPortTool
{
    public partial class PcSerialTool : Form
    {
        public SerialPort serialPort;
        public byte[] RxBuffer = new byte[256];
        public byte[] TxBuffer = new byte[256];
        public byte[] RespBuffer = new byte[256];
        public bool LedCtrlEnable = false;
        public uint CmdCtrlSelect = 0;
        private readonly Timer TrackBarDebounceTimer;
        private byte TbLedPwm_Value = 0;

        private readonly Dictionary<string, uint> ActCmdCodes = new Dictionary<string, uint>
        {
            { "FLASH_READ",   1 },
            { "FLASH_WRITE",  2 },
            { "FLASH_ERASE",  3 },
            { "DS1307_START", 4 },
            { "LED_TOGGLE",   5 },
            { "LED_PWM_CTRL", 6 },
        };

        private readonly Dictionary<string, byte[]> ReadCodes = new Dictionary<string, byte[]>
        {
            { "BOARD_ID",    new byte[] { 0, 0  } },
            { "BME280_THP",  new byte[] { 1, 12 } },
            { "ADC_VOLTAGE", new byte[] { 2, 2  } },
            { "FLASH_ID",    new byte[] { 3, 4  } },
            { "LED_PWM",     new byte[] { 4, 4  } },
            { "FLASH_READ",  new byte[] { 5, 4  } },
            { "DAC_VOLTAGE", new byte[] { 6, 2  } }
        };

        public PcSerialTool()
        {
            InitializeComponent();
            TrackBarDebounceTimer = new Timer() { Interval = 300 };
            TrackBarDebounceTimer.Tick += TbLedPwm_DebounceTimerTick;
            serialPort = new SerialPort();
            RefreshComPorts();
        }

        private void RefreshComPorts()
        {
            comboBoxComPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            comboBoxComPorts.Items.AddRange(ports);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshComPorts();
        }

        private void comboBoxComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        } 

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxComPorts.SelectedItem != null)
                {
                    serialPort.PortName = comboBoxComPorts.SelectedItem.ToString();
                    serialPort.BaudRate = 115200; // Set your baud rate
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.ReadTimeout = 1000;
                    byte[] data = {0xBE, 2, 2, 0xBE, 0, 0, 0, 0x27};
                    serialPort.Open();
                    serialPort.DiscardInBuffer();
                    serialPort.Write(data, 0, data.Length);
                    MessageBox.Show("Data sent successfully!");
                    // Read Board ID
                    //byte[] data2 = SerialProtocol.DataRead(0);
                    //serialPort.Write(data2, 0, data2.Length);
                    //InfoBox.Text = serialPort.ReadLine();
                }
                else
                {
                    MessageBox.Show("Please select a COM port.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnReadBme280_Click(object sender, EventArgs e)
        {
            bool result = false;

            byte[] txData = SerialProtocol.DataRead(ReadCodes["BME280_THP"][0]);
            result = ProcessCommandAndRead(txData, txData.Length, 19);
            tbTemperature.Text = SerialProtocol.FormatHexRows(RespBuffer, 13, 16);
        }

        private void btnReadHum_Click(object sender, EventArgs e)
        {
            byte[] data = { 0, 1, 2, 3 };
            serialPort.Write(data, 0, data.Length);
            while(serialPort.BytesToRead == 0) ;
            serialPort.Read(RxBuffer, 0, serialPort.BytesToRead);
        }

        private void tbTemperature_TextChanged(object sender, EventArgs e)
        {
        }

        private void btFlashId_Click(object sender, EventArgs e)
        {
            bool result = false;

            byte[] txData = SerialProtocol.DataRead(ReadCodes["FLASH_ID"][0]);
            result = ProcessCommandAndRead(txData, txData.Length, 8);
            tbFlashType.Text = SerialProtocol.FormatHexRows(RespBuffer, 2, 16);
        }

        private void tbHumidity_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task SendAndShowResponse(byte[] payload, TextBox target)
        {
            if (serialPort.IsOpen == false)
            {
                MessageBox.Show("SerialPort is closed!", "Port Closed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    // Clear stale incoming data before new request
                    serialPort.DiscardInBuffer();
                }
                finally
                {
                    MessageBox.Show("Error!");
                }
            }
        }

        private void InfoBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Led_PWM_Scroll(object sender, EventArgs e)
        {
        }

        private void LedPwmCtrl_CheckedChanged(object sender, EventArgs e)
        {
            LedCtrlEnable = LedPwmCtrl.Checked;
        }

        private void LedPwmRead_Click(object sender, EventArgs e)
        {
            bool result = false;

            byte[] txData = SerialProtocol.DataRead(ReadCodes["LED_PWM"][0]);
            result = ProcessCommandAndRead(txData, txData.Length, 11);
            tbLedPwm.Text = SerialProtocol.FormatHexRows(RespBuffer, 4, 16);
        }

        private void tbLedPwm_TextChanged(object sender, EventArgs e)
        {

        }

        private void CbCmdSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = CbCmdSelect.SelectedItem.ToString();
            CmdCtrlSelect = ActCmdCodes[selectedValue];
        }

        private void BtnExeCommand_Click(object sender, EventArgs e)
        {
            byte[] txData = SerialProtocol.ActionCmd((byte)CmdCtrlSelect);
            ProcessCommand(txData, txData.Length);
        }

        private void tbLed_PWM_ValueChanged(object sender, EventArgs e)
        {
            if (LedCtrlEnable == true)
            {
                TrackBarDebounceTimer.Stop();
                TrackBarDebounceTimer.Start();
            }
        }
        private void TbLedPwm_DebounceTimerTick(object sender, EventArgs e)
        {
            TrackBarDebounceTimer.Stop();

            if (LedCtrlEnable == true)
            {
                byte[] cmdData = { (byte)ActCmdCodes["LED_PWM_CTRL"], (byte)Led_PWM.Value };
                byte[] txData = SerialProtocol.ActionCmdWithData(cmdData, 2);
                ProcessCommand(txData, txData.Length);
            }
        }

        private void BtReadADC_Click(object sender, EventArgs e)
        {
            bool result = false;

            byte[] txData = SerialProtocol.DataRead(ReadCodes["ADC_VOLTAGE"][0]);
            result = ProcessCommandAndRead(txData, txData.Length, 27);
            TbAdcVoltages.Text = SerialProtocol.FormatHexRows(RespBuffer, 26, 16);
        }
    }
}
