using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZenView.Core.Controllers;
using ZenView.Core.Internals;

namespace ZenView.Core.Helpers
{
    public class ZendeskHelper
    {
        public ZendeskHelper()
        {
            

        }

        public string GetTicktets()
        {
            HttpRequests req = new HttpRequests();
            var result = req.GetAllTickets();
            return result;
        }
    }
}