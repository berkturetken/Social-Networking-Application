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
            this.button__addFriend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_friendName = new System.Windows.Forms.TextBox();
            this.button_friendRequests = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMyFriends = new System.Windows.Forms.Button();
            this.listBoxOnlineFriends = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ip
            // 
            this.ip.AutoSize = true;
            this.ip.Location = new System.Drawing.Point(21, 9);
            this.ip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(20, 13);
            this.ip.TabIndex = 0;
            this.ip.Text = "IP:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(47, 6);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(97, 20);
            this.textBox_ip.TabIndex = 1;
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(165, 9);
            this.Port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(29, 13);
            this.Port.TabIndex = 2;
            this.Port.Text = "Port:";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(198, 6);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(97, 20);
            this.textBox_port.TabIndex = 3;
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(380, 58);
            this.logs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(263, 254);
            this.logs.TabIndex = 4;
            this.logs.Text = "";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(482, 3);
            this.button_connect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(56, 25);
            this.button_connect.TabIndex = 5;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_message
            // 
            this.textBox_message.Location = new System.Drawing.Point(208, 342);
            this.textBox_message.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(347, 20);
            this.textBox_message.TabIndex = 6;
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(151, 345);
            this.message.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(53, 13);
            this.message.TabIndex = 7;
            this.message.Text = "Message:";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(570, 342);
            this.button_send.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.name.Location = new System.Drawing.Point(318, 9);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(38, 13);
            this.name.TabIndex = 9;
            this.name.Text = "Name:";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(362, 6);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 20);
            this.textBox_name.TabIndex = 10;
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(555, 3);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(71, 25);
            this.button_disconnect.TabIndex = 11;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // button__addFriend
            // 
            this.button__addFriend.Location = new System.Drawing.Point(198, 69);
            this.button__addFriend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button__addFriend.Name = "button__addFriend";
            this.button__addFriend.Size = new System.Drawing.Size(83, 19);
            this.button__addFriend.TabIndex = 12;
            this.button__addFriend.Text = "Add Friend";
            this.button__addFriend.UseVisualStyleBackColor = true;
            this.button__addFriend.Click += new System.EventHandler(this.button__addFriend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Friend Name:";
            // 
            // textBox_friendName
            // 
            this.textBox_friendName.Location = new System.Drawing.Point(90, 68);
            this.textBox_friendName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_friendName.Name = "textBox_friendName";
            this.textBox_friendName.Size = new System.Drawing.Size(104, 20);
            this.textBox_friendName.TabIndex = 14;
            // 
            // button_friendRequests
            // 
            this.button_friendRequests.Location = new System.Drawing.Point(47, 202);
            this.button_friendRequests.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_friendRequests.Name = "button_friendRequests";
            this.button_friendRequests.Size = new System.Drawing.Size(110, 24);
            this.button_friendRequests.TabIndex = 15;
            this.button_friendRequests.Text = "Friend Requests";
            this.button_friendRequests.UseVisualStyleBackColor = true;
            this.button_friendRequests.Click += new System.EventHandler(this.button_friendRequests_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Chat Box:";
            // 
            // btnMyFriends
            // 
            this.btnMyFriends.Location = new System.Drawing.Point(47, 240);
            this.btnMyFriends.Margin = new System.Windows.Forms.Padding(2);
            this.btnMyFriends.Name = "btnMyFriends";
            this.btnMyFriends.Size = new System.Drawing.Size(110, 24);
            this.btnMyFriends.TabIndex = 17;
            this.btnMyFriends.Text = "My Friends";
            this.btnMyFriends.UseVisualStyleBackColor = true;
            // 
            // listBoxOnlineFriends
            // 
            this.listBoxOnlineFriends.FormattingEnabled = true;
            this.listBoxOnlineFriends.Location = new System.Drawing.Point(236, 126);
            this.listBoxOnlineFriends.Name = "listBoxOnlineFriends";
            this.listBoxOnlineFriends.Size = new System.Drawing.Size(120, 186);
            this.listBoxOnlineFriends.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Online:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 384);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxOnlineFriends);
            this.Controls.Add(this.btnMyFriends);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_friendRequests);
            this.Controls.Add(this.textBox_friendName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button__addFriend);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button button__addFriend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_friendName;
        private System.Windows.Forms.Button button_friendRequests;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMyFriends;
        private System.Windows.Forms.ListBox listBoxOnlineFriends;
        private System.Windows.Forms.Label label3;
    }
}

