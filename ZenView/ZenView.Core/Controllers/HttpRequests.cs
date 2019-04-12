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

        public void InitializeLogin(string code)
        {
            //https://{subdomain}https://zenview.zendesk.com/oauth/authorizations/new?response_type=code&redirect_uri={your_redirect_url}&client_id={your_unique_identifier}&scope=read%20write
            var config = CreateConfig("https://zenview.zendesk.com/oauth/tokens");
            var result = _client.PostAuthorizeAsync<OauthGetAccessTokenModel>(config, CreateAccessToken(code));
            var token = new JavaScriptSerializer().Deserialize<AccessTokenModel>(result.Result);
            //var result = _client.PostAuthorizeAsync(config, $"grant_type=authorization_code&code={code}&client_id=zenview-dev&client_secret=10ed46af35e864e77e8e3ace0a02aee7e31677ffddccdc94f4a811abf47b8b28&redirect_uri=http://localhost:56871/Account/ZendeskLoginCallback&scope=read");
            //?response_type=code&redirect_uri=zenview.azurewebsites.net/Account/ZendeskLoginCallback&client_id=zenview-dev&scope=read
            //http://localhost:56871/Account/ZendeskLoginCallback
        }

        private OauthGetAccessTokenModel CreateAccessToken(string code)
        {
            var model = new OauthGetAccessTokenModel
            {
                grant_type = "authorization_code",
                code=code,
                client_id = "zenview-dev",
                client_secret = "10ed46af35e864e77e8e3ace0a02aee7e31677ffddccdc94f4a811abf47b8b28",
                scope = "read",
            };

            return model;
        }
    }
}