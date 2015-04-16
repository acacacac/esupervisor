using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eSupervisor_Beta.MyClasses
{
    public class UserLogin
    {
        [DisplayName("User Code")]
        [Required]
        public string code { get; set; }
        [DisplayName("Password")]
        [Required]
        public string pwd { get; set; }
        [DisplayName("Remember")]
        public bool remember { get; set; }
    }
}