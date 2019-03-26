using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using ZenView.Core.Models.ClientConfigModels;

namespace ZenView.Core.Internals
{
    internal class Client
    {
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
                    client.DefaultRequestHeaders.Authorization = null;
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
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("jhonnyhultkar@gmail.com")
                    SetSecurityProtocol(config.ProtocolType);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            //Add content type headers to the package itself
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}