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
    public partial class Form1 : Form
    {
        private SerialPort serialPort;

        public Form1()
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
                    serialPort.BaudRate = 9600; // Set your baud rate
                    byte[] data = {0, 1, 2, 3};
                    serialPort.Open();
                    serialPort.Write(data, 0, data.Length);
                    //serialPort.Close();
                    MessageBox.Show("Data sent successfully!");
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

        private void btnReadTemp_Click(object sender, EventArgs e)
        {
            byte[] data = { 0, 1, 2, 3 };
            serialPort.Write(data, 0, data.Length);
        }

        private void btnReadHum_Click(object sender, EventArgs e)
        {
            byte[] data = { 0, 1, 2, 3 };
            serialPort.Write(data, 0, data.Length);
        }

        private void tbTemperature_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
