using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSupervisor_Beta.Models;

namespace eSupervisor_Beta.MyClasses
{
    public class PostAndComments
    {
        public post post { get; set; }
        public List<comment> comments { get; set; }

        public PostAndComments(post post, List<comment> comments)
        {
            this.post = post;
            this.comments = comments;
        }
    }
}