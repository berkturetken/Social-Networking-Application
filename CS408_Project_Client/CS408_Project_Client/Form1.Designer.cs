namespace CS408_Project_Client
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
            this.ip = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.message = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ip
            // 
            this.ip.AutoSize = true;
            this.ip.Location = new System.Drawing.Point(55, 55);
            this.ip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(20, 13);
            this.ip.TabIndex = 0;
            this.ip.Text = "IP:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(77, 51);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(97, 20);
            this.textBox_ip.TabIndex = 1;
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(44, 94);
            this.Port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(29, 13);
            this.Port.TabIndex = 2;
            this.Port.Text = "Port:";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(77, 90);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(97, 20);
            this.textBox_port.TabIndex = 3;
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(237, 53);
            this.logs.Margin = new System.Windows.Forms.Padding(2);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(191, 285);
            this.logs.TabIndex = 4;
            this.logs.Text = "";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(77, 163);
            this.button_connect.Margin = new System.Windows.Forms.Padding(2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(56, 25);
            this.button_connect.TabIndex = 5;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_message
            // 
            this.textBox_message.Location = new System.Drawing.Point(77, 249);
            this.textBox_message.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(76, 20);
            this.textBox_message.TabIndex = 6;
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(21, 251);
            this.message.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(53, 13);
            this.message.TabIndex = 7;
            this.message.Text = "Message:";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(168, 248);
            this.button_send.Margin = new System.Windows.Forms.Padding(2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(56, 19);
            this.button_send.TabIndex = 8;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(38, 127);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(38, 13);
            this.name.TabIndex = 9;
            this.name.Text = "Name:";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(77, 127);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 20);
            this.textBox_name.TabIndex = 10;
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(139, 163);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(71, 25);
            this.button_disconnect.TabIndex = 11;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 384);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.name);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.message);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.ip);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ip;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button_disconnect;
    }
}

