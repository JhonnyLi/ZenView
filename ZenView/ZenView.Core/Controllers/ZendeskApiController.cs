using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ZenView.Core.Controllers
{
    [RoutePrefix("api")]
    public class ZendeskApiController : ApiController
    {
        [Route("")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage ZendeskWebHook(string test)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage StatusCakeWebHook(string test)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public void GetZendeskTickets()
        {

        }
       
    }
}
