using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eSupervisor_Beta.Models;
using eSupervisor_Beta.MyClasses;

namespace eSupervisor_Beta.Controllers
{
    public class MeetingController : Controller
    {
        private eSupervisorEntities db = new eSupervisorEntities();
        MyClasses.Authorization authorization = new MyClasses.Authorization();

        // GET: /Meeting/
        // GET: /Meeting/Details/5
        public ActionResult createMeeting()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(2, (int)Session["userid"]))
                {
                    int supervisorID = (int)Session["userid"];
                    var querryStudents = from st in db.users
                                         from alc in db.allocations
                                         where alc.studentID == st.id && alc.supervisorID == supervisorID
                                         select st;
                    return View(querryStudents.ToList());
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult createMeeting(string listStudentID, DateTime time, string detail, bool? virtualMeeting)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(2, (int)Session["userid"]))
                {
                    List<int> listStudentIDint = listStudentID.Split(',').Select(int.Parse).ToList();
                    int supervisorID = (int)Session["userid"];
                    virtualMeeting = virtualMeeting == null ? false : true;
                    if (listStudentIDint.Count == 1)
                    {
                        var querryStudents = from st in db.users
                                             from alc in db.allocations
                                             where alc.studentID == st.id && alc.supervisorID == supervisorID
                                             select st;
                        if (listStudentIDint.ElementAt(0) == -2)
                            ViewBag.NoStudentSelected = "Please turn on javascript to proceed!";
                        else
                            ViewBag.NoStudentSelected = "Please select at least one student!";
                        return View(querryStudents.ToList());
                    }
                    listStudentIDint.RemoveAt(0);
                    meeting meeting;
                    int meetingID = -1;
                    meetingArrangement meetingArrangement;
                    DateTime createDate = DateTime.Now;
                    meeting = new meeting();
                    meeting.supervisorID = supervisorID;
                    meeting.time = time;
                    meeting.createDate = createDate;
                    meeting.type = virtualMeeting;
                    meeting.detail = detail;
                    if (ModelState.IsValid)
                    {
                        db.meetings.Add(meeting);
                        db.SaveChanges();
                        meetingID = meeting.id;
                    }
                    foreach (int studentID in listStudentIDint)
                    {
                        meetingArrangement = new meetingArrangement();
                        meetingArrangement.meetingID = meetingID;
                        meetingArrangement.studentID = studentID;
                        if (ModelState.IsValid)
                        {
                            db.meetingArrangements.Add(meetingArrangement);
                            db.SaveChanges();
                        }
                    }
                    return RedirectToAction("teacherViewMeeting");
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult teacherViewMeeting()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(2, (int)Session["userid"]))
                {
                    user supervisor = db.users.Find((int)Session["userid"]);
                    List<meeting> listMeetings;
                    List<TeacherViewMeeting> retList = new List<TeacherViewMeeting>();
                    TeacherViewMeeting tvm;

                    var querryMeeting = from mt in db.meetings
                                        where mt.supervisorID == supervisor.id
                                        select mt;
                    listMeetings = querryMeeting.ToList();
                    foreach (meeting meeting in listMeetings)
                    {
                        var querryStudent = from st in db.users
                                            from mtarr in db.meetingArrangements
                                            where mtarr.studentID == st.id && mtarr.meetingID == meeting.id
                                            select st;
                        tvm = new TeacherViewMeeting(meeting, supervisor, querryStudent.ToList());
                        retList.Add(tvm);
                    }
                    return View(retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult studentViewMeeting()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]))
                {
                    user student = db.users.Find((int)Session["userid"]);
                    List<meetingArrangement> listMeetingsArr;
                    List<StudentViewMeeting> retList = new List<StudentViewMeeting>();
                    StudentViewMeeting svm;
                    user supervisor;
                    meeting meeting;
                    int numberOfStudent;

                    var querryMeetingArr = from mtArr in db.meetingArrangements
                                           where mtArr.studentID == student.id
                                           select mtArr;
                    listMeetingsArr = querryMeetingArr.ToList();
                    foreach (meetingArrangement meetingArr in listMeetingsArr)
                    {
                        meeting = db.meetings.Find(meetingArr.meetingID);
                        numberOfStudent = (from mtArr2 in db.meetingArrangements where mtArr2.meetingID == meeting.id select mtArr2).ToList().Count;
                        supervisor = db.users.Find(meeting.supervisorID);
                        svm = new StudentViewMeeting(meeting, numberOfStudent, supervisor);
                        retList.Add(svm);
                    }
                    return View(retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
