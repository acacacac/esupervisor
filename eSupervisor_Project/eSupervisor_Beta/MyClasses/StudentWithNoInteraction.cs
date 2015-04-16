using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSupervisor_Beta.Models;

namespace eSupervisor_Beta.MyClasses
{
    public class StudentWithNoInteraction
    {
        public user student { get; set; }
        public int hibernateDays { get; set; }


        public StudentWithNoInteraction(user student, int hibernateDays)
        {
            this.student = student;
            this.hibernateDays = hibernateDays;
        }
    }
}