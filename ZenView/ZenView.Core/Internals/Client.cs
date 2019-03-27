using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using ZenView.Core.Controllers;
using ZenView.Core.Models.ClientConfigModels;

namespace ZenView.Core.Internals
{
    internal class Client
    {
        private readonly AccessTokenModel _accessToken;
        public Client()
        {
            _accessToken = AuthorizeClient();
        }

        internal Task<string> PostRequestAsync<T>(ClientConfig config, T model)
        {
            Task<string> result = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    SetSecurityProtocol(config.ProtocolType);

                    var jsonContent = JsonConvert.SerializeObject(model);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    AddCustomHeaders(client, config.CustomHeaders);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_accessToken.token_type, _accessToken.access_token);
                    var byteContent = CreateBinaryContent(jsonContent);

                    Task<HttpResponseMessage> response = client.PostAsync(config._targetUri, byteContent);
                    response.Result.EnsureSuccessStatusCode();

                    result = response.Result.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
            return result;
        }

        internal Task<string> GetRequestAsync(ClientConfig config,string querystring)
        {
            Task<string> result = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    SetSecurityProtocol(config.ProtocolType);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_accessToken.token_type, _accessToken.access_token);
                    var builder = new UriBuilder(config._targetUri);
                    builder.Query = querystring;
                    Task<HttpResponseMessage> response = client.GetAsync(builder.ToString());
                    response.Result.EnsureSuccessStatusCode();

                    result = response.Result.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
            return result;
        }

        internal Task<string> PostAuthorizeAsync<T>(ClientConfig config, T model)
        {
            Task<string> result = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    SetSecurityProtocol(config.ProtocolType);

                    var jsonContent = JsonConvert.SerializeObject(model);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var byteContent = CreateBinaryContent(jsonContent);

                    Task<HttpResponseMessage> response = client.PostAsync(config._targetUri, byteContent);
                    response.Result.EnsureSuccessStatusCode();

                    result = response.Result.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }
            }
            return result;
        }

        private void SetSecurityProtocol(SecurityProtocolType protocol)
        {
            if (protocol != 0)
            {
                ServicePointManager.SecurityProtocol = protocol;
            }
        }

        private void AddCustomHeaders(HttpClient client, Dictionary<string, string> headers)
        {
            if (headers.Count > 0)
            {
                try
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                catch
                {
                    //May not be neccessary
                }

            }
        }

        private ByteArrayContent CreateBinaryContent(string jsonContent)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }

        private AccessTokenModel AuthorizeClient()
        {
            var config = HttpRequests.CreateConfig("https://zenview.zendesk.com/oauth/tokens");
            var result = PostAuthorizeAsync<OauthGetAccessTokenModel>(config, CreateAccessToken());
            return new JavaScriptSerializer().Deserialize<AccessTokenModel>(result.Result);
        }

        private OauthGetAccessTokenModel CreateAccessToken()
        {
            var model = new OauthGetAccessTokenModel
            {
                grant_type = "password",
                client_id = ConfigurationManager.AppSettings["ZendeskClientId"],
                client_secret = ConfigurationManager.AppSettings["ZendeskClientSecret"],
                scope = "read",
                username = ConfigurationManager.AppSettings["ZendeskUser"],
                password = ConfigurationManager.AppSettings["ZendeskPassword"]
            };

            return model;
        }
    }
}