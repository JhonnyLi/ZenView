﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZenView.Core.Models;

namespace ZenView.Web.ViewModels
{
    [Serializable]
    public class ZenViewViewModel
    {
        public ZenViewViewModel()
        {
            ZenView.Core.Helpers.ZendeskHelper helper = new Core.Helpers.ZendeskHelper();
            Tickets = helper.GetTicktets();
            Users = helper.GetAgents();
            
        }
        public Tickets Tickets { get; set; }
        public List<User> Users { get; set; }
    }
}