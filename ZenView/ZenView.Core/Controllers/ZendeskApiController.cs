using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ZenView.Core.Controllers
{
    public class ZendeskApiController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public void ZendeskWebHook(string test)
        {
            throw new NotImplementedException();
        }

        public void GetZendeskTickets()
        {

        }
       
    }
}
