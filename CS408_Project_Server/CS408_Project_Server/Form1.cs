using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace CS408_Project_Server
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        Dictionary<Socket, string> connectedUsers = new Dictionary<Socket, string>();
        List<string> userDatabase = new List<string>();
        Dictionary<string,List<string>> friendRequests = new Dictionary<string, List<string>>();

        

        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            create_db();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();

            //Prevent to write the logs console
            logs.ReadOnly = true;
        }

        //Creating database for clients
        private void create_db()
        {
            try
            {
                //Get the current path of project in any local machine...
                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                //Get rid of the "bin/debug" part in path and add our database file (user_db.txt) to the path
                path = path.Substring(0, path.Length - 9) + "user_db.txt";
                List<string> requests = new List<string>();
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        userDatabase.Add(line);
                        friendRequests.Add(line, requests);
                    }
                        // here is up to you how to find the control to set and to assign the value.
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

            //Port numbers range from 0 to 65535! Not to get exception, added serverPort > -1
            if (Int32.TryParse(textBox_port.Text, out serverPort) && serverPort > -1)
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);         //why?

                //The server is getting ready to listen...
                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {
                logs.AppendText("Please check port number! \n");
            }
        }
        //Accepting Connections
        private void Accept()
        {
            while (listening)
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
                    if (terminating)
                        listening = false;
                    else
                        logs.AppendText("The socket stopped working.\n");
                }
            }
        }

        //Recieving a name from clients and checking if they are authorized to connect
        private void ReceiveName()
        {
            Socket thisClient = clientSockets[clientSockets.Count() - 1];

            try
            {
                Byte[] buffer = new Byte[128];
                thisClient.Receive(buffer);

                string username = Encoding.Default.GetString(buffer);
                username = username.Substring(0, username.IndexOf("\0"));

                //If the username is in the database, then send a "Successful" message to the client, 
                //add the user to the connectedUsers dictionary, log as "connected", and 
                //ready to transfer his/her message to other clients.
                if (userDatabase.Contains(username) && !connectedUsers.ContainsValue(username))
                {
                    string message = "Successful";
                    Byte[] buffer2 = new Byte[128];
                    buffer = Encoding.Default.GetBytes(message);
                    thisClient.Send(buffer);
                    connectedUsers.Add(thisClient, username);
                    logs.AppendText(username + " is connected.\n");
                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();
                }

                //If the username is already in the database or not in the database, 
                //then send a "NotSuccessful" message to the client,
                //remove from the clientSockets and log appropriate messages whether
                //the client is already connected or not in the database
                else
                {
                    string message = "NotSuccessful";
                    Byte[] buffer2 = new Byte[128];
                    buffer = Encoding.Default.GetBytes(message);
                    thisClient.Send(buffer);
                    clientSockets.Remove(thisClient);

                    //Differentiate the outputs of "already connected" case and "not in database" case...
                    if(!connectedUsers.ContainsValue(username))
                        logs.AppendText("There is no such a person! \n");
                    else
                        logs.AppendText(username + " is already connected! \n");
                }
            }
            catch
            {
                //Connection has lost...
                if (!terminating)
                    logs.AppendText("A client has disconnected! \n");

                thisClient.Close();
                clientSockets.Remove(thisClient);
            }
        }

        //Recieving meesages from clients
        private void Receive()
        {
            Socket thisClient = clientSockets[clientSockets.Count() - 1];
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    Byte[] Incomingbuffer = new Byte[128];
                    thisClient.Receive(Incomingbuffer);

                    string incomingMessage = Encoding.Default.GetString(Incomingbuffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    char RequestCode = incomingMessage[0];
                    incomingMessage = incomingMessage.Substring(1);

                    if (RequestCode == 0)
                    {
                        string outgoingMessage = connectedUsers[thisClient] + ": " + incomingMessage + "\n";
                        Byte[] Outgoingbuffer = new Byte[128];
                        Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);

                        logs.AppendText("Recieved a message from " + connectedUsers[thisClient] + " \n");

                        foreach (Socket client in connectedUsers.Keys)
                        {
                            if (client == thisClient)
                                continue;
                            client.Send(Outgoingbuffer);
                        }

                        //The server still sends the message although there is only one user 

                        if (connectedUsers.Count == 1)
                            logs.AppendText("No other user to send message in the server right now! \n");
                        else
                            logs.AppendText("Sent it to the other clients!\n");
                    }
                    else if (RequestCode == 1)
                    {
                        if (userDatabase.Contains(incomingMessage))
                        {
                            if (connectedUsers.ContainsValue(incomingMessage))
                            {
                                string outgoingMessage = "Recieved a new friend request from: "+ connectedUsers[thisClient];
                                Byte[] Outgoingbuffer = new Byte[128];
                                Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);

                                foreach (Socket client in connectedUsers.Keys)
                                {
                                    if (client == thisClient)
                                    {
                                        client.Send(Outgoingbuffer);
                                        break;
                                    }
                                }
                            }

                            friendRequests[incomingMessage].Add(connectedUsers[thisClient]);

                        }
                        else
                        {
                            string outgoingMessage = "The name is not in database\n";
                            Byte[] Outgoingbuffer = new Byte[128];
                            Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);
                            thisClient.Send(Outgoingbuffer);
                        }


                    }

                  
                }
                catch
                {
                    //Connection has lost...
                    if (!terminating)
                    {
                        logs.AppendText(connectedUsers[thisClient] + " has disconnected! \n");
                        
                        //If the client terminates the connection, the other clients have to understand the disconnection
                        string outgoingMessage = connectedUsers[thisClient] + " has disconnected\n";
                        Byte[] Outgoingbuffer = new Byte[128];
                        Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);

                        foreach (Socket client in connectedUsers.Keys)
                        {
                            if (client == thisClient)
                                continue;
                            client.Send(Outgoingbuffer);
                        }
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
            Environment.Exit(0);    //Exit safely...
        }
    }
}
