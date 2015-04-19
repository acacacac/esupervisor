using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSupervisor_Beta.MyClasses
{
    public class StudentDashboardProps
    {
        public int numberOfMess {get;set;}
        public int numberOfMessWithSup {get;set;}
        public string lastSentSup {get;set;}
        public int numberOfMessWithSec {get;set;}
        public string lastSentSec {get;set;}
        public int numberOfComment {get;set;}
        public string lastComment {get;set;}
        public int numberOfPost {get;set;}
        public string lastPost {get;set;}
        public int numberOfMeeting {get;set;}
        public string lastMeeting {get;set;}

        public StudentDashboardProps(int numberOfMess, int numberOfMessWithSup, string lastSentSup, int numberOfMessWithSec,
                                     string lastSentSec, int numberOfComment, string lastComment, int numberOfPost,
                                     string lastPost, int numberOfMeeting, string lastMeeting)
        {
            this.numberOfMess = numberOfMess;
            this.numberOfMessWithSup = numberOfMessWithSup;
            this.lastSentSup = lastSentSup;
            this.numberOfMessWithSec = numberOfMessWithSec;
            this.lastSentSec = lastSentSec;
            this.numberOfComment = numberOfComment;
            this.lastComment = lastComment;
            this.numberOfPost = numberOfPost;
            this.lastPost = lastPost;
            this.numberOfMeeting = numberOfMeeting;
            this.lastMeeting = lastMeeting;
        }
    }
}