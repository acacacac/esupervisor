using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSupervisor_Beta.Models;

namespace eSupervisor_Beta.MyClasses
{
    public class StudentViewMeeting
    {
        public meeting meeting {get;set;}
        public int numberOfStudent {get;set;}
        public user supervisor{get;set;}
        public StudentViewMeeting(meeting meeting, int numberOfStudent, user supervisor)
        {
            this.meeting = meeting;
            this.numberOfStudent = numberOfStudent;
            this.supervisor =supervisor;
        }
    }
}