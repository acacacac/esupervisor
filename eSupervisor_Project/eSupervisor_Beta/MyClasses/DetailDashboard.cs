using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSupervisor_Beta.MyClasses
{
    public class DetailDashboard
    {
        public int number { get; set; }
        public string date { get; set; }
        public DetailDashboard(int numberOfMess, string date)
        {
            this.number = numberOfMess;
            this.date = date;
        }
    }
}