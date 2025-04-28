namespace SerialPortTool
{
    partial class Form1
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
            this.btnReadTemp = new System.Windows.Forms.Button();
            this.btnReadHum = new System.Windows.Forms.Button();
            this.tbTemperature = new System.Windows.Forms.TextBox();
            this.tbHumidity = new System.Windows.Forms.TextBox();
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
            // btnReadTemp
            // 
            this.btnReadTemp.Location = new System.Drawing.Point(27, 108);
            this.btnReadTemp.Name = "btnReadTemp";
            this.btnReadTemp.Size = new System.Drawing.Size(75, 23);
            this.btnReadTemp.TabIndex = 4;
            this.btnReadTemp.Text = "ReadTemp";
            this.btnReadTemp.UseVisualStyleBackColor = true;
            this.btnReadTemp.Click += new System.EventHandler(this.btnReadTemp_Click);
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
            this.tbTemperature.Location = new System.Drawing.Point(118, 108);
            this.tbTemperature.Name = "tbTemperature";
            this.tbTemperature.Size = new System.Drawing.Size(100, 20);
            this.tbTemperature.TabIndex = 6;
            this.tbTemperature.TextChanged += new System.EventHandler(this.tbTemperature_TextChanged);
            // 
            // tbHumidity
            // 
            this.tbHumidity.Location = new System.Drawing.Point(118, 138);
            this.tbHumidity.Name = "tbHumidity";
            this.tbHumidity.Size = new System.Drawing.Size(100, 20);
            this.tbHumidity.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbHumidity);
            this.Controls.Add(this.tbTemperature);
            this.Controls.Add(this.btnReadHum);
            this.Controls.Add(this.btnReadTemp);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.comboBoxComPorts);
            this.Controls.Add(this.btnRefresh);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox comboBoxComPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnReadTemp;
        private System.Windows.Forms.Button btnReadHum;
        private System.Windows.Forms.TextBox tbTemperature;
        private System.Windows.Forms.TextBox tbHumidity;
    }
}

