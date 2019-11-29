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

        string messageCode = "1";
        string addFriendCode = "2";
        string notificationCode = "3";

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        Dictionary<Socket, string> connectedUsers = new Dictionary<Socket, string>();
        List<string> userDatabase = new List<string>();
        Dictionary<string, List<string>> friendRequests = new Dictionary<string, List<string>>();

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
                
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        List<string> requests = new List<string>();
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

                    Thread RecieveThread = new Thread(Recieve);
                    RecieveThread.Start();
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
        private void ReceiveName(Socket thisClient, string incomingMessage)
        {
            //  Byte[] buffer = new Byte[128];
            // thisClient.Receive(buffer);

            // string username = Encoding.Default.GetString(buffer);
            // username = username.Substring(0, username.IndexOf("\0"));

            string username = incomingMessage;

            //If the username is in the database, then send a "Successful" message to the client, 
            //add the user to the connectedUsers dictionary, log as "connected", and 
            //ready to transfer his/her message to other clients.
            if (userDatabase.Contains(username) && !connectedUsers.ContainsValue(username))
            {
                string message = "Successful";
                Byte[] buffer2 = new Byte[128];
                buffer2 = Encoding.Default.GetBytes(message);
                thisClient.Send(buffer2);
                connectedUsers.Add(thisClient, username);



                logs.AppendText(username + " is connected.\n");
            }

            //If the username is already in the database or not in the database, 
            //then send a "NotSuccessful" message to the client,
            //remove from the clientSockets and log appropriate messages whether
            //the client is already connected or not in the database
            else
            {
                string message = "NotSuccessful";
                Byte[] buffer2 = new Byte[128];
                buffer2 = Encoding.Default.GetBytes(message);
                thisClient.Send(buffer2);
                clientSockets.Remove(thisClient);

                //Differentiate the outputs of "already connected" case and "not in database" case...
                if (!connectedUsers.ContainsValue(username))
                    logs.AppendText("There is no such a person! \n");
                else
                    logs.AppendText(username + " is already connected! \n");
            }
        }

        private void sendRequest(Socket thisClient)
        {
            foreach (string user in friendRequests.Keys)
            {
                if (user == connectedUsers[thisClient])
                {
                    foreach (string request in friendRequests[user])
                    {
                        string requestWithCode = addFriendCode + request;
                        Byte[] requestBuffer = new Byte[64];
                        requestBuffer = Encoding.Default.GetBytes(requestWithCode);
                        thisClient.Send(requestBuffer);
                        
                    }
                    friendRequests[user].RemoveRange(0,friendRequests[user].Count);
                }
            }

            logs.AppendText("Relayed friend requests to " + connectedUsers[thisClient]+"\n");
        }

        private void RecieveMessage(Socket thisClient, string incomingMessage)
        {
            string outgoingMessage = connectedUsers[thisClient] + ": " + incomingMessage + "\n";
            Byte[] Outgoingbuffer = new Byte[128];
            outgoingMessage = messageCode + outgoingMessage;
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

        //Recieving meesages from clients
        private void Recieve()
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

                    if (RequestCode == '0') //name control
                    {
                        ReceiveName(thisClient, incomingMessage);
                    }
                    else if (RequestCode == '1') //msg broadcast
                    {
                        RecieveMessage(thisClient, incomingMessage);
                    }
                    else if (RequestCode == '2') // friend request
                    {
                        if (userDatabase.Contains(incomingMessage))
                        {
                            if (connectedUsers.ContainsValue(incomingMessage))
                            {
                                //RecieveFriendRequest(thisClient, incomingMessage);
                                string requestWithCode = RequestCode + connectedUsers[thisClient];
                                Byte[] requestBuffer = new Byte[64];
                                requestBuffer = Encoding.Default.GetBytes(requestWithCode);

                                foreach (Socket client in connectedUsers.Keys)
                                {

                                    if (connectedUsers[client] == incomingMessage)
                                        client.Send(requestBuffer);
                                }

                                logs.AppendText("Friend Request from " + connectedUsers[thisClient] + " to " + incomingMessage + " sent.\n");
                            }
                            else
                            {
                                logs.AppendText("Friend Request from " + connectedUsers[thisClient] + " to " + incomingMessage + " stored.\n");
                                friendRequests[incomingMessage].Add(connectedUsers[thisClient]);// disarida normalde

                            }

                          
                           


                            string outgoingMessage = notificationCode + "Sent a new friend request to " + incomingMessage + "\n";
                            Byte[] Outgoingbuffer = new Byte[128];
                            Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);
                            thisClient.Send(Outgoingbuffer);

                            /* --- NOT WORKING ---
                            List<string> dummy = new List<string>();
                            dummy = friendRequests[incomingMessage];
                            dummy.Add(connectedUsers[thisClient]);
                            friendRequests[incomingMessage] = dummy;
                            */
                            /*
                            List<string> dummy = new List<string>();
                            dummy = friendRequests[incomingMessage];
                            */
                           
                            
                        }
                        else
                        {
                            string outgoingMessage = notificationCode + "The name is not in database! \n";          //this is not a broadcasting...
                            Byte[] Outgoingbuffer = new Byte[128];
                            Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);
                            thisClient.Send(Outgoingbuffer);
                        }
                    }
                    else if (RequestCode == '3')
                    {
                        string acceptedFriend = incomingMessage.Substring(8);
                        incomingMessage = incomingMessage.Substring(0, 8);

                        string outgoingMessage = notificationCode + incomingMessage + connectedUsers[thisClient];          //this is not a broadcasting...
                        Byte[] Outgoingbuffer = new Byte[128];
                        Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);

                        friendRequests[connectedUsers[thisClient]].Remove(acceptedFriend);

                        foreach (Socket client in connectedUsers.Keys)
                        {
                            if (connectedUsers[client] == acceptedFriend)
                            {
                                client.Send(Outgoingbuffer);
                            }
                        }

                    }
                    else if (RequestCode == '4')
                    {
                        sendRequest(thisClient);
                    }
                    else
                    {
                        logs.AppendText("Error...");
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
