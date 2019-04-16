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
        /// <summary>
        /// This is for matching a logged in user with a Zendesk Auth token.
        /// string userName, string zendeskAuthToken.
        /// After finding the user and matching it the user should be removed from this list.
        /// </summary>
        public static Dictionary<string, string> _usersThatLoggedOn = new Dictionary<string, string>();
        /// <summary>
        /// This list holds current active users and their auth tokens.
        /// </summary>
        private Dictionary<Guid, string> _activeUsers = new Dictionary<Guid, string>();
        public void Connected(Guid userId, string userName)
        {
            var user = _usersThatLoggedOn.FirstOrDefault(u => u.Key.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrEmpty(user.Key))
            {
                var vm = new ZenViewViewModel(user.Value);
                
                if (_usersThatLoggedOn.Remove(userName))
                {
                    if (!_activeUsers.Any(u=>u.Key.ToString().Equals(user.Key)))
                    {
                        _activeUsers.Add(userId, user.Value);
                    }
                    else
                    {
                        _activeUsers[userId] = user.Value;
                    }
                }
                Clients.Caller.receiveState(vm.Tickets, vm.Users);
            }
            Clients.All.online($"User {user.Key} connected at: " + DateTime.Now.TimeOfDay.ToString());
        }
        public void GetTickets(string token)
        {
            var vm = new ZenViewViewModel(token);
            Clients.Caller.receiveTickets(vm.Tickets);
        }

        public void GetWebHookTicket(string ticket)
        {
            Clients.All.receiveWebHookTicket(ticket);
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

/*
 Client-side target functions
 ******************************
 online - Needs better name
 receiveTickets - May need a better name
 receiveWebHookTicket - Needs a better name
 statusUpdate - May be good as it is...
     */
