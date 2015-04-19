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
using System.IO;

namespace eSupervisor_Beta.Controllers
{
    public class PostController : Controller
    {
        private eSupervisorEntities db = new eSupervisorEntities();
        MyClasses.Authorization authorization = new MyClasses.Authorization();
        // GET: /Post/

        public ActionResult Index()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    switch (db.users.Find((int)Session["userid"]).roleID)
                    {
                        case 2: return RedirectToAction("TeacherViewBlog");
                        default: return RedirectToAction("StudentViewBlog");
                    }
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
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
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");

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
                    return View("Index", postsReturned.Distinct().ToList()); // Return a list including his students
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
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
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult PostFile()
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    return View();
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PostFile(post post)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    fileUpload fileu;
                    int authorID = (int)Session["userid"];
                    post.authorID = authorID;
                    post.postTime = DateTime.Now;
                    post.updateTime = DateTime.Now;
                    db.posts.Add(post);
                    if (db.users.Find(authorID).roleID == 3)//student
                    {
                        interaction interaction = createInteraction(authorID, 4);
                        db.interactions.Add(interaction);
                    }
                    db.SaveChanges();
                    var files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        var file = files[i];
                        fileu = new fileUpload();
                        string path = "";
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            path = Path.Combine(Server.MapPath("~/Document/Files/"), fileName);
                            file.SaveAs(path);
                            fileu.fileUri = path;
                            fileu.postID = post.id;
                            db.fileUploads.Add(fileu);
                            db.SaveChanges();
                        }
                    }
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }


        // GET: /Post/Details/5
        public ActionResult Details(int? id)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    if (id == null)
                    {
                        return RedirectToAction("Index");
                    }
                    post post = db.posts.Find(id);
                    var querryComment = from cm in db.comments
                                        where cm.postID == post.id
                                        select cm;
                    List<comment> comments = querryComment.ToList();
                    PostAndComments postAndComments = new PostAndComments(post, comments);
                    if (post == null)
                    {
                        return HttpNotFound();
                    }
                    return View(postAndComments);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult createComment(string commentContent, string postID)
        {
            if (authorization.validateRememberedUser() || Session["userid"] != null)
                if (authorization.allowAccess(3, (int)Session["userid"]) || authorization.allowAccess(2, (int)Session["userid"]))
                {
                    post post = db.posts.Find(Convert.ToInt16(postID));
                    int commenterID = (int)Session["userid"];
                    comment cm = new comment();
                    cm.C_content = commentContent;
                    cm.postID = post.id;
                    cm.time = DateTime.Now;
                    cm.commenterID = commenterID;
                    if (ModelState.IsValid)
                    {
                        if (db.users.Find(commenterID).roleID == 3)//student
                        {
                            interaction interaction = createInteraction(commenterID, 5);
                            db.interactions.Add(interaction);
                        }
                        db.comments.Add(cm);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Details/" + postID);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
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
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
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
                    int authorID = Convert.ToInt16(Session["userid"]);
                    post.postTime = DateTime.Now;
                    post.updateTime = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        post.authorID = authorID;
                        db.posts.Add(post);
                        if (db.users.Find(authorID).roleID == 3)//student
                        {
                            interaction interaction = createInteraction(authorID, 2);
                            db.interactions.Add(interaction);
                        }
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    ViewBag.authorID = new SelectList(db.users, "id", "firstName", post.authorID);
                    return View(post);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
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
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
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
                        if (db.users.Find(post.authorID).roleID == 3)//student
                        {
                            interaction interaction = createInteraction((int)post.authorID, 3);
                            db.interactions.Add(interaction);
                        }
                        db.Entry(post).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    ViewBag.authorID = new SelectList(db.users, "id", "firstName", post.authorID);
                    return View(post);
                }
                else
                    return RedirectToAction("NotAuthorised", "Home");
            return RedirectToAction("Login", "Home");
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

        public interaction createInteraction(int authorID, int interactionType)
        {
            interaction interaction = new interaction();
            interaction.interactionTypeID = interactionType;
            interaction.studentID = authorID;
            interaction.time = DateTime.Now;
            return interaction;
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
