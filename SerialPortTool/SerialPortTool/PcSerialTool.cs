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
        public byte[] RespBuffer = new byte[256];

        public PcSerialTool()
        {
            InitializeComponent();
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

            byte[] txData = SerialProtocol.DataRead(1);
            result = ProcessCommand(txData, txData.Length, 19);
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

            byte[] txData = SerialProtocol.DataRead(3);
            result = ProcessCommand(txData, txData.Length, 8);
            tbFlashType.Text = SerialProtocol.FormatHexRows(RespBuffer, 2, 16);
        }

        private void tbHumidity_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        }

        private void LedPwmRead_Click(object sender, EventArgs e)
        {

        }

        private void tbLedPwm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
