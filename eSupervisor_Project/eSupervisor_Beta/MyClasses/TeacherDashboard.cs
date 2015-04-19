using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSupervisor_Beta.Models;

namespace eSupervisor_Beta.MyClasses
{
    public class TeacherDashboard
    {
        public user student { get; set; }
        public string roleToStudent { get; set; }
        public TeacherDashboard(user student, string roleToStudent)
        {
            this.student = student;
            this.roleToStudent = roleToStudent;
        }
    }
}