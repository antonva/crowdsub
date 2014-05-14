using System;
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
using Microsoft.AspNet.Identity;
using System.IO;
using System.Diagnostics;

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
        public ActionResult subtitle_profile(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,subtitle_user_id,subtitle_video_id,subtitle_file_path,subtitle_date_created,subtitle_download_count,subtitle_language")] subtitle subtitle)
        {
            if (ModelState.IsValid)
            {
                string user_id = User.Identity.GetUserId(); // Get the user id
                string user_name = User.Identity.GetUserName(); // Bind the user id to the subtitle object
                subtitle.subtitle_user_id = user_id;   // Add the user id to the video object
                subtitle.subtitle_date_created = DateTime.Now;    // Add current time to the object being created
                
                subtitle_repo.add(subtitle);
                return RedirectToAction("Video/Profile", new { id = subtitle.subtitle_video_id });
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

        public ActionResult TopDownloadedSubtitles()
        {
            var model = (from v in subtitle_repo.get_subtitles()
                        orderby v.subtitle_download_count descending
                        select v).ToList().Take(10);

            return View(model);
        }

		[HttpGet]
		public ActionResult Upload()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Upload(HttpPostedFileBase file)
		{
			if (file.ContentLength > 0)
			{
				var file_name = Path.GetFileName(file.FileName);
				Debug.WriteLine("File name: " + file_name.ToString());
				var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), file_name);
				Debug.WriteLine("File path: " + path.ToString());
				var subtitle = new subtitle
				{
					subtitle_user_id = User.Identity.GetUserId(), //get user id
					subtitle_video_id = 5, 
					subtitle_file_path = file_name,
					subtitle_date_created = DateTime.Now,
					subtitle_download_count = 0,
					subtitle_language = 0
				};
				subtitle_repo.add(subtitle);
				file.SaveAs(path);
			}
			return RedirectToAction("Upload");
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
