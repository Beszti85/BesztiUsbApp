namespace SerialPortTool
{
    partial class PcSerialTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.comboBoxComPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnReadBme280 = new System.Windows.Forms.Button();
            this.btnReadHum = new System.Windows.Forms.Button();
            this.tbTemperature = new System.Windows.Forms.TextBox();
            this.tbHumidity = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ReadADC = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.InfoBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(27, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // comboBoxComPorts
            // 
            this.comboBoxComPorts.FormattingEnabled = true;
            this.comboBoxComPorts.Location = new System.Drawing.Point(27, 26);
            this.comboBoxComPorts.Name = "comboBoxComPorts";
            this.comboBoxComPorts.Size = new System.Drawing.Size(156, 21);
            this.comboBoxComPorts.TabIndex = 2;
            this.comboBoxComPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxComPorts_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(108, 53);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnReadBme280
            // 
            this.btnReadBme280.Location = new System.Drawing.Point(27, 109);
            this.btnReadBme280.Name = "btnReadBme280";
            this.btnReadBme280.Size = new System.Drawing.Size(85, 23);
            this.btnReadBme280.TabIndex = 4;
            this.btnReadBme280.Text = "ReadBME280";
            this.btnReadBme280.UseVisualStyleBackColor = true;
            this.btnReadBme280.Click += new System.EventHandler(this.btnReadBme280_Click);
            // 
            // btnReadHum
            // 
            this.btnReadHum.Location = new System.Drawing.Point(27, 138);
            this.btnReadHum.Name = "btnReadHum";
            this.btnReadHum.Size = new System.Drawing.Size(75, 23);
            this.btnReadHum.TabIndex = 5;
            this.btnReadHum.Text = "ReadHum";
            this.btnReadHum.UseVisualStyleBackColor = true;
            this.btnReadHum.Click += new System.EventHandler(this.btnReadHum_Click);
            // 
            // tbTemperature
            // 
            this.tbTemperature.Location = new System.Drawing.Point(129, 109);
            this.tbTemperature.Name = "tbTemperature";
            this.tbTemperature.Size = new System.Drawing.Size(100, 20);
            this.tbTemperature.TabIndex = 6;
            this.tbTemperature.TextChanged += new System.EventHandler(this.tbTemperature_TextChanged);
            // 
            // tbHumidity
            // 
            this.tbHumidity.Location = new System.Drawing.Point(129, 140);
            this.tbHumidity.Name = "tbHumidity";
            this.tbHumidity.Size = new System.Drawing.Size(100, 20);
            this.tbHumidity.TabIndex = 7;
            this.tbHumidity.TextChanged += new System.EventHandler(this.tbHumidity_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "FlashId";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 168);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            // 
            // ReadADC
            // 
            this.ReadADC.Location = new System.Drawing.Point(27, 207);
            this.ReadADC.Name = "ReadADC";
            this.ReadADC.Size = new System.Drawing.Size(75, 23);
            this.ReadADC.TabIndex = 10;
            this.ReadADC.Text = "ReadADC";
            this.ReadADC.UseVisualStyleBackColor = true;
            this.ReadADC.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(129, 209);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 11;
            // 
            // InfoBox
            // 
            this.InfoBox.Location = new System.Drawing.Point(203, 53);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(263, 20);
            this.InfoBox.TabIndex = 12;
            this.InfoBox.TextChanged += new System.EventHandler(this.InfoBox_TextChanged);
            // 
            // PcSerialTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.ReadADC);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbHumidity);
            this.Controls.Add(this.tbTemperature);
            this.Controls.Add(this.btnReadHum);
            this.Controls.Add(this.btnReadBme280);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.comboBoxComPorts);
            this.Controls.Add(this.btnRefresh);
            this.Name = "PcSerialTool";
            this.Text = "SerialTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox comboBoxComPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnReadBme280;
        private System.Windows.Forms.Button btnReadHum;
        private System.Windows.Forms.TextBox tbTemperature;
        private System.Windows.Forms.TextBox tbHumidity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ReadADC;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox InfoBox;
    }
}

