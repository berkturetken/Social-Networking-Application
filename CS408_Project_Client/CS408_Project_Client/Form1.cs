using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace CS408_Project_Client
{
    public partial class Form1 : Form
    {

        bool terminating = false;
        bool connected = false;

        Socket serverSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();

            //Prevent to click on the "Send" button and write the logs console
            button_send.Enabled = false;
            logs.ReadOnly = true;
        }

        //Building the TCP connection 
        private void button_connect_Click(object sender, EventArgs e)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string userName = textBox_name.Text;
            string IP = textBox_ip.Text;
            int portNum;

            if (Int32.TryParse(textBox_port.Text, out portNum))
            {
                try
                {
                    //Without entering an IP, we can still connect to the server. What is the reason?
                    serverSocket.Connect(IP, portNum);
                    connected = true;

                    Thread sendUserName = new Thread(send_name);
                    sendUserName.Start();

                    Thread receiveApproval = new Thread(RecieveApproval);
                    receiveApproval.Start();
                }
                catch
                {
                    logs.AppendText("Could not connect to the server!\n");
                }
            }
            else
                logs.AppendText("Check the port!\n");
        }

        //Getting an authentication from the server
        private void RecieveApproval()
        {
            try
            {
                Byte[] buffer = new Byte[64];
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
                    logs.AppendText("Connected to the server!\n");

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
                    logs.AppendText("Server has disconnected\n");
                    connected = false;
                }
                serverSocket.Close();
            }
        }

        //Receiving messages from other clients by over the server
        private void recieve()
        {
            while (connected && !terminating)
            {
                try
                {
                    Byte[] Incomingbuffer = new Byte[64];
                    serverSocket.Receive(Incomingbuffer);

                    string incomingMessage = Encoding.Default.GetString(Incomingbuffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    logs.AppendText(incomingMessage);
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
                        logs.AppendText("Server has disconnected\n");
                    }
                    serverSocket.Close();
                    connected = false;
                }
            }
        }
        
        //Sending name to be checked by the server
        private void send_name()
        {
            string username = textBox_name.Text;

            if (username != "" && username.Length <= 64)
            {
                Byte[] buffer = new Byte[64];
                buffer = Encoding.Default.GetBytes(username);
                serverSocket.Send(buffer);
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string message = textBox_message.Text;

            //For simplicity, the length of the message should be smaller than 64 characters
            //serverSocket should be connected to proceed...
            if (message != "" && message.Length <= 64 && serverSocket.Connected)
            {
                logs.AppendText("Me:" + message + "\n");
                Byte[] buffer = new Byte[64];
                buffer = Encoding.Default.GetBytes(message);
                serverSocket.Send(buffer);
                textBox_message.Clear();        //Clearing the textbox for the new usage
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

                button_send.Enabled = false;
                serverSocket.Close();
            }
            catch
            {

            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            terminating = true;
            connected = false;
            Environment.Exit(0);    //Exit safely...
        }
    }
}
