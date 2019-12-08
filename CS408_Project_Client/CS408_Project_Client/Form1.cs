using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CS408_Project_Client
{
    public partial class Form1 : Form
    {
        string nameCode = "0";
        char broadcastMessageCode = '1';
        char addFriendCode = '2';
        char notificationCode = '3';
        string updateLists = "4";
        string getNotification = "5";
        char getRequests = '6';
        char getFriends = '7';

        string username = "";

        bool terminating = false;
        bool connected = false;

        Socket serverSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();

            //INITIAL BUTTON SITUATIONS
            button_send.Enabled = false;
            logs.ReadOnly = true;
            button_addFriend.Enabled = false;
            button_accept.Enabled = false;
            button_reject.Enabled = false;

        }

        //Building the TCP connection 
        private void button_connect_Click(object sender, EventArgs e)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string userName = textBox_name.Text;
            string IP = textBox_ip.Text;
            int portNum;

            //Get the local IP Address
            string currIP = "";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    currIP = ip.ToString();                         //Since type of "ip" is System.Net.IPAddress, there must be conversions
            }

            //First, check the port (actually, we're only checking the conversion from string to integer!)
            if (Int32.TryParse(textBox_port.Text, out portNum))
            {
                //Second, check the IP address
                if (IP == currIP || IP == "")
                {
                    try
                    {
                        serverSocket.Connect(IP, portNum);
                        connected = true;

                        /* Thread sendUserName = new Thread(send_name);
                         sendUserName.Start();*/
                        send_name();

                        Thread receiveApproval = new Thread(RecieveApproval);
                        receiveApproval.Start();
                    }
                    catch
                    {
                        logs.AppendText("Could not connect to the server!\n");
                    }
                }
                else
                    logs.AppendText("Check your IP address!\n");
            }
            else
                logs.AppendText("Check the port!\n");
        }


        private void Update_lists()
        {
            Byte[] updateListsBuffer = new Byte[128];
            updateListsBuffer = Encoding.Default.GetBytes(updateLists);
            serverSocket.Send(updateListsBuffer);
        }
        private void Get_Notifications()
        {
            Byte[] getNotificationBuffer = new Byte[128];
            getNotificationBuffer = Encoding.Default.GetBytes(getNotification);
            serverSocket.Send(getNotificationBuffer);
        }

        //Getting an authentication from the server
        private void RecieveApproval()
        {
            try
            {
                Byte[] buffer = new Byte[128];
                serverSocket.Receive(buffer);

                string incomingMessage = Encoding.Default.GetString(buffer);
                incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                //If the client gets "NotSuccessful" message from the server side, this means
                //that the client is either already connected or not in the database
                if (incomingMessage == "NotSuccessful")
                {
                    logs.AppendText("You are already connected or not registered! \n");
                    serverSocket.Close();
                    connected = false;
                }

                //Otherwise, the client connects to the server successfully and 
                //arrange necessary GUI elements according to given specifications
                else
                {
                    button_connect.Enabled = false;
                    textBox_message.Enabled = true;
                    button_send.Enabled = true;
                    connected = true;
                    button_disconnect.Enabled = true;
                    button_addFriend.Enabled = true;
                    button_accept.Enabled = true;
                    button_reject.Enabled = true;

                    logs.AppendText("Connected to the server!\n");
                    Update_lists();
                    Get_Notifications();

                    Thread recieveThread = new Thread(recieve);
                    recieveThread.Start();
                }

            }
            catch
            {
                //Connection has lost... and
                //arrange necessary GUI elements according to given specifications
                if (!terminating)
                {
                    button_send.Enabled = false;
                    button_disconnect.Enabled = false;
                    button_connect.Enabled = true;
                    logs.AppendText("Disconnected from server\n");
                    connected = false;
                }
                serverSocket.Close();
            }
        }



        private void recieve()
        {
            while (connected && !terminating)
            {
                try
                {
                    Byte[] Incomingbuffer = new Byte[128];
                    serverSocket.Receive(Incomingbuffer);

                    string incomingMessage = Encoding.Default.GetString(Incomingbuffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    char RequestCode = incomingMessage[0];
                    incomingMessage = incomingMessage.Substring(1);

                    if (RequestCode == broadcastMessageCode)
                    {
                        logs.AppendText(incomingMessage);
                    }
                    else if (RequestCode == getNotification[0])
                    {
                        logs.AppendText(incomingMessage);
                    }
                    else if (RequestCode == getRequests)
                    {
                        listBox_friendRequests.Items.Clear();
                        if (incomingMessage != "")
                        {
                            string request = incomingMessage;
                            listBox_friendRequests.Items.Add(request);
                        }
                    }
                    else if (RequestCode == getFriends)
                    {
                        listBox_friendsList.Items.Clear();
                        if (incomingMessage != "")
                        {
                            string friend = incomingMessage;

                            listBox_friendsList.Items.Add(friend);
                        }
                    }

                }
                catch
                {
                    //Connection has lost...
                    //arrange necessary GUI elements according to given specifications
                    if (!terminating)
                    {
                        button_send.Enabled = false;
                        button_disconnect.Enabled = false;
                        button_connect.Enabled = true;
                        logs.AppendText("Disconnected from server\n");
                    }
                    serverSocket.Close();
                    connected = false;
                }
            }
        }

        //Sending name to be checked by the server
        private void send_name()
        {
            username = textBox_name.Text;
            string outgoingMessage = nameCode + username;

            if (username != "" && username.Length <= 64)
            {
                Byte[] buffer = new Byte[64];
                buffer = Encoding.Default.GetBytes(outgoingMessage);
                serverSocket.Send(buffer);
            }
        }



        private void button_send_Click(object sender, EventArgs e)
        {
            string message = textBox_message.Text;
            string outgoingMessage = broadcastMessageCode + message;

            //For simplicity, the length of the message should be smaller than 64 characters
            //serverSocket should be connected to proceed...
            if (serverSocket.Connected)
            {
                if (message != "" && message.Length <= 128)
                {
                    logs.AppendText(username + ": " + message + "\n");
                    Byte[] buffer = new Byte[128];
                    buffer = Encoding.Default.GetBytes(outgoingMessage);
                    serverSocket.Send(buffer);
                    textBox_message.Clear();        //Clearing the textbox for the new usage
                }
                else
                    logs.AppendText("Text must be less than or equal to 128 characters! \n");
            }
            else
                logs.AppendText("The connection has lost with the server! \n");
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            //Arrange necessary GUI elements according to given specifications and close the serverSocket
            try
            {
                connected = false;
                button_connect.Enabled = true;
                button_disconnect.Enabled = false;
                button_addFriend.Enabled = false;
                button_accept.Enabled = false;
                button_reject.Enabled = false;

                button_send.Enabled = false;
                serverSocket.Close();
            }
            catch
            {

            }
        }

        private void button__addFriend_Click(object sender, EventArgs e)
        {

            string friendName = textBox_friendName.Text;
            string goingFriendName = addFriendCode + friendName;

            if (serverSocket.Connected)
            {
                Byte[] buffer = new Byte[128];
                buffer = Encoding.Default.GetBytes(goingFriendName);
                serverSocket.Send(buffer);
                //logs.AppendText("Sent a new friend request to " + friendName.Substring(1) + "\n");
            }
            else
                logs.AppendText("The connection has lost with the server!AAA \n");


        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            terminating = true;
            connected = false;
            Environment.Exit(0);    //Exit safely...
        }

        private void sendNotification(string text)
        {
            text = notificationCode + text;
            Byte[] buffer = new Byte[128];
            buffer = Encoding.Default.GetBytes(text);
            serverSocket.Send(buffer);
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            string friend = listBox_friendRequests.GetItemText(listBox_friendRequests.SelectedItem);
            string notification = "ACCEPTED" + friend;
            logs.AppendText("You are now friends with " + friend + "\n");
            sendNotification(notification);
            Update_lists();
        }

        private void button_reject_Click(object sender, EventArgs e)
        {
            string friend = listBox_friendRequests.GetItemText(listBox_friendRequests.SelectedItem);

            string notification = "REJECTED" + friend;
            logs.AppendText("You rejected friend request from " + friend + "\n");

            sendNotification(notification);
            Update_lists();

        }
    }
}
