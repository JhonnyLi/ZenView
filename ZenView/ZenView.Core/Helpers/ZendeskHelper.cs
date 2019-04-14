using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ZenView.Core.Interfaces;
using ZenView.Core.Internals;
using ZenView.Core.Models;
using ZenView.Core.Models.ClientConfigModels;
using System.Web.Script.Serialization;

namespace ZenView.Core.Helpers
{
    public class ZendeskHelper : IHttpRequests
    {
        private Client _client;
        public ZendeskHelper()
        {
            _client = new Client();

        }

        public Tickets GetAllTickets(string token)
        {
            var config = Client.CreateConfig("https://zenview.zendesk.com/api/v2/tickets.json");
            var result = _client.GetRequestAsync(config, "", Client.GetAccessToken(token));
            var tickets = new JavaScriptSerializer().Deserialize<Tickets>(result.Result);  //Maybe add where to remove all closed tickets.
            return tickets;

        }

        public List<User> GetAllUsers(string token)
        {
            var config = Client.CreateConfig("https://zenview.zendesk.com/api/v2/users.json");
            var result = _client.GetRequestAsync(config, "", Client.GetAccessToken(token));
            var model = new JavaScriptSerializer().Deserialize<ZendeskRootObject>(result.Result);
            return model.users.Where(x => x.role == "agent").ToList();
        }

        public AccessTokenModel GetAccessToken(string code)
        {
            var config = Client.CreateConfig("https://zenview.zendesk.com/oauth/tokens");
            var result = _client.PostAuthorizeAsync<OauthGetAccessTokenModel>(config, Client.CreateAuthToken(code));
            var token = new JavaScriptSerializer().Deserialize<AccessTokenModel>(result.Result);
            return token;
        }
    }
}