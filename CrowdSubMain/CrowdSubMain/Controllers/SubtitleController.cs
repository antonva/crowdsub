﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;
using CrowdSubMain.Repositories;

namespace CrowdSubMain.Controllers
{
    public class SubtitleController : Controller
    {
		private readonly i_subtitle_repository subtitle_repo;
		public SubtitleController()
		{
			subtitle_repository subtitle = new subtitle_repository();
			subtitle_repo = subtitle;
		}

		public SubtitleController(i_subtitle_repository subtitles)
		{
			subtitle_repo = subtitles; //constructor takes repo as parameter
		}

        // GET: /Subtitle/
        public ActionResult Index()
        {
            return View(subtitle_repo.get_subtitles());
        }

        // GET: /Subtitle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			subtitle subtitle = subtitle_repo.get_subtitles().Where(x => x.id == id).FirstOrDefault();
            if (subtitle == null)
            {
                return HttpNotFound();
            }
            return View(subtitle);
        }

        // GET: /Subtitle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Subtitle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,subtitle_user_id,subtitle_video_id,subtitle_file_path,subtitle_date_created,subtitle_download_count,subtitle_language")] subtitle subtitle)
        {
            if (ModelState.IsValid)
            {
				subtitle_repo.add(subtitle);
                return RedirectToAction("Index");
            }

            return View(subtitle);
        }

        // GET: /Subtitle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			subtitle subtitle = subtitle_repo.get_subtitles().Where(x => x.id == id).FirstOrDefault();
            if (subtitle == null)
            {
                return HttpNotFound();
            }
            return View(subtitle);
        }

        // POST: /Subtitle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,subtitle_user_id,subtitle_video_id,subtitle_file_path,subtitle_date_created,subtitle_download_count,subtitle_language")] subtitle subtitle)
        {
            if (ModelState.IsValid)
            {
				subtitle_repo.edit(subtitle);
                return RedirectToAction("Index");
            }
            return View(subtitle);
        }

        // GET: /Subtitle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			subtitle subtitle = subtitle_repo.get_subtitles().Where(x => x.id == id).FirstOrDefault();
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
			subtitle subtitle = subtitle_repo.get_subtitles().Where(x => x.id == id).FirstOrDefault();
			subtitle_repo.delete(subtitle);
            return RedirectToAction("Index");
        }

        /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        } */
    }
}