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
        public ZenViewViewModel(string token)
        {
            ZenView.Core.Helpers.ZendeskHelper helper = new Core.Helpers.ZendeskHelper();
            Tickets = helper.GetAllTickets(token).tickets;
            Users = helper.GetAllUsers(token);
            
        }
        public List<Ticket> Tickets { get; set; }
        public List<User> Users { get; set; }
    }
}