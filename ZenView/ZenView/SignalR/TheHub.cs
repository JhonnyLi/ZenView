using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ZenView.Web.Classes.SignalR
{
    public class TheHub : Hub
    {
        private static Dictionary<Guid, string> _users = new Dictionary<Guid, string>();
        public void Connected(Guid userId, string user)
        {
            _users.Add(userId, user);
            ZenView.Core.Helpers.ZendeskHelper helper = new Core.Helpers.ZendeskHelper();
            var tickets = helper.GetTicktets();
            Clients.All.online("User connected at: " + DateTime.Now.TimeOfDay.ToString(),tickets);
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