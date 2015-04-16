using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSupervisor_Beta.Models;

namespace eSupervisor_Beta.MyClasses
{
    public class StudentWIthSupAndSec
    {
        public user student { get; set; }
        public user supervisor {get;set;}
        public user secondMarker { get;set;}

        public StudentWIthSupAndSec(user student, user supervisor, user secondMarker){
            this.student = student;
            this.supervisor = supervisor;
            this.secondMarker = secondMarker;
        }
    }
}