using Microsoft.AspNet.SignalR;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ZenView.Web.Classes.SignalR;

namespace ZenView.Web.Controllers
{
    public class WebHookController : Controller
    {
        private IHubContext _theHub;
        public WebHookController()
        {
            _theHub = GlobalHost.ConnectionManager.GetHubContext<TheHub>();
            
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage ZenGet(string message)
        {

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage ZenPost([FromBody]string message)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage StatusGet(string Token, string Status, string StatusCode, string Url, string IP, string Name, string Tags, string CheckRate)
        {
            _theHub.Clients.All.online(Name + ": " + Status + " [" + StatusCode + "] (" + Url + ")");
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage StatusPost([FromBody]string Token, string Status, string StatusCode, string Url, string IP, string Name, string Tags, string CheckRate)
        {
            _theHub.Clients.All.online(Name + ": " + Status + " [" + StatusCode + "] (" + Url + ")");
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}