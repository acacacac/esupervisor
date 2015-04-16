using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSupervisor_Beta.MyClasses
{
    public class SupervisorAndSecondMarkerID
    {
        public int supervisorID { get; set; }
        public int secondMarkerID { get; set; }
        public string supervisorName { get; set; }
        public string secondMarkerName { get; set; }

        public SupervisorAndSecondMarkerID(int supervisorID, int secondMarkerID, string supervisorName, string secondMarkerName)
        {
            this.supervisorID = supervisorID;
            this.secondMarkerID = secondMarkerID;
            this.supervisorName = supervisorName;
            this.secondMarkerName = secondMarkerName;
        }
    }
}