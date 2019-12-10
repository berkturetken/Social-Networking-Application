using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace CS408_Project_Server
{
    public partial class Form1 : Form
    {
        string nameCode = "0";
        char broadcastMessageCode = '1';
        char addFriendCode = '2';
        char notificationCode = '3';
        char updateRequests = '4';
        char getNotification = '5';
        char getRequests = '6';
        char getFriends = '7';
        char updateFriends = '8';
        char deletedCode = '9';
        char privateMessageCode = '*';
        char getPrivateMessagesCode = '#';

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        Dictionary<Socket, string> connectedUsers = new Dictionary<Socket, string>();
        List<Client> userList = new List<Client>();

        bool terminating = false;
        bool listening = false;

        private Client findClientByName(string name)
        {
            foreach (Client client in userList)
            {
                if (client.name == name)
                    return client;
            }
            return null;
        }

        private Client findClientBySocket(Socket socket)
        {
            foreach (Client client in userList)
            {
                if (client.socket == socket)
                    return client;
            }
            return null;
        }


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

                        Client newClient = new Client(line);
                        userList.Add(newClient);
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
        private void NameCheck(Socket thisClient, string incomingMessage)
        {


            string username = incomingMessage;

            //If the username is in the database, then send a "Successful" message to the client, 
            //add the user to the connectedUsers dictionary, log as "connected", and 
            //ready to transfer his/her message to other clients.
            if (findClientByName(username) != null && !connectedUsers.ContainsValue(username))
            {
                string message = "Successful" + "(end)";
                Byte[] buffer2 = new Byte[128];
                buffer2 = Encoding.Default.GetBytes(message);
                thisClient.Send(buffer2);
                connectedUsers.Add(thisClient, username);
                findClientByName(username).socket = thisClient;


                logs.AppendText(username + " is connected.\n");
            }

            //If the username is already in the database or not in the database, 
            //then send a "NotSuccessful" message to the client,
            //remove from the clientSockets and log appropriate messages whether
            //the client is already connected or not in the database
            else
            {
                string message = "NotSuccessful" + "(end)";
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

            List<string> requests = findClientBySocket(thisClient).GetFriendRequests();
            int i = 0;


            foreach (string request in requests)
            {
                string requestWithCode;

                requestWithCode = getRequests + request + "(end)";

                Byte[] requestBuffer = new Byte[64];
                requestBuffer = Encoding.Default.GetBytes(requestWithCode);
                thisClient.Send(requestBuffer);
                i++;
            }

            logs.AppendText("Relayed friend requests to " + connectedUsers[thisClient] + "\n");
        }

        private void sendFriends(Socket thisClient,bool isDeleted= false)
        {
            List<string> myFriends = findClientBySocket(thisClient).GetFriends();
            


            foreach (string friend in myFriends)
            {
                string requestWithCode;

                requestWithCode = getFriends + friend + "(end)";

                Byte[] requestBuffer = new Byte[64];
                requestBuffer = Encoding.Default.GetBytes(requestWithCode);
                thisClient.Send(requestBuffer);
                
            }



            logs.AppendText("Relayed friends list to " + connectedUsers[thisClient] + "\n");


        }

        private void sendPrivateMessages(Socket thisClient)
        {
            List<string> messages = findClientBySocket(thisClient).GetPrivateMessages();



            foreach (string message in messages)
            {
                string requestWithCode;

                requestWithCode = notificationCode + message ;

                Byte[] requestBuffer = new Byte[64];
                requestBuffer = Encoding.Default.GetBytes(requestWithCode);
                thisClient.Send(requestBuffer);

            }



            logs.AppendText("Relayed private Messages to " + connectedUsers[thisClient] + "\n");


        }


        private void sendNotifications(Socket thisClient)
        {
            List<string> notifications = findClientBySocket(thisClient).GetNotifications();

            foreach (string notification in notifications)
            {
                string requestWithCode = notificationCode + notification;
                Byte[] requestBuffer = new Byte[64];
                requestBuffer = Encoding.Default.GetBytes(requestWithCode);
                thisClient.Send(requestBuffer);
            }
            findClientBySocket(thisClient).DeleteAllNotifications();
            logs.AppendText("Relayed notification list to " + connectedUsers[thisClient] + "\n");
        }


        private void privateMessage(Socket thisClient, string incomingMessage)
        {
            string outgoingMessage = connectedUsers[thisClient] + "(Private): " + incomingMessage + "(end)";
            Byte[] Outgoingbuffer = new Byte[128];
            outgoingMessage = privateMessageCode + outgoingMessage;
            Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);

            logs.AppendText("Recieved a message from " + connectedUsers[thisClient] + " \n");

            List<string> friendsList = findClientBySocket(thisClient).GetFriends();

            foreach (string client in friendsList )
            {
                if (connectedUsers.ContainsValue(client))
                {
                    findClientByName(client).socket.Send(Outgoingbuffer);
                }
                else
                {
                    findClientByName(client).AddPrivateMessage(outgoingMessage.Substring(1));
                }
            }

            //The server still sends the message although there is only one user 

        }

        private void BroadCastMessage(Socket thisClient, string incomingMessage)
        {
            string outgoingMessage = connectedUsers[thisClient] + ": " + incomingMessage + "(end)";
            Byte[] Outgoingbuffer = new Byte[128];
            outgoingMessage = broadcastMessageCode + outgoingMessage;
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

        private void AddFriend(Socket thisClient, string reciever)
        {
            Client recieverClient = findClientByName(reciever);
            Client senderClient = findClientBySocket(thisClient);
            if (recieverClient != null)
            {
                if (!senderClient.GetFriendRequests().Contains(recieverClient.name) && !senderClient.GetPendingFriendRequests().Contains(recieverClient.name))
                {
                    if (!senderClient.GetFriends().Contains(recieverClient.name))
                    {
                        //Update Client's requestlists 
                        findClientBySocket(thisClient).AddPendingFriendRequest(reciever);
                        findClientByName(reciever).AddFriendRequest(senderClient.name);


                        //if the reciever is online send the updated requests list and notification
                        if (connectedUsers.ContainsValue(reciever))
                        {
                            sendRequest(findClientByName(reciever).socket);

                            string notification = notificationCode + "Received a new friend request from " + connectedUsers[thisClient] + "(end)";
                            Byte[] notificationBuffer = new Byte[64];
                            notificationBuffer = Encoding.Default.GetBytes(notification);

                            foreach (Socket client in connectedUsers.Keys)
                            {

                                if (connectedUsers[client] == reciever)
                                    client.Send(notificationBuffer);
                            }

                            logs.AppendText("Friend Request from " + connectedUsers[thisClient] + " to " + reciever + " sent.\n");
                        }
                        //store the request and notification
                        else
                        {
                            logs.AppendText("Friend Request from " + connectedUsers[thisClient] + " to " + reciever + " stored.\n");

                            findClientByName(reciever).AddNotification("Received a new friend request from " + connectedUsers[thisClient] + "(end)");
                        }



                        //notification for sender
                        string outgoingMessage = notificationCode + "Sent a new friend request to " + reciever + "(end)";
                        Byte[] Outgoingbuffer = new Byte[128];
                        Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);
                        thisClient.Send(Outgoingbuffer);
                    }
                    else
                    {
                        string outgoingMessage = notificationCode + "You are already friends with " + recieverClient.name + "(end)";
                        Byte[] Outgoingbuffer = new Byte[128];
                        Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);
                        thisClient.Send(Outgoingbuffer);
                    }

                }

                else
                {
                    string outgoingMessage = notificationCode + "You have already a request waiting!" + "(end)";
                    Byte[] Outgoingbuffer = new Byte[128];
                    Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);
                    thisClient.Send(Outgoingbuffer);
                }

            }
            else
            {
                string outgoingMessage = notificationCode + "The name is not in database!" + "(end)";
                Byte[] Outgoingbuffer = new Byte[128];
                Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);
                thisClient.Send(Outgoingbuffer);
            }

        }

        private void NotificationStatus(Socket thisClient, string reciever, string status)
        {

            Socket recieverSocket = findClientByName(reciever).socket;
            if (connectedUsers.ContainsValue(reciever))
            {

                Byte[] Outgoingbuffer = new Byte[128];
                if (status == "ACCEPTED")
                {
                    string outgoingMessage = notificationCode + connectedUsers[thisClient] + " accepted your friend request." + "(end)";    //this is not a broadcasting...

                    Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);

                    findClientBySocket(thisClient).DeleteFriendRequest(reciever);
                    findClientBySocket(thisClient).AddFriend(reciever);
                    findClientByName(reciever).AddFriend(connectedUsers[thisClient]);
                    findClientByName(reciever).DeletePendingFriendRequest(connectedUsers[thisClient]);


                    sendFriends(recieverSocket);
                    sendRequest(recieverSocket);
                    logs.AppendText("acceptance from " + connectedUsers[thisClient] + " to " + reciever + " sent.\n");


                }
                else if (status == "DELETEDD")
                {
                    string outgoingMessage = notificationCode + connectedUsers[thisClient] + " deleted you from friends list" + "(end)";    //this is not a broadcasting...

                    Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);


                    findClientBySocket(thisClient).DeleteFriend(reciever);
                    findClientByName(reciever).DeleteFriend(connectedUsers[thisClient]);

                    string deletedFriend = deletedCode + connectedUsers[thisClient] + "(end)";

                    Byte[] deletedFriendBuffer = new Byte[128];
                    deletedFriendBuffer = Encoding.Default.GetBytes(deletedFriend);


                    recieverSocket.Send(deletedFriendBuffer);
                    //sendFriends(recieverSocket);
                    logs.AppendText("Deletion from " + connectedUsers[thisClient] + " sent to " + reciever + ".\n");
                }
                else
                {
                    string outgoingMessage = notificationCode + connectedUsers[thisClient] + " rejected your friend request." + "(end)";    //this is not a broadcasting...

                    Outgoingbuffer = Encoding.Default.GetBytes(outgoingMessage);

                    logs.AppendText("rejection from " + connectedUsers[thisClient] + " to " + reciever + " sent.\n");
                    findClientBySocket(thisClient).DeleteFriendRequest(reciever);
                    findClientByName(reciever).DeletePendingFriendRequest(connectedUsers[thisClient]);

                }

                recieverSocket.Send(Outgoingbuffer);

            }
            else
            {

                if (status == "ACCEPTED")
                {
                    logs.AppendText("acceptance from " + connectedUsers[thisClient] + " to " + reciever + " stored.\n");

                    findClientBySocket(thisClient).DeleteFriendRequest(reciever);
                    findClientBySocket(thisClient).AddFriend(reciever);
                    findClientByName(reciever).AddFriend(connectedUsers[thisClient]);
                    findClientByName(reciever).DeletePendingFriendRequest(connectedUsers[thisClient]);
                    findClientByName(reciever).AddNotification(connectedUsers[thisClient] + " accepted your friend request." + "(end)");
                }
                else if (status == "DELETEDD")
                {



                    findClientBySocket(thisClient).DeleteFriend(reciever);
                    findClientByName(reciever).DeleteFriend(connectedUsers[thisClient]);

                    findClientByName(reciever).AddNotification(connectedUsers[thisClient] + " deleted you from friends list" + "(end)");


                    logs.AppendText("Deletion from " + connectedUsers[thisClient] + " to " + reciever + "stored.\n");
                }
                else
                {
                    logs.AppendText("rejection from " + connectedUsers[thisClient] + " to " + reciever + " stored.\n");
                    findClientBySocket(thisClient).DeleteFriendRequest(reciever);
                    findClientByName(reciever).DeletePendingFriendRequest(connectedUsers[thisClient]);
                    findClientByName(reciever).AddNotification(connectedUsers[thisClient] + " rejected your friend request." + "(end)");
                }
            }
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


                    while (incomingMessage.IndexOf("(end)") > 0)
                    {

                        string message = incomingMessage.Substring(0, incomingMessage.IndexOf("(end)"));
                        incomingMessage = incomingMessage.Substring(incomingMessage.IndexOf("(end)") + 5);
                        char RequestCode = message[0];
                        message = message.Substring(1);


                        if (RequestCode == nameCode[0]) //name control
                        {
                            NameCheck(thisClient, message);
                        }
                        else if (RequestCode == broadcastMessageCode) //msg broadcast
                        {
                            BroadCastMessage(thisClient, message);
                        }
                        else if (RequestCode == addFriendCode) // friend request
                        {
                            AddFriend(thisClient, message);
                        }
                        else if (RequestCode == notificationCode)
                        {
                            string reciever = message.Substring(8);
                            string status = message.Substring(0, 8);

                            NotificationStatus(thisClient, reciever, status);

                        }
                        else if (RequestCode == updateRequests)

                            sendRequest(thisClient);
                        else if (RequestCode == getNotification)
                        {
                            sendNotifications(thisClient);
                        }

                        else if (RequestCode == updateFriends)
                            sendFriends(thisClient);
                        else if (RequestCode == privateMessageCode)
                        {
                            privateMessage(thisClient,message);
                        }
                        else if (RequestCode == getPrivateMessagesCode)
                        {
                            sendPrivateMessages(thisClient);
                        }
                        else
                        {
                            logs.AppendText("Error...");
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
                        string outgoingMessage = connectedUsers[thisClient] + " has disconnected" + "(end)";
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
                    findClientBySocket(thisClient).connected = false;
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
