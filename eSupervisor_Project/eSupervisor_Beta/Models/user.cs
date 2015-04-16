//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eSupervisor_Beta.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public user()
        {
            this.allocations = new HashSet<allocation>();
            this.allocations1 = new HashSet<allocation>();
            this.allocations2 = new HashSet<allocation>();
            this.comments = new HashSet<comment>();
            this.interactions = new HashSet<interaction>();
            this.meetings = new HashSet<meeting>();
            this.meetings1 = new HashSet<meeting>();
            this.messages = new HashSet<message>();
            this.messages1 = new HashSet<message>();
            this.posts = new HashSet<post>();
        }
    
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public string email { get; set; }
        public Nullable<int> roleID { get; set; }
        public string loginCode { get; set; }
        public string loginPass { get; set; }
    
        public virtual ICollection<allocation> allocations { get; set; }
        public virtual ICollection<allocation> allocations1 { get; set; }
        public virtual ICollection<allocation> allocations2 { get; set; }
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<interaction> interactions { get; set; }
        public virtual ICollection<meeting> meetings { get; set; }
        public virtual ICollection<meeting> meetings1 { get; set; }
        public virtual ICollection<message> messages { get; set; }
        public virtual ICollection<message> messages1 { get; set; }
        public virtual ICollection<post> posts { get; set; }
        public virtual role role { get; set; }
    }
}