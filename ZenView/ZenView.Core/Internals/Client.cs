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
using ZenView.Core.Models.ClientConfigModels;

namespace ZenView.Core.Internals
{
    internal class Client
    {
        private readonly AccessTokenModel _accessToken;
        public Client()
        {
            
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

        internal Task<string> GetRequestAsync(ClientConfig config,string querystring, AccessTokenModel token)
        {
            Task<string> result = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    SetSecurityProtocol(config.ProtocolType);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.token_type, token.access_token);
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
            //var accessToken = AuthorizeClient();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    SetSecurityProtocol(config.ProtocolType);

                    var jsonContent = JsonConvert.SerializeObject(model);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_accessToken.token_type, _accessToken.access_token);
                    var byteContent = CreateBinaryContent(jsonContent);

                    Task<HttpResponseMessage> response = client.PostAsync(config._targetUri, byteContent);
                    response.Result.EnsureSuccessStatusCode();

                    result = response.Result.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    throw new HttpRequestException($"Result-string: {result} " ,e);
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
                    throw;
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

        //private AccessTokenModel AuthorizeUser()
        //{
        //    var config = HttpRequests.CreateConfig("https://zenview.zendesk.com/oauth/authorizations/new");
        //    var result = GetRequestAsync(config, "response_type=code&redirect_uri=http://localhost:56871/Account/ZendeskLoginCallback&client_id=zenview-dev&scope=read");
        //    return new JavaScriptSerializer().Deserialize<AccessTokenModel>(result.Result);
        //}

        //private AccessTokenModel AuthorizeClient()
        //{
        //    var config = HttpRequests.CreateConfig("https://zenview.zendesk.com/oauth/tokens");
        //    var result = PostAuthorizeAsync<OauthGetAccessTokenModel>(config, CreateAccessToken(""));
        //    return new JavaScriptSerializer().Deserialize<AccessTokenModel>(result.Result);
        //}

        //internal static OauthGetAccessTokenModel CreateAccessToken()
        //{
        //    var model = new OauthGetAccessTokenModel
        //    {
        //        grant_type = "password",
        //        code = "",
        //        client_id = ConfigurationManager.AppSettings["ZendeskClientId"],
        //        client_secret = ConfigurationManager.AppSettings["ZendeskClientSecret"],
        //        redirect_uri = "",
        //        scope = "read",
        //    };

        //    return model;
        //}

        internal static OauthGetAccessTokenModel CreateAuthToken(string code)
        {
            var clientId = ConfigurationManager.AppSettings["ZendeskClientId"];
            var clientSecret = ConfigurationManager.AppSettings["ZendeskClientSecret"];
            var model = new OauthGetAccessTokenModel
            {
                grant_type = "authorization_code",
                code = code,
                client_id = clientId,
                client_secret = clientSecret,

                redirect_uri = ConfigurationManager.AppSettings["ZendeskRedirectUri"],
                scope = "read",
            };

            return model;
        }
        internal static AccessTokenModel GetAccessToken(string token)
        {
            var model = new AccessTokenModel();
            model.access_token = token;
            model.token_type = "Bearer";
            model.scope = "read";

            return model;
        }

        public static ClientConfig CreateConfig(string url)
        {
            var model = new ClientConfig(url);
            model.ProtocolType = System.Net.SecurityProtocolType.SystemDefault;
            return model;
        }

        //private OauthGetAccessTokenModel CreateAccessToken()
        //{
        //    var model = new OauthGetAccessTokenModel
        //    {
        //        grant_type = "password",
        //        client_id = ConfigurationManager.AppSettings["ZendeskClientId"],
        //        client_secret = ConfigurationManager.AppSettings["ZendeskClientSecret"],
        //        scope = "read",
        //        username = ConfigurationManager.AppSettings["ZendeskUser"],
        //        password = ConfigurationManager.AppSettings["ZendeskPassword"]
        //    };

        //        return model;
        //    }
    }
}