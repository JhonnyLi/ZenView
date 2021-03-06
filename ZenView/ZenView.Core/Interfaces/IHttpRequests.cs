﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenView.Core.Models;
using ZenView.Core.Models.ClientConfigModels;

namespace ZenView.Core.Interfaces
{
    interface IHttpRequests
    {
        Tickets GetAllTickets(string token);
        List<User> GetAllUsers(string token);
        AccessTokenModel GetAccessToken(string code);

    }
}
