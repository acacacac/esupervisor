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
    
    public partial class meeting
    {
        public meeting()
        {
            this.meetingArrangements = new HashSet<meetingArrangement>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> time { get; set; }
        public Nullable<bool> type { get; set; }
        public string detail { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> supervisorID { get; set; }
    
        public virtual user user { get; set; }
        public virtual ICollection<meetingArrangement> meetingArrangements { get; set; }
    }
}
