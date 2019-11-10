using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CS408_Project_Server
{

    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        Dictionary<Socket,string> connectedUsers = new Dictionary<Socket,string>();
        List<string> userDatabase = new List<string>();

        bool terminating = false;
        bool listening = false;
                                   

        public Form1()
        {
            create_db();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
            //logs.AppendText("Hey"); //For debugging purposes
        }
        //Creating database for clients
        private void create_db()
        {
            try
            {
                using (StreamReader reader = new StreamReader("C:\\Users\\MEHMET\\Desktop\\Klasörlerim\\CS408\\Proje Part1\\CS408_SocialNetworkingApplication\\CS408_Project_Server\\CS408_Project_Server\\user_db.txt"))
                {

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        userDatabase.Add(line);
                        // here is up to you how to find the control to set and to assign the value.
                    }
                }
            }
            catch
            {
                Console.WriteLine("Database can not be found!");
            }

        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            //Converts the string representation of a number to its 32-bit signed integer equivalent.
            //A return value indicates whether the operation succeeded.
            if (Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);     //why?

                //The server is getting ready to listen...
                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {
                logs.AppendText("Please check port number \n");
            }
        }
        //Accepting Connections
        private void Accept()
        {

            while(listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    clientSockets.Add(newClient);

                    Thread receiveName = new Thread(ReceiveName);
                    receiveName.Start();
                }
                catch
                {
                    if(terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }
                }
            }
        }
        //Recieving a name from clients and checking if they are authorized to connect
        private void ReceiveName()
        {
            Socket thisClient = clientSockets[clientSockets.Count() - 1];
            
                try
                {
                    Byte[] buffer = new Byte[64];
                    thisClient.Receive(buffer);

                    string username = Encoding.Default.GetString(buffer);
                    username = username.Substring(0, username.IndexOf("\0"));

                if(userDatabase.Contains(username)&& !connectedUsers.ContainsValue(username))
                {
                    string message = "Successful";
                    Byte[] buffer2 = new Byte[64];
                    buffer = Encoding.Default.GetBytes(message);
                    thisClient.Send(buffer);
                    connectedUsers.Add(thisClient, username);
                    logs.AppendText(username+" is connected.\n");
                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();
                }
                else
                {
                    string message = "NotSuccessful";
                    Byte[] buffer2 = new Byte[64];
                    buffer = Encoding.Default.GetBytes(message);
                    thisClient.Send(buffer);
                    clientSockets.Remove(thisClient);
                    logs.AppendText(username + " is already connected or not in database\n");

                }
                  

                }
                catch
                {
                    //Connection has lost...
                    if (!terminating)
                    {
                        logs.AppendText("A client has disconnected\n");
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                  
                }
            
        }
        //Recieving meesages from clients
        private void Receive()
        {
            Socket thisClient = clientSockets[clientSockets.Count() - 1];
            bool connected = true;

            while(connected && !terminating)
            {
                try
                {
                    Byte[] Incomingbuffer = new Byte[64];
                    thisClient.Receive(Incomingbuffer);

                    string incomingMessage = Encoding.Default.GetString(Incomingbuffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    string outgoingMessage = connectedUsers[thisClient] + ": " + incomingMessage + "\n";
                    Byte[] Outgoingbuffer = new Byte[64];
                    Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);
                    logs.AppendText("Recieved a message from " + connectedUsers[thisClient] + " \n");
                    
                    foreach (Socket client in connectedUsers.Keys) {
                        if (client == thisClient)
                            continue;
                        client.Send(Outgoingbuffer);

                    }

                    logs.AppendText("Sent it to the other clients!\n");



                }
                catch
                {
                    //Connection has lost...
                    if(!terminating)
                    {
                        logs.AppendText(connectedUsers[thisClient]+" has disconnected\n");
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connectedUsers.Remove(thisClient);
                    connected = false;
                }
            }
        }

   

        public void Form1_FormClosing(object Sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = false;
            Environment.Exit(0);    //exit safely
        }

    }
}
