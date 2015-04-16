using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSupervisor_Beta.Models;
using eSupervisor_Beta.MyClasses;
using eSupervisor_Beta.Hubs;
using System.Net;

namespace eSupervisor_Beta.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/
        eSupervisorEntities db = new eSupervisorEntities();
        MyClasses.Authorization authorization = new MyClasses.Authorization();
        public ActionResult StudentMessage()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]))
                {
                    user student = db.users.Find((int)Session["userid"]);
                    var querryAllocation = from alc in db.allocations
                                           where alc.studentID == student.id
                                           select alc;
                    allocation allo = querryAllocation.ToList().ElementAt(0);
                    SupervisorAndSecondMarkerID supvisorAndSecondMarkerID = new SupervisorAndSecondMarkerID((int)allo.supervisorID, (int)allo.secondmarkerID,
                                                                                                             allo.user1.firstName + allo.user1.lastName,
                                                                                                             allo.user2.firstName + allo.user2.lastName);
                    return View(supvisorAndSecondMarkerID);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login","Home");
        }

        public ActionResult TeacherMessage()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(2, (int)Session["userid"]))
                {
                    List<user> retList = new List<user>(); //students
                    user student;
                    user teacher = db.users.Find((int)Session["userid"]);
                    var querryAllocation = from alc in db.allocations
                                           where alc.supervisorID == teacher.id || alc.secondmarkerID == teacher.id
                                           select alc;
                    List<allocation> allos = querryAllocation.ToList();
                    foreach (allocation allo in allos)
                    {
                        student = new user();
                        student = db.users.Find(allo.studentID);
                        retList.Add(student);
                    }
                    return View(retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login","Home");
        }

        public PartialViewResult GetMessages(int? receiverID)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    MessagesRepository mr = new MessagesRepository();
                    return PartialView("_MessagesList", mr.GetAllMessages((int)receiverID));
                }
            return PartialView("NotAuthorised");
        }

        [HttpPost]
        public ActionResult SendMessage(string message, int receiverID)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    message mes = new message();
                    int userRole = (int)db.users.Find((int)Session["userid"]).roleID;
                    mes.C_content = message;
                    mes.senderID = (int)Session["userid"];
                    mes.receiverID = receiverID;
                    mes.time = DateTime.Now;
                    interaction itr = null;
                    if (userRole == 3)
                    {
                        itr = new interaction();
                        itr.interactionTypeID = 1;
                        itr.studentID = (int)Session["userid"];
                        itr.time = DateTime.Now;
                    }
                    if (ModelState.IsValid)
                    {
                        db.messages.Add(mes);
                        if (userRole == 3)
                            db.interactions.Add(itr);
                        db.SaveChanges();
                    }
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
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