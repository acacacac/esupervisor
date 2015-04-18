using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSupervisor_Beta.Models;
namespace eSupervisor_Beta.MyClasses
{
    public class TeacherViewMeeting
    {
        public meeting meeting { get; set; }
        public user supervisor { get; set; }
        public List<user> students { get; set; }
        public TeacherViewMeeting(meeting meeting, user supervisor, List<user> students)
        {
            this.meeting = meeting;
            this.supervisor = supervisor;
            this.students = students;
        }
    }
}