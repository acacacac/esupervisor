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
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    
    public partial class post
    {
        public post()
        {
            this.comments = new HashSet<comment>();
            this.fileUploads = new HashSet<fileUpload>();
        }
    
        public int id { get; set; }
        public Nullable<int> authorID { get; set; }
        public string title { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string C_content { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public Nullable<System.DateTime> postTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }
    
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<fileUpload> fileUploads { get; set; }
        public virtual user user { get; set; }
    }
}
