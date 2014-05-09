using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrowdSub.Models;

namespace CrowdSub.Controllers
{
    public class VideoController : Controller
    {
        private crowddbEntities db = new crowddbEntities();

        // GET: /Video/
        public ActionResult Index()
        {
            var videos = db.videos.Include(v => v.user);
            return View(videos.ToList());
        }

        // GET: /Video/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video video = db.videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: /Video/Create
        public ActionResult Create()
        {
            ViewBag.video_created_by_user_id = new SelectList(db.users, "id", "user_name");
            return View();
        }

        // POST: /Video/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,video_created_by_user_id,video_title,video_type,video_year_published,video_date_created,video_date_updated")] video video)
        {
            if (ModelState.IsValid)
            {
                db.videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.video_created_by_user_id = new SelectList(db.users, "id", "user_name", video.video_created_by_user_id);
            return View(video);
        }

        // GET: /Video/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video video = db.videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.video_created_by_user_id = new SelectList(db.users, "id", "user_name", video.video_created_by_user_id);
            return View(video);
        }

        // POST: /Video/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,video_created_by_user_id,video_title,video_type,video_year_published,video_date_created,video_date_updated")] video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.video_created_by_user_id = new SelectList(db.users, "id", "user_name", video.video_created_by_user_id);
            return View(video);
        }

        // GET: /Video/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video video = db.videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: /Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            video video = db.videos.Find(id);
            db.videos.Remove(video);
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
