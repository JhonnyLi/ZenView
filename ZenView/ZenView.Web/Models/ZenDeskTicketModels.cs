using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZenView.Web.Models
{
    public class Ticket
    {
        public string ticket_id { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Organization
    {
        public string name { get; set; }
    }

    public class Requester
    {
        public string requester_field { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public Organization organization { get; set; }
    }

    public class Assignee
    {
        public string name { get; set; }
        public string email { get; set; }
    }

    public class Message
    {
        public Ticket ticket { get; set; }
        public Requester requester { get; set; }
        public Assignee assignee { get; set; }
    }

    public class WebhookModel
    {
        public Message message { get; set; }
    }
}