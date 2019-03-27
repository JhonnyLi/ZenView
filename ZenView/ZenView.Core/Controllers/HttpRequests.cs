using System;
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
        public void GetAgentsFromGroup(string group)
        {

            throw new NotImplementedException();
        }

        public void GetAllGroups()
        {
            throw new NotImplementedException();
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

    }
}