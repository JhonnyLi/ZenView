using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ZenView.SignalR
{
    public class TheHub : Hub
    {
        public void Connected(string userName)
        {
            Clients.All.online(DateTime.Now.TimeOfDay.ToString());
        }

        public void Send(string user, string message)
        {
            Clients.All.broadcast(user, message);
        }

        public void SendToUser(string user, string message)
        {
            Clients.User(user).message(user, message);
        }
    }
}