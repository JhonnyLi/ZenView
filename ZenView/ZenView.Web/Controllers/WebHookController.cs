using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZenView.Web.Classes.SignalR;
using ZenView.Web.Models;

namespace ZenView.Web.Controllers
{
    public class WebHookController : ApiController
    {
        private IHubContext _theHub;
        public WebHookController()
        {
            _theHub = GlobalHost.ConnectionManager.GetHubContext<TheHub>();
            
        }

        [HttpPost]
        public HttpResponseMessage ZenPost([FromBody]WebhookModel message)
        {
            var jsonContent = JsonConvert.SerializeObject(message);
            _theHub.Clients.All.receiveWebHookTicket(jsonContent);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage StatusGet(string Token, string Status, string StatusCode, string Url, string IP, string Name, string Tags, string CheckRate)
        {
            _theHub.Clients.All.statusUpdate(Name + ": " + Status + " [" + StatusCode + "] (" + Url + ")");
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage StatusPost([FromBody]string Token, string Status, string StatusCode, string Url, string IP, string Name, string Tags, string CheckRate)
        {
            _theHub.Clients.All.statusUpdate(Name + ": " + Status + " [" + StatusCode + "] (" + Url + ")");
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}