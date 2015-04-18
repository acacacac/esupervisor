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
    public class PostController : Controller
    {
        private eSupervisorEntities db = new eSupervisorEntities();
        MyClasses.Authorization authorization = new MyClasses.Authorization();
        // GET: /Post/

        public ActionResult Index()
        {
            switch (db.users.Find((int)Session["userid"]).roleID)
            {
                case 2: return RedirectToAction("TeacherViewBlog");
                default: return RedirectToAction("StudentViewBlog");
            }
        }
        public ActionResult StudentViewBlog()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]))
                {
                    int studentID = Convert.ToInt16(Session["userid"].ToString());
                    var querryAllocation = from alc in db.allocations
                                           where alc.studentID == studentID
                                           select alc;
                    List<allocation> allo = querryAllocation.ToList();
                    int supID = Convert.ToInt16(allo.ElementAt(0).supervisorID);
                    int secID = Convert.ToInt16(allo.ElementAt(0).secondmarkerID);

                    var querryPost = from p in db.posts
                                     where p.authorID == studentID || p.authorID == supID || p.authorID == secID
                                     select p;
                    return View("Index", querryPost.ToList());// Return a list including his teacher and secondmarker
                }
                else
                    return RedirectToAction("NotAuthorised");
            return RedirectToAction("Login");

        }
        public ActionResult TeacherViewBlog()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(2, (int)Session["userid"]))
                {
                    int teacherID = Convert.ToInt16(Session["userid"].ToString());
                    List<post> postsReturned = new List<post>();
                    var querryAllocation = from alc in db.allocations
                                           where alc.supervisorID == teacherID || alc.secondmarkerID == teacherID
                                           select alc;

                    List<allocation> allo = querryAllocation.ToList();

                    foreach (allocation a in allo)
                    {
                        int studentID = (int)a.studentID;
                        var post = from p in db.posts
                                   where p.authorID == studentID || p.authorID == teacherID
                                   select p;
                        List<post> ps = post.ToList();
                        foreach (post p in ps)
                        {
                            postsReturned.Add(p);
                        }
                    }
                    return View("Index", postsReturned.ToList()); // Return a list including his students
                }
                else
                    return RedirectToAction("NotAuthorised");
            return RedirectToAction("Login");
        }

        public ActionResult MyBlog()// Return a list of his blogs
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    //Session["userid"] = "2";
                    //int usid = Convert.ToInt16(Session["userid"].ToString());
                    //THe two lines of code above is only used for viewing MyBlog
                    int userID = Convert.ToInt16(Session["userid"].ToString());
                    var posts = from p in db.posts
                                where p.authorID == userID
                                select p;
                    return View("Index", posts.ToList());
                }
                else
                    return RedirectToAction("NotAuthorised");
            return RedirectToAction("Login");
        }

        // GET: /Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: /Post/Create
        public ActionResult Create()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    return View();
                }
                else
                    return RedirectToAction("NotAuthorised");
            return RedirectToAction("Login");
        }

        // POST: /Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,authorID,title,C_content,postTime,updateTime")] post post)
        {
             if (authorization.validateRememberedUser() || Session["userid"] != null)
                 if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                 {
                     post.postTime = DateTime.Now;
                     post.updateTime = DateTime.Now;

                     if (ModelState.IsValid)
                     {
                         post.authorID = Convert.ToInt16(Session["userid"]);
                         db.posts.Add(post);
                         db.SaveChanges();
                         return RedirectToAction("Index");
                     }

                     ViewBag.authorID = new SelectList(db.users, "id", "firstName", post.authorID);
                     return View(post);
                 }
                 else
                     return RedirectToAction("NotAuthorised");
             return RedirectToAction("Login");
        }

        // GET: /Post/Edit/5
        public ActionResult Edit(int? id)
        {
             if (authorization.validateRememberedUser() || Session["userid"] != null)
                 if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                 {
                     if (id == null)
                     {
                         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                     }
                     post post = db.posts.Find(id);
                     if (post == null)
                     {
                         return HttpNotFound();
                     }
                     ViewBag.authorID = new SelectList(db.users, "id", "firstName", post.authorID);
                     return View(post);
                 }
                 else
                     return RedirectToAction("NotAuthorised");
             return RedirectToAction("Login");
        }

        // POST: /Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,authorID,title,C_content,postTime,updateTime")] post post)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    post.updateTime = DateTime.Now;

                    if (ModelState.IsValid)
                    {
                        db.Entry(post).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    ViewBag.authorID = new SelectList(db.users, "id", "firstName", post.authorID);
                    return View(post);
                }
                else
                    return RedirectToAction("NotAuthorised");
            return RedirectToAction("Login");
        }

        // GET: /Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: /Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            post post = db.posts.Find(id);
            db.posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
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
