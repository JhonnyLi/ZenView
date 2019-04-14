using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using ZenView.Web.ViewModels;

namespace ZenView.Web.Classes.SignalR
{
    public class TheHub : Hub
    {
        private static Dictionary<Guid, string> _users = new Dictionary<Guid, string>();
        public void Connected(Guid userId, string user)
        {
            Clients.All.online("User connected at: " + DateTime.Now.TimeOfDay.ToString());
        }
        public void GetTickets(string token)
        {
            var vm = new ZenViewViewModel(token);
            Clients.Caller.receiveTickets(vm.Tickets);
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