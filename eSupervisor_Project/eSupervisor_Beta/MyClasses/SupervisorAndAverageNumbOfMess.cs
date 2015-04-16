using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSupervisor_Beta.Models;

namespace eSupervisor_Beta.MyClasses
{
    public class SupervisorAndAverageNumbOfMess
    {
        public user supervisor { get; set; }
        public double averageNumbOfMess { get; set; }
        public SupervisorAndAverageNumbOfMess(user supervisor, double averageNumbOfMess)
        {
            this.supervisor = supervisor;
            this.averageNumbOfMess = averageNumbOfMess;
        }
    }
}