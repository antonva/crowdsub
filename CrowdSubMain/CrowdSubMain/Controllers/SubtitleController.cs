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
using Microsoft.AspNet.Identity;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace CrowdSubMain.Controllers
{
    public class SubtitleController : Controller
    {
		private readonly i_subtitle_repository subtitle_repo;
		private readonly i_video_repository video_repo;
        private readonly i_subtitle_comment_repository subtitle_comment_repo;

		public SubtitleController()
		{
			subtitle_repository subtitle = new subtitle_repository();
			video_repository videos = new video_repository();
            subtitle_comment_repository sc_repo = new subtitle_comment_repository();
            subtitle_repo = subtitle;
			video_repo = videos;
            subtitle_comment_repo = sc_repo; 
		}

		public SubtitleController(i_subtitle_repository subtitles)
		{
			subtitle_repo = subtitles; //constructor takes repo as parameter
		}

        // GET: /Subtitle/
        public ActionResult Index()
        {
			var view_model = new subtitle_view_model_download
			{
				path = Server.MapPath("~/App_Data/uploads"),
				subtitles = new List<subtitle>()
			};
			var paths = Directory.GetFiles(view_model.path).ToList();
			view_model.subtitles = (from s in subtitle_repo.get_subtitles()
									orderby s.subtitle_file_path descending
									select s).ToList();
			foreach(var sub in view_model.subtitles)
			{
				var file_name = sub.subtitle_file_path;
				sub.subtitle_file_path = Path.Combine(Server.MapPath("~/App_data/uploads"), file_name);
			}
			return View(view_model);
        }

		public FileResult download(string file_path, string file_name)
		{
			var file = File(file_path, System.Net.Mime.MediaTypeNames.Text.Plain, file_name);
			return file;
		}

        // GET: /Subtitle/Details/5
        public ActionResult subtitle_profile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            IEnumerable<subtitle_comment> subtitle_comments = get_comments_for_subtitle(id);

			subtitle subtitle = subtitle_repo.get_subtitles().Where(x => x.id == id).FirstOrDefault();
            if (subtitle == null)
            {
                return HttpNotFound();
            }
            
            string srt_string = string.Empty;
            string file_path = Path.Combine(Server.MapPath("~/App_Data/uploads"), subtitle.subtitle_file_name);
            using (StreamReader stream_reader = new StreamReader(file_path, Encoding.UTF8))
            {            
                srt_string = stream_reader.ReadToEnd();
            }

            
            var model = new subtitle_profile_model { subtitle = subtitle, srt_string = srt_string, subtitle_comments = subtitle_comments };
            return View(model);
        }

        // GET: /Subtitle/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        public ActionResult RecentSubtitles() 
        {
            var model = (from v in subtitle_repo.get_subtitles()
                         orderby v.subtitle_date_created descending
                         select v).ToList().Take(10);
            return View(model);
        }

		[HttpPost]
        [Authorize]
		public ActionResult Upload(HttpPostedFileBase file, int video_id)
		{
			if (file.ContentLength > 0)
			{
				var video_name = (from v in video_repo.get_videos()
								  where v.id == video_id
								  select v).First().video_title; //get title of video
				var file_name = video_name + ".srt";
				Debug.WriteLine("File name: " + file_name.ToString());
				var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), file_name);
				Debug.WriteLine("File path: " + path.ToString());
				var subtitle = new subtitle
				{
					subtitle_user_id = User.Identity.GetUserId(), //get user id
					subtitle_video_id = video_id, 
					subtitle_file_path = file_name,
					subtitle_file_name = file_name,
					subtitle_date_created = DateTime.Now,
					subtitle_download_count = 0,
					subtitle_language = 0
				};
				subtitle_repo.add(subtitle);
				file.SaveAs(path);
			}
			return RedirectToAction("Profile","Video", new { id = video_id });
		}

        [HttpGet]
        public int GetCount()
        {
            var count = subtitle_comment_repo.get_subtitle_comments().Count();

            return count;
        }

        [HttpGet]
        public IEnumerable<subtitle_comment> get_comments_for_subtitle(int? id) 
        { 
            var comments = (from s in subtitle_comment_repo.get_subtitle_comments()
                            where s.sc_sub_id == id 
                            orderby s.sc_date_created
                            select s);

            return comments;
        }

        [HttpPost]
        public ActionResult post_comment(subtitle_comment d, int sub_id)
        {
            
            subtitle_comment c = new subtitle_comment 
            {
                sc_user_id = User.Identity.GetUserId(),
                sc_sub_id = sub_id,
                sc_comment = d.sc_comment,
                sc_date_created = DateTime.Now
            };
            subtitle_comment_repo.add(c);
            var repo = subtitle_comment_repo.get_subtitle_comments();

            return Json(repo, JsonRequestBehavior.AllowGet);
            }
    }
}
