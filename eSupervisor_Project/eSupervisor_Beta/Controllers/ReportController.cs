using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSupervisor_Beta.Models;
using eSupervisor_Beta.MyClasses;

namespace eSupervisor_Beta.Controllers
{
    public class ReportController : Controller
    {
        eSupervisorEntities db = new eSupervisorEntities();
        Authorization authorization = new Authorization();
        //
        // GET: /Report/
        public ActionResult NumbOfMess()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]))
                {
                    List<user> list;
                    UserAndNumbOfMess userAndNumbOfMess;
                    int numbOfMess;
                    DateTime sevenDaysBefore = DateTime.Now.AddDays(-7);
                    List<UserAndNumbOfMess> retList = new List<UserAndNumbOfMess>();
                    var querryStudents = from sts in db.users
                                         select sts;
                    list = querryStudents.ToList();
                    foreach (user user in list)
                    {
                        var querryMess = from mes in db.messages
                                         where mes.senderID == user.id &&
                                         (mes.time >= sevenDaysBefore && mes.time <= DateTime.Now)
                                         select mes;
                        numbOfMess = querryMess.ToList().Count;
                        userAndNumbOfMess = new UserAndNumbOfMess(user, numbOfMess);
                        retList.Add(userAndNumbOfMess);
                    }
                    return View(retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult AverageMess()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]))
                {
                    List<user> supervisors;
                    SupervisorAndAverageNumbOfMess supervisorAndAverageNumbOfMess;
                    List<SupervisorAndAverageNumbOfMess> retList = new List<SupervisorAndAverageNumbOfMess>();
                    int numbOfMess;
                    DateTime firstDate, lastDate;
                    int numbOfDays;
                    double averageNumbOfMess;

                    var querrySupervisor = from sup in db.users
                                           where sup.roleID == 2
                                           select sup;
                    supervisors = querrySupervisor.ToList();
                    foreach (user supervisor in supervisors)
                    {
                        var querryMess = (from mes in db.messages
                                          where mes.senderID == supervisor.id
                                          select mes).Distinct().OrderBy(mes => mes.time);
                        try
                        {
                            firstDate = (DateTime)querryMess.ToList().ElementAt(0).time;
                            lastDate = (DateTime)querryMess.ToList().ElementAt(querryMess.ToList().Count - 1).time;
                            numbOfMess = querryMess.ToList().Count;
                            numbOfDays = lastDate.Subtract(firstDate).Days + 1;
                            averageNumbOfMess = Convert.ToDouble((numbOfMess / (double)numbOfDays).ToString("#.##"));
                        }
                        catch //No messages have been sent
                        {
                            averageNumbOfMess = 0;
                        }
                        supervisorAndAverageNumbOfMess = new SupervisorAndAverageNumbOfMess(supervisor, averageNumbOfMess);
                        retList.Add(supervisorAndAverageNumbOfMess);
                    }
                    return View(retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult StudentWithoutSupervisor()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]))
                {
                    List<user> retList = new List<user>();
                    List<user> students;
                    var querryStudents = from sts in db.users
                                         where sts.roleID == 3
                                         select sts;
                    students = querryStudents.ToList();
                    foreach (user student in students)
                    {
                        var querryAllocation = from alc in db.allocations
                                               where alc.studentID == student.id &&
                                               alc.supervisorID != null &&
                                               alc.secondmarkerID != null
                                               select alc;
                        if (querryAllocation.ToList().Count <= 0)
                            retList.Add(student);
                    }

                    return View(retList);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult StudentWithNoInteraction()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]))
                {
                    List<StudentWithNoInteraction> retList = new List<StudentWithNoInteraction>();
                    List<user> students;
                    StudentWithNoInteraction studentWithNoInteraction;
                    DateTime lastTime;
                    int hibernateDays;
                    var querryStudent = from sts in db.users
                                        where sts.roleID == 3
                                        select sts;
                    students = querryStudent.ToList();
                    foreach (user student in students)
                    {
                        var querryInteraction = (from ir in db.interactions
                                                 where ir.studentID == student.id
                                                 select ir).Distinct().OrderBy(ir => ir.time);
                        try
                        {
                            lastTime = (DateTime)querryInteraction.ToList().ElementAt(querryInteraction.ToList().Count - 1).time;
                            hibernateDays = DateTime.Now.Subtract(lastTime).Days;
                            if (hibernateDays > 7)
                            {
                                studentWithNoInteraction = new StudentWithNoInteraction(student, hibernateDays);
                                retList.Add(studentWithNoInteraction);
                            }
                        }
                        catch //No interactions have been made yet
                        {

                        }
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