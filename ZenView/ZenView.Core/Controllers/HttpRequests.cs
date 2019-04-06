using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using ZenView.Core.Interfaces;
using ZenView.Core.Internals;
using ZenView.Core.Models;
using ZenView.Core.Models.ClientConfigModels;

namespace ZenView.Core.Controllers
{
    internal class HttpRequests : IHttpRequests
    {
        private readonly Client _client;
        public HttpRequests()
        {
            _client = new Client();
        }

        public Tickets GetAllTickets()
        {
            var config = CreateConfig("https://zenview.zendesk.com/api/v2/tickets/recent.json");
            var result = _client.GetRequestAsync(config, "");
            return new JavaScriptSerializer().Deserialize<Tickets>(result.Result);
        }

        public static ClientConfig CreateConfig(string url)
        {
            var model = new ClientConfig(url);
            model.ProtocolType = System.Net.SecurityProtocolType.SystemDefault;
            return model;
        }

        public List<User> GetAllUsers()
        {
            var config = CreateConfig("https://zenview.zendesk.com/api/v2/users.json");
            var result = _client.GetRequestAsync(config, "");
            var model = new JavaScriptSerializer().Deserialize<ZendeskRootObject>(result.Result);
            return model.users;
        }

        public List<User> GetAllAgents()
        {
            return GetAllUsers().Where(x => x.role == "agent").ToList();
        }
    }
}