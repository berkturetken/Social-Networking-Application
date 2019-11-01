using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS408_Project_Client
{
    public partial class Form1 : Form
    {

        bool terminating = false;
        bool connected = false;
        Socket clientSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string userName = textBox_name.Text; 
            string IP = textBox_ip.Text;
            int portNum;

            if (Int32.TryParse(textBox_port.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(userName, portNum);
                    //??? Without entering an IP, we can still connect to the server. What is the reason?
                    button_connect.Enabled = false;
                    textBox_message.Enabled = true;
                    button_send.Enabled = true;
                    connected = true;
                    logs.AppendText("Connected to the server!\n");

                    //Thread receiveThread = new Thread(Recieve);
                    //receiveThread.Start();
                }
                catch
                {
                    logs.AppendText("Could not connect to the server!\n");
                }
            }
            else
            {
                logs.AppendText("Check the port!\n");
            }
        }


        /*
        private void Recieve()
        {

        }
        */

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            terminating = true;
            connected = false;
            Environment.Exit(0);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            //logs.AppendText("Inside button_send_Click\n"); //for debugging purposes
            string message = textBox_message.Text;
            string userName = textBox_name.Text;

            //For simplicity, the length of the message should be smaller than 64 characters
            if (message != "" && message.Length <= 64)
            {
                //logs.AppendText("Sending the message...\n"); //for debugging purposes
                Byte[] buffer = new Byte[64];
                buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                logs.AppendText(userName + ": " + message + "\n");
                textBox_message.Clear();    //Clearing the textbox for the new usage
            }
        }
    }
}
