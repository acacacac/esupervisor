using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eSupervisor_Beta.Models;

namespace eSupervisor_Beta.MyClasses
{
    public class Authorization
    {
        eSupervisorEntities db = new eSupervisorEntities();
        //roleID == 1 ~ Authorised Staff
        //roleID == 2 ~ Teacher
        //roleID == 3 ~ Student
        public bool allowAccess(int roleID, int userID)
        {
            try
            {
                int userRole = (int)db.users.Find(userID).roleID;
                if (userRole == roleID)
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }
           
        }

        public bool validateUser(UserLogin user)
        {
            var us = from u in db.users
                     where u.loginCode.Equals(user.code) && u.loginPass.Equals(user.pwd)
                     select u;
            user uss = new user();
            try
            {
                uss = us.ToList().ElementAt(0);
                HttpContext.Current.Session["userid"] = uss.id;
                HttpContext.Current.Session["userName"] = uss.firstName + " " + uss.lastName;
                if (user.remember == true)
                {
                    HttpCookie cookie = new HttpCookie("esupervisor-login");
                    cookie.Value = user.code + "-" + user.pwd;
                    cookie.Expires = DateTime.Now.AddDays(999);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool validateRememberedUser()
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains("esupervisor-login"))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["esupervisor-login"];
                string code = cookie.Value.Substring(0, cookie.Value.IndexOf("-"));
                string pwd = cookie.Value.Substring(cookie.Value.IndexOf("-") + 1, cookie.Value.Length - code.Length - 1);
                bool remember = true;
                UserLogin user = new UserLogin();
                user.code = code;
                user.pwd = pwd;
                user.remember = remember;
                if (validateUser(user))
                    return true;
            }
            return false;
        }
    }
}