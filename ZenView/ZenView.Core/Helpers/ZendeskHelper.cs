using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZenView.Core.Controllers;
using ZenView.Core.Internals;
using ZenView.Core.Models;
using ZenView.Core.Models.ClientConfigModels;

namespace ZenView.Core.Helpers
{
    public class ZendeskHelper
    {
        private HttpRequests _request;
        public ZendeskHelper()
        {
            _request = new HttpRequests();

        }

        public Tickets GetTicktets()
        {
            var result = _request.GetAllTickets();
            return result;
        }

        public List<User> GetAgents()
        {
            var result = _request.GetAllAgents();
            return result;
        }

        public void InitLogin(string code)
        {
            _request.InitializeLogin(code);
        }
    }
}