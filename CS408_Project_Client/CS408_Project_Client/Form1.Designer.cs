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
            this.btnMyFriends = new System.Windows.Forms.Button();
            this.listBox_friendsList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_friendRequests = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_accept = new System.Windows.Forms.Button();
            this.button_reject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ip
            // 
            this.ip.AutoSize = true;
            this.ip.Location = new System.Drawing.Point(28, 11);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(24, 17);
            this.ip.TabIndex = 0;
            this.ip.Text = "IP:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(63, 7);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(128, 22);
            this.textBox_ip.TabIndex = 1;
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(220, 11);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(38, 17);
            this.Port.TabIndex = 2;
            this.Port.Text = "Port:";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(264, 7);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(128, 22);
            this.textBox_port.TabIndex = 3;
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(507, 71);
            this.logs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(349, 312);
            this.logs.TabIndex = 4;
            this.logs.Text = "";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(643, 4);
            this.button_connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 31);
            this.button_connect.TabIndex = 5;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_message
            // 
            this.textBox_message.Location = new System.Drawing.Point(276, 425);
            this.textBox_message.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(461, 22);
            this.textBox_message.TabIndex = 6;
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(201, 425);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(69, 17);
            this.message.TabIndex = 7;
            this.message.Text = "Message:";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(760, 425);
            this.button_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 8;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(424, 11);
            this.name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(49, 17);
            this.name.TabIndex = 9;
            this.name.Text = "Name:";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(483, 7);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(132, 22);
            this.textBox_name.TabIndex = 10;
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(740, 4);
            this.button_disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(95, 31);
            this.button_disconnect.TabIndex = 11;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // button_addFriend
            // 
            this.button_addFriend.Location = new System.Drawing.Point(264, 85);
            this.button_addFriend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_addFriend.Name = "button_addFriend";
            this.button_addFriend.Size = new System.Drawing.Size(111, 23);
            this.button_addFriend.TabIndex = 12;
            this.button_addFriend.Text = "Add Friend";
            this.button_addFriend.UseVisualStyleBackColor = true;
            this.button_addFriend.Click += new System.EventHandler(this.button__addFriend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Friend Name:";
            // 
            // textBox_friendName
            // 
            this.textBox_friendName.Location = new System.Drawing.Point(120, 84);
            this.textBox_friendName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_friendName.Name = "textBox_friendName";
            this.textBox_friendName.Size = new System.Drawing.Size(137, 22);
            this.textBox_friendName.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Chat Box:";
            // 
            // btnMyFriends
            // 
            this.btnMyFriends.Location = new System.Drawing.Point(31, 439);
            this.btnMyFriends.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMyFriends.Name = "btnMyFriends";
            this.btnMyFriends.Size = new System.Drawing.Size(147, 23);
            this.btnMyFriends.TabIndex = 17;
            this.btnMyFriends.Text = "My Friends";
            this.btnMyFriends.UseVisualStyleBackColor = true;
            // 
            // listBox_friendsList
            // 
            this.listBox_friendsList.FormattingEnabled = true;
            this.listBox_friendsList.ItemHeight = 16;
            this.listBox_friendsList.Location = new System.Drawing.Point(315, 155);
            this.listBox_friendsList.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_friendsList.Name = "listBox_friendsList";
            this.listBox_friendsList.Size = new System.Drawing.Size(159, 228);
            this.listBox_friendsList.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Friends List";
            // 
            // listBox_friendRequests
            // 
            this.listBox_friendRequests.FormattingEnabled = true;
            this.listBox_friendRequests.ItemHeight = 16;
            this.listBox_friendRequests.Location = new System.Drawing.Point(31, 155);
            this.listBox_friendRequests.Name = "listBox_friendRequests";
            this.listBox_friendRequests.Size = new System.Drawing.Size(162, 228);
            this.listBox_friendRequests.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Friend Requests";
            // 
            // button_accept
            // 
            this.button_accept.Location = new System.Drawing.Point(31, 389);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(75, 30);
            this.button_accept.TabIndex = 22;
            this.button_accept.Text = "Accept";
            this.button_accept.UseVisualStyleBackColor = true;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // button_reject
            // 
            this.button_reject.Location = new System.Drawing.Point(116, 389);
            this.button_reject.Name = "button_reject";
            this.button_reject.Size = new System.Drawing.Size(75, 30);
            this.button_reject.TabIndex = 23;
            this.button_reject.Text = "Reject";
            this.button_reject.UseVisualStyleBackColor = true;
            this.button_reject.Click += new System.EventHandler(this.button_reject_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 473);
            this.Controls.Add(this.button_reject);
            this.Controls.Add(this.button_accept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox_friendRequests);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox_friendsList);
            this.Controls.Add(this.btnMyFriends);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button btnMyFriends;
        private System.Windows.Forms.ListBox listBox_friendsList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_friendRequests;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.Button button_reject;
    }
}

