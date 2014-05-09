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
    public class SubtitleController : Controller
    {
        private crowddbEntities db = new crowddbEntities();

        // GET: /Subtitle/
        public ActionResult Index()
        {
            var subtitles = db.subtitles.Include(s => s.user).Include(s => s.video);
            return View(subtitles.ToList());
        }

        // GET: /Subtitle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subtitle subtitle = db.subtitles.Find(id);
            if (subtitle == null)
            {
                return HttpNotFound();
            }
            return View(subtitle);
        }

        // GET: /Subtitle/Create
        public ActionResult Create()
        {
            ViewBag.subtitle_user_id = new SelectList(db.users, "id", "user_name");
            ViewBag.subtitle_video_id = new SelectList(db.videos, "id", "video_title");
            return View();
        }

        // POST: /Subtitle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,subtitle_user_id,subtitle_video_id,subtitle_file_path,subtitle_version_is_active,subtitle_version")] subtitle subtitle)
        {
            if (ModelState.IsValid)
            {
                db.subtitles.Add(subtitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.subtitle_user_id = new SelectList(db.users, "id", "user_name", subtitle.subtitle_user_id);
            ViewBag.subtitle_video_id = new SelectList(db.videos, "id", "video_title", subtitle.subtitle_video_id);
            return View(subtitle);
        }

        // GET: /Subtitle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subtitle subtitle = db.subtitles.Find(id);
            if (subtitle == null)
            {
                return HttpNotFound();
            }
            ViewBag.subtitle_user_id = new SelectList(db.users, "id", "user_name", subtitle.subtitle_user_id);
            ViewBag.subtitle_video_id = new SelectList(db.videos, "id", "video_title", subtitle.subtitle_video_id);
            return View(subtitle);
        }

        // POST: /Subtitle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,subtitle_user_id,subtitle_video_id,subtitle_file_path,subtitle_version_is_active,subtitle_version")] subtitle subtitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subtitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subtitle_user_id = new SelectList(db.users, "id", "user_name", subtitle.subtitle_user_id);
            ViewBag.subtitle_video_id = new SelectList(db.videos, "id", "video_title", subtitle.subtitle_video_id);
            return View(subtitle);
        }

        // GET: /Subtitle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subtitle subtitle = db.subtitles.Find(id);
            if (subtitle == null)
            {
                return HttpNotFound();
            }
            return View(subtitle);
        }

        // POST: /Subtitle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subtitle subtitle = db.subtitles.Find(id);
            db.subtitles.Remove(subtitle);
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
