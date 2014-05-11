using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrowdSub.Models;
using CrowdSub.Repositories;

namespace CrowdSub.Controllers
{
    public class UserController : Controller
    {
        private readonly i_user_repository user_repo;

        // Normal constructor.
        public UserController()
        {
            var users = new user_repository();
            user_repo = users;
        }

        // Test constructor, takes a repository as argument.
        public UserController(i_user_repository users)
        {
            user_repo = users;
        }

        // GET: /User/
        public ActionResult Index()
        {
            var model = (from u in user_repo.get_users()
                          orderby u.user_name descending
                          select u).Take(12);

            return View(model);
        }

    //    // GET: /User/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        user user = db.users.Find(id);
    //        if (user == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(user);
    //    }

    //    // GET: /User/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: /User/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include="id,user_name,user_role,user_password,user_email")] user user)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.users.Add(user);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        return View(user);
    //    }

    //    // GET: /User/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        user user = db.users.Find(id);
    //        if (user == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(user);
    //    }

    //    // POST: /User/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include="id,user_name,user_role,user_password,user_email")] user user)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(user).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(user);
    //    }

    //    // GET: /User/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        user user = db.users.Find(id);
    //        if (user == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(user);
    //    }

    //    // POST: /User/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        user user = db.users.Find(id);
    //        db.users.Remove(user);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    }
}
