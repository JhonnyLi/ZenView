using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZenView.Core.Models.ClientConfigModels
{
    public class AccessTokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }
}