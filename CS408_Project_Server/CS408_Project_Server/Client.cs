using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CS408_Project_Server
{
     class Client
    {
        public Socket socket;
        public string name;
        private List<string> friends;
        private List<string> friendRequests;
        private List<string> pendingFriendRequests;
        private List<string> waitingNotifications;
        public bool connected;
        

        public Client(Socket socket = null, string name = null)
        {
            this.connected = false;
            this.socket = socket;
            this.name = name;
            this.friends = new List<string>();
            this.friendRequests = new List<string>();
            this.pendingFriendRequests = new List<string>();
            this.waitingNotifications = new List<string>();

        }

        public Client( string name = null)
        {
            this.connected = false;
            this.socket = null;
            this.name = name;
            friends = new List<string>();
            friendRequests = new List<string>();
            pendingFriendRequests = new List<string>();
            this.waitingNotifications = new List<string>();

        }

        public void AddFriend(string name)
        {
            this.friends.Add(name);
        }

        public void AddFriendRequest(string name)
        {
            this.friendRequests.Add(name);
        }
        public void AddNotification(string notification)
        {
            this.waitingNotifications.Add(notification);
        }
        public void AddPendingFriendRequest(string name)
        {
            this.pendingFriendRequests.Add(name);
        }

        public void DeleteFriendRequest(string name)
        {
            this.friendRequests.Remove(name);

        }

        public void DeletePendingFriendRequest(string name)
        {
            this.pendingFriendRequests.Remove(name);

        }
        public void DeleteAllNotifications()
        {
            this.waitingNotifications.RemoveRange(0,waitingNotifications.Count());

        }
        public List<String> GetFriendRequests()
        {
            return friendRequests;
        }

        public List<String> GetPendingFriendRequests()
        {
            return pendingFriendRequests;
        }

        public List<String> GetFriends()
        {
            return friends;
        }
        public List<String> GetNotifications()
        {
            return waitingNotifications;
        }
    }
}
