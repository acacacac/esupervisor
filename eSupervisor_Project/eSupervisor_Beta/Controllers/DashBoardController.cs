using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSupervisor_Beta.MyClasses;
using eSupervisor_Beta.Models;
using System.Data.Objects;

namespace eSupervisor_Beta.Controllers
{
    public class DashBoardController : Controller
    {
        eSupervisorEntities db = new eSupervisorEntities();
        MyClasses.Authorization authorization = new MyClasses.Authorization();
        //
        // GET: /DashBoard/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentDashboard(int studentIDPara)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]) || authorization.allowAccess(3, (int)Session["userid"]))
                {
                    if (db.users.Find(studentIDPara).roleID == 1 || db.users.Find(studentIDPara).roleID == 2 || //Only student dashboard
                         (db.users.Find((int)Session["userid"]).roleID == 3 && studentIDPara != (int)Session["userid"]) //A student cannot see others' stuff 
                         )
                    {
                        //A student cannot view dashboard of others
                        return RedirectToAction("NotAuthorised", "Home");
                    }
                    int studentID = studentIDPara;
                    IEnumerable<message> listMessWithSec = retrieveMessages(studentID).Except(retrieveMessagesWithSup(studentID));

                    int numberOfMess = retrieveMessages(studentID).Count;
                    int numberOfMessWithSup = retrieveMessagesWithSup(studentID).ToList().Count;
                    string lastSentSup = numberOfMessWithSup > 0 ? ((DateTime)retrieveMessagesWithSup(studentID).ToList().Last().time).ToString("MM/dd/yyyy") : "N/A";
                    int numberOfMessWithSec = listMessWithSec.ToList().Count;
                    string lastSentSec = numberOfMessWithSec > 0 ? ((DateTime)listMessWithSec.ToList().Last().time).ToString("MM/dd/yyyy") : "N/A";
                    int numberOfComment = retrieveComments(studentID).Count;
                    string lastComment = numberOfComment > 0 ? ((DateTime)retrieveComments(studentID).Last().time).ToString("MM/dd/yyyy") : "N/A";
                    int numberOfPost = retrievePosts(studentID).Count;
                    string lastPost = numberOfPost > 0 ? ((DateTime)retrievePosts(studentID).Last().postTime).ToString("MM/dd/yyyy") : "N/A";
                    int numberOfMeeting = retrieveMeetings(studentID).Count;
                    string lastMeeting = numberOfMeeting > 0 ? ((DateTime)retrieveMeetings(studentID).Last().time).ToString("MM/dd/yyyy") : "N/A";
                    StudentDashboardProps ret = new StudentDashboardProps(numberOfMess, numberOfMessWithSup, lastSentSup, numberOfMessWithSec,
                                                                          lastSentSec, numberOfComment, lastComment, numberOfPost, lastPost,
                                                                          numberOfMeeting, lastMeeting);
                    ViewBag.studentID = studentID;
                    return View(ret);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult MessagesDetailDashboard(int studentIDPara)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]) || authorization.allowAccess(3, (int)Session["userid"]))
                {
                    if (db.users.Find(studentIDPara).roleID == 1 || db.users.Find(studentIDPara).roleID == 2 || //Only student dashboard
                        (db.users.Find((int)Session["userid"]).roleID == 3 && studentIDPara != (int)Session["userid"]) //A student cannot see others' stuff 
                        )
                    {
                        //A student cannot view dashboard of others
                        return RedirectToAction("NotAuthorised", "Home");
                    }
                    List<DetailDashboard> retList = new List<DetailDashboard>();
                    var querryMessagesByDate = from m in db.messages
                                               where m.senderID == studentIDPara
                                               group m by EntityFunctions.TruncateTime(m.time) into rec
                                               select new
                                               {
                                                   numberOfMess = rec.Count(),
                                                   date = rec.Key
                                               };
                    DetailDashboard mdd;
                    string date;
                    foreach (var item in querryMessagesByDate)
                    {
                        date = item.date.Value.ToString("MM/dd/yyyy");
                        mdd = new DetailDashboard(item.numberOfMess, date);
                        retList.Add(mdd);
                    }
                    ViewBag.TypeDetail = "Number of Messages per day";
                    return PartialView("_DetailDashboard", retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult CommentsDetailDashboard(int studentIDPara)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]) || authorization.allowAccess(3, (int)Session["userid"]))
                {
                    if (db.users.Find(studentIDPara).roleID == 1 || db.users.Find(studentIDPara).roleID == 2 || //Only student dashboard
                         (db.users.Find((int)Session["userid"]).roleID == 3 && studentIDPara != (int)Session["userid"]) //A student cannot see others' stuff 
                         )
                    {
                        //A student cannot view dashboard of others
                        return RedirectToAction("NotAuthorised", "Home");
                    }
                    List<DetailDashboard> retList = new List<DetailDashboard>();
                    var querryCommentsByDate = from m in db.comments
                                               where m.commenterID == studentIDPara
                                               group m by EntityFunctions.TruncateTime(m.time) into rec
                                               select new
                                               {
                                                   number = rec.Count(),
                                                   date = rec.Key
                                               };
                    DetailDashboard mdd;
                    string date;
                    foreach (var item in querryCommentsByDate)
                    {
                        date = item.date.Value.ToString("MM/dd/yyyy");
                        mdd = new DetailDashboard(item.number, date);
                        retList.Add(mdd);
                    }
                    ViewBag.TypeDetail = "Number of Comments per day";
                    return PartialView("_DetailDashboard", retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult PostsDetailDashboard(int studentIDPara)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]) || authorization.allowAccess(3, (int)Session["userid"]))
                {
                    if (db.users.Find(studentIDPara).roleID == 1 || db.users.Find(studentIDPara).roleID == 2 || //Only student dashboard
                        (db.users.Find((int)Session["userid"]).roleID == 3 && studentIDPara != (int)Session["userid"]) //A student cannot see others' stuff 
                        )
                    {
                        //A student cannot view dashboard of others
                        return RedirectToAction("NotAuthorised", "Home");
                    }
                    List<DetailDashboard> retList = new List<DetailDashboard>();
                    var querryPostsByDate = from m in db.posts
                                            where m.authorID == studentIDPara
                                            group m by EntityFunctions.TruncateTime(m.postTime) into rec
                                            select new
                                            {
                                                number = rec.Count(),
                                                date = rec.Key
                                            };
                    DetailDashboard mdd;
                    string date;
                    foreach (var item in querryPostsByDate)
                    {
                        date = item.date.Value.ToString("MM/dd/yyyy");
                        mdd = new DetailDashboard(item.number, date);
                        retList.Add(mdd);
                    }
                    ViewBag.TypeDetail = "Number of Posts per day";
                    return PartialView("_DetailDashboard", retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult AuthorisedStaffDashboard()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]) || authorization.allowAccess(3, (int)Session["userid"]))
                {
                    var users = from u in db.users
                                where u.roleID == 2 || u.roleID == 3
                                select u;
                    return View(users.ToList());
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult TeacherDashboard(int teacherIDPara)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    if (db.users.Find(teacherIDPara).roleID == 1 || db.users.Find(teacherIDPara).roleID == 3 || //Only teacher dashboard
                        (db.users.Find((int)Session["userid"]).roleID == 2 && teacherIDPara != (int)Session["userid"]) //A teacher cannot see others' stuff 
                        )
                    {
                        //A student cannot view dashboard of others
                        return RedirectToAction("NotAuthorised", "Home");
                    }
                    var querryStudents = from st in db.users
                                         from te in db.users
                                         from a in db.allocations
                                         where a.studentID == st.id &&
                                         (a.supervisorID == te.id || a.secondmarkerID == te.id) &&
                                         te.id == teacherIDPara
                                         select st;
                    List<TeacherDashboard> retList = new List<TeacherDashboard>();
                    string teacherRole;
                    foreach(user student in querryStudents.ToList()){
                        var role = from a in db.allocations
                                   where a.studentID == student.id
                                   select a;
                        teacherRole = role.ToList().ElementAt(0).supervisorID == teacherIDPara ? "Supervisor" : "Second marker";
                        retList.Add(new TeacherDashboard(student, teacherRole));
                    }
                    return View(retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public List<message> retrieveMessages(int studentID)
        {
            var querryMess = from m in db.messages
                             where m.senderID == studentID
                             select m;
            return querryMess.ToList();
        }

        public List<message> retrieveMessagesWithSup(int studentID)
        {
            var querryMessWithSup = from m in db.messages
                                    from t in db.users
                                    from a in db.allocations
                                    where m.senderID == studentID &&
                                    m.receiverID == t.id &&
                                    a.studentID == studentID &&
                                    a.supervisorID == t.id
                                    select m;
            return querryMessWithSup.ToList();
        }

        public List<comment> retrieveComments(int studentID)
        {
            var querryComment = from cm in db.comments
                                where cm.commenterID == studentID
                                select cm;
            return querryComment.ToList();
        }

        public List<post> retrievePosts(int studentID)
        {
            var querryPost = from p in db.posts
                             where p.authorID == studentID
                             select p;
            return querryPost.ToList();
        }

        public List<meeting> retrieveMeetings(int studentID)
        {
            var querryMeeting = from mt in db.meetings
                                from mta in db.meetingArrangements
                                where mta.studentID == studentID &&
                                mta.meetingID == mt.id
                                select mt;
            return querryMeeting.ToList();
        }

    }
}
