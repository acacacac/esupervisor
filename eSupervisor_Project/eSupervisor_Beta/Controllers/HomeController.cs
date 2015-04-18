using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSupervisor_Beta.Models;
using eSupervisor_Beta.MyClasses;
using eSupervisor_Beta.Hubs;
using System.Net.Mail;

namespace eSupervisor_Beta.Controllers
{
    public class HomeController : Controller
    {
        eSupervisorEntities db = new eSupervisorEntities();
        Authorization authorization = new Authorization();

        public ActionResult Index()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
            {
                user u = db.users.Find((int)Session["userid"]);
                switch (u.roleID)
                {
                    case 1: { return RedirectToAction("AuthorisedStaffIndex");}
                    case 2: { return RedirectToAction("TeacherIndex");}
                    default: { return RedirectToAction("StudentIndex");}
                }
            }
            return RedirectToAction("Login");
        }
        public ActionResult AuthorisedStaffIndex()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(1, (int)Session["userid"]))
                    return View();
                else
                    return RedirectToAction("NotAuthorised");
            return RedirectToAction("Login");
        }
        public ActionResult TeacherIndex()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(2, (int)Session["userid"]))
                    return View();
                else
                    return RedirectToAction("NotAuthorised");
            return RedirectToAction("Login");
        }

        public ActionResult StudentIndex()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]))
                    return View();
                else
                    return RedirectToAction("NotAuthorised");
            return RedirectToAction("Login");
        }

        public ActionResult NotAuthorised()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                switch (redirectCode())
                {
                    case 1: { return RedirectToAction("AuthorisedStaffIndex"); }
                    case 2: { return RedirectToAction("TeacherIndex");}
                    case 3: { return View("StudentIndex");}
                    default: { return RedirectToAction("NotAuthorised"); }
                }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin user)
        {
            if (authorization.validateUser(user))
                switch (redirectCode())
                {
                    case 1: { return RedirectToAction("AuthorisedStaffIndex");}
                    case 2: { return RedirectToAction("TeacherIndex");}
                    case 3: { return RedirectToAction("StudentIndex");}
                    default: { return RedirectToAction("NotAuthorised"); }
                }
            ViewBag.res = "Wrong user name or password!";
            return View();
        }
        public ActionResult Logout()
        {
            Session["userid"] = null;
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("esupervisor-login"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["esupervisor-login"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Login");
        }
        public int redirectCode()
        {
            try
            {
                user user = db.users.Find((int)Session["userid"]);
                return (int)user.roleID;
            }
            catch
            {
                return -1;
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void sendMail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("your_email_address@gmail.com");
            mail.To.Add("kid3pzaj@gmail.com");
            mail.Subject = "Test Mail";
            mail.Body = "This is for testing SMTP mail from GMAIL";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("kid3pzaj102@gmail.com", "goodlucktoyou");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}