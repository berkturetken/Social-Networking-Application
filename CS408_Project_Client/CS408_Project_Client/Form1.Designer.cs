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
            this.button_addFriend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_friendName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_friendsList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_friendRequests = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_accept = new System.Windows.Forms.Button();
            this.button_reject = new System.Windows.Forms.Button();
            this.btnDeleteFriend = new System.Windows.Forms.Button();
            this.btnSendToFriends = new System.Windows.Forms.Button();
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
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(2);
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
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(97, 20);
            this.textBox_port.TabIndex = 3;
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(380, 58);
            this.logs.Margin = new System.Windows.Forms.Padding(2);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(263, 254);
            this.logs.TabIndex = 4;
            this.logs.Text = "";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(482, 3);
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
            this.textBox_message.Location = new System.Drawing.Point(87, 348);
            this.textBox_message.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(347, 20);
            this.textBox_message.TabIndex = 6;
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(21, 351);
            this.message.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(53, 13);
            this.message.TabIndex = 7;
            this.message.Text = "Message:";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(450, 349);
            this.button_send.Margin = new System.Windows.Forms.Padding(2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(56, 24);
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
            // button_addFriend
            // 
            this.button_addFriend.Location = new System.Drawing.Point(198, 69);
            this.button_addFriend.Margin = new System.Windows.Forms.Padding(2);
            this.button_addFriend.Name = "button_addFriend";
            this.button_addFriend.Size = new System.Drawing.Size(83, 19);
            this.button_addFriend.TabIndex = 12;
            this.button_addFriend.Text = "Add Friend";
            this.button_addFriend.UseVisualStyleBackColor = true;
            this.button_addFriend.Click += new System.EventHandler(this.button__addFriend_Click);
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
            this.textBox_friendName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_friendName.Name = "textBox_friendName";
            this.textBox_friendName.Size = new System.Drawing.Size(104, 20);
            this.textBox_friendName.TabIndex = 14;
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
            // listBox_friendsList
            // 
            this.listBox_friendsList.FormattingEnabled = true;
            this.listBox_friendsList.Location = new System.Drawing.Point(236, 126);
            this.listBox_friendsList.Name = "listBox_friendsList";
            this.listBox_friendsList.Size = new System.Drawing.Size(120, 186);
            this.listBox_friendsList.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Friends List";
            // 
            // listBox_friendRequests
            // 
            this.listBox_friendRequests.FormattingEnabled = true;
            this.listBox_friendRequests.Location = new System.Drawing.Point(23, 126);
            this.listBox_friendRequests.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_friendRequests.Name = "listBox_friendRequests";
            this.listBox_friendRequests.Size = new System.Drawing.Size(122, 186);
            this.listBox_friendRequests.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Friend Requests";
            // 
            // button_accept
            // 
            this.button_accept.Location = new System.Drawing.Point(23, 316);
            this.button_accept.Margin = new System.Windows.Forms.Padding(2);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(56, 24);
            this.button_accept.TabIndex = 22;
            this.button_accept.Text = "Accept";
            this.button_accept.UseVisualStyleBackColor = true;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // button_reject
            // 
            this.button_reject.Location = new System.Drawing.Point(87, 316);
            this.button_reject.Margin = new System.Windows.Forms.Padding(2);
            this.button_reject.Name = "button_reject";
            this.button_reject.Size = new System.Drawing.Size(56, 24);
            this.button_reject.TabIndex = 23;
            this.button_reject.Text = "Reject";
            this.button_reject.UseVisualStyleBackColor = true;
            this.button_reject.Click += new System.EventHandler(this.button_reject_Click);
            // 
            // btnDeleteFriend
            // 
            this.btnDeleteFriend.Location = new System.Drawing.Point(260, 316);
            this.btnDeleteFriend.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteFriend.Name = "btnDeleteFriend";
            this.btnDeleteFriend.Size = new System.Drawing.Size(56, 24);
            this.btnDeleteFriend.TabIndex = 24;
            this.btnDeleteFriend.Text = "Delete";
            this.btnDeleteFriend.UseVisualStyleBackColor = true;
            this.btnDeleteFriend.Click += new System.EventHandler(this.btnDeleteFriend_Click);
            // 
            // btnSendToFriends
            // 
            this.btnSendToFriends.Location = new System.Drawing.Point(526, 348);
            this.btnSendToFriends.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendToFriends.Name = "btnSendToFriends";
            this.btnSendToFriends.Size = new System.Drawing.Size(117, 25);
            this.btnSendToFriends.TabIndex = 25;
            this.btnSendToFriends.Text = "Send Only Friends";
            this.btnSendToFriends.UseVisualStyleBackColor = true;
            this.btnSendToFriends.Click += new System.EventHandler(this.btnSendToFriends_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 384);
            this.Controls.Add(this.btnSendToFriends);
            this.Controls.Add(this.btnDeleteFriend);
            this.Controls.Add(this.button_reject);
            this.Controls.Add(this.button_accept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox_friendRequests);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox_friendsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_friendName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_addFriend);
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
        private System.Windows.Forms.Button button_addFriend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_friendName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_friendsList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_friendRequests;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.Button button_reject;
        private System.Windows.Forms.Button btnDeleteFriend;
        private System.Windows.Forms.Button btnSendToFriends;
    }
}

