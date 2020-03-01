namespace mavlinkWinformClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serverPort = new System.Windows.Forms.TextBox();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Send = new System.Windows.Forms.Button();
            this.custom_mode = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server Port:";
            // 
            // serverPort
            // 
            this.serverPort.Location = new System.Drawing.Point(143, 75);
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(121, 25);
            this.serverPort.TabIndex = 1;
            this.serverPort.Text = "3333";
            // 
            // serverIP
            // 
            this.serverIP.Location = new System.Drawing.Point(143, 36);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(121, 25);
            this.serverIP.TabIndex = 1;
            this.serverIP.Text = "192.168.1.102";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(289, 75);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(113, 28);
            this.connect.TabIndex = 2;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Heartbeat:";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(289, 172);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(113, 28);
            this.Send.TabIndex = 2;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // custom_mode
            // 
            this.custom_mode.Location = new System.Drawing.Point(143, 172);
            this.custom_mode.Name = "custom_mode";
            this.custom_mode.Size = new System.Drawing.Size(121, 25);
            this.custom_mode.TabIndex = 1;
            this.custom_mode.Text = "2";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(352, 315);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(44, 225);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 345);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recived:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.custom_mode);
            this.Controls.Add(this.serverPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "mavlinkClient V0.0.1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverPort;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox custom_mode;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

