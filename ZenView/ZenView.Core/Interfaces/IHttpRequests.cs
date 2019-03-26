using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenView.Core.Interfaces
{
    interface IHttpRequests
    {
        string GetAllTickets();
        void GetAllGroups();
        void GetAgentsFromGroup(string group);
    }
}
