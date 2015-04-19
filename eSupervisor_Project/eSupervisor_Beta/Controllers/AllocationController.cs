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
using System.Net.Mail;

namespace eSupervisor_Beta.Controllers
{
    public class AllocationController : Controller
    {
        private eSupervisorEntities db = new eSupervisorEntities();
        MyClasses.Authorization authorization = new MyClasses.Authorization();

        public ActionResult viewAllocation()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]))
                {
                    List<StudentWIthSupAndSec> retList = new List<StudentWIthSupAndSec>();
                    StudentWIthSupAndSec studentWithSupAndSec;
                    foreach (allocation alc in db.allocations.ToList())
                    {
                        studentWithSupAndSec = new StudentWIthSupAndSec(db.users.Find(alc.studentID), db.users.Find(alc.supervisorID), db.users.Find(alc.secondmarkerID));
                        retList.Add(studentWithSupAndSec);
                    }
                    return View(retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult selectSupervisor(bool? allocate)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]))
                {
                    Session["allocate"] = allocate;
                    var querrySup = from sup in db.users
                                    where sup.roleID == 2
                                    select sup;
                    return View(querrySup.ToList());
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public ActionResult selectSupervisor(int supervisorID)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]))
                {
                    if (supervisorID == -1)
                    {
                        ViewBag.NoSupervisorSelected = "Please select a supervisor";
                        var querrySup = from sup in db.users
                                        where sup.roleID == 2
                                        select sup;
                        return View(querrySup.ToList());
                    }
                    Session["supervisorID"] = supervisorID;
                    return RedirectToAction("selectSecondMarker");
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }
        public ActionResult selectSecondMarker()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]) && Session["supervisorID"] != null)
                {
                    int selectedsupervisorID = (int)Session["supervisorID"];
                    var querrySec = from sec in db.users
                                    where sec.roleID == 2 && sec.id != selectedsupervisorID
                                    select sec;
                    return View(querrySec.ToList());
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult selectSecondMarker(int secondMarkerID)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]) && Session["supervisorID"] != null)
                {
                    if (secondMarkerID == -1)
                    {
                        ViewBag.NoSecondMarkerSelected = "Please select a second marker";
                        int selectedsupervisorID = (int)Session["supervisorID"];
                        var querrySec = from sec in db.users
                                        where sec.roleID == 2 && sec.id != selectedsupervisorID
                                        select sec;
                        return View(querrySec.ToList());
                    }
                    Session["secondMarkerID"] = secondMarkerID;
                    return RedirectToAction("alloCate");
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult alloCate()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]) && Session["supervisorID"] != null && Session["secondMarkerID"] != null)
                {
                    ViewBag.SupervisorName = db.users.Find((int)Session["supervisorID"]).firstName + " " +
                                             db.users.Find((int)Session["supervisorID"]).lastName;

                    ViewBag.SecondMarkerName = db.users.Find((int)Session["secondMarkerID"]).firstName + " " +
                                             db.users.Find((int)Session["secondMarkerID"]).lastName;

                    if ((bool)Session["allocate"])
                    {
                        //User with no allocation
                        List<user> retList = new List<user>();
                        List<user> students;
                        var querryStudents = from sts in db.users
                                             where sts.roleID == 3
                                             select sts;
                        students = querryStudents.ToList();
                        foreach (user student in students)
                        {
                            var querryAllocation = from alc in db.allocations
                                                   where alc.studentID == student.id
                                                   select alc;
                            if (querryAllocation.ToList().Count <= 0)
                                retList.Add(student);
                        }
                        return View(retList);
                    }
                    else
                    {
                        var querryStudent = from st in db.users
                                            where st.roleID == 3
                                            select st;
                        return View(querryStudent.ToList());
                    }
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult alloCate(string listStudentID)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]))
                {
                    List<int> listStudentIDint = listStudentID.Split(',').Select(int.Parse).ToList();
                    allocation allocation;
                    if (listStudentIDint.Count == 1)
                    {
                            ViewBag.SupervisorName = db.users.Find((int)Session["supervisorID"]).firstName + " " +
                                                 db.users.Find((int)Session["supervisorID"]).lastName;

                            ViewBag.SecondMarkerName = db.users.Find((int)Session["secondMarkerID"]).firstName + " " +
                                                     db.users.Find((int)Session["secondMarkerID"]).lastName;

                            var querryStudent = from st in db.users
                                                from alc in db.allocations
                                                where st.roleID == 3 && alc.studentID != st.id //Student with no allocation
                                                select st;
                            if (listStudentIDint.ElementAt(0) == -2)
                                ViewBag.NoStudentSelected = "Please turn on javascript to proceed!";
                            else
                                ViewBag.NoStudentSelected = "Please select at least one student!";
                            return View(querryStudent.ToList());                            
                    }
                    listStudentIDint.RemoveAt(0);
                    foreach (int studentID in listStudentIDint)
                    {
                        if ((bool)Session["allocate"])
                        {
                            allocation = new allocation();
                            allocation.studentID = studentID;
                        }
                        else
                        {
                            var querryAlc = from alc in db.allocations
                                            where alc.studentID == studentID
                                            select alc;
                            allocation = querryAlc.ToList().ElementAt(0);
                        }
                        allocation.supervisorID = (int)Session["supervisorID"];
                        allocation.secondmarkerID = (int)Session["secondMarkerID"];
                        if (ModelState.IsValid)
                        {
                            if ((bool)Session["allocate"])
                                db.allocations.Add(allocation);
                            else
                            {
                                db.Entry(allocation).State = EntityState.Modified;
                            }
                            db.SaveChanges();
                            sendMail(db.users.Find(studentID).email);
                        }
                    }
                    return RedirectToAction("viewAllocation");
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
        public void sendMail(string recipient)
        {
            recipient = recipient == null ? "noEmailAvailable@gmail.com" : recipient;
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("ewsdTest1415@gmail.com");
            mail.To.Add(recipient);
            mail.Subject = "Allocation";
            mail.Body = "Hello there is a change in your allocation, please log into the eSupervisor to confirm!";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ewsdTest1415@gmail.com", "dareyouenter");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
