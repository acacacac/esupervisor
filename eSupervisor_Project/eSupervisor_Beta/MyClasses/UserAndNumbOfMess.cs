using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSupervisor_Beta.Models;

namespace eSupervisor_Beta.MyClasses
{
    public class UserAndNumbOfMess
    {
        public user user { get; set; }
        public int numbOfMess { get; set; }
        public UserAndNumbOfMess(user user, int numbOfMess)
        {
            this.user = user;
            this.numbOfMess = numbOfMess;
        }
    }
}