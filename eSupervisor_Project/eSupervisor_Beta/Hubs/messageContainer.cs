using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSupervisor_Beta.Hubs
{
    public class messageContainer
    {
        public string content { get; set; }
        public string senderName { get; set; }
        public int senderID { get; set; }
        public Nullable<System.DateTime> time { get; set; }
    }
}