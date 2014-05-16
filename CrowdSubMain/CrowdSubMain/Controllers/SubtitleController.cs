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

		public FileResult download(int subtitle_id)
		{
			var subtitle = (from s in subtitle_repo.get_subtitles()
							 where s.id == subtitle_id
							 select s).First();
			var file_name = subtitle.subtitle_file_name;
			subtitle.subtitle_download_count++; //increment download count
			subtitle_repo.edit(subtitle); //update download count in database
			var file_path = Path.Combine(Server.MapPath("~/App_Data/uploads"), file_name);
			var file = File(file_path, System.Net.Mime.MediaTypeNames.Text.Plain, file_name);
			return file;
		}
        
        /* Returns subtitle info, comments and text as string.
         * srt_parser_menu.js handles rendering the srt text 
         * into editable text blocks.
         */
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

		/* Edit function that overwrites srt file with new content. */
		public void update_subtitle(string new_srt, int subtitle_id)
		{
			var file_name = (from s in subtitle_repo.get_subtitles()
							 where s.id == subtitle_id
							 select s).First().subtitle_file_name;
			var file_path = Path.Combine(Server.MapPath("~/App_Data/uploads"), file_name);
			using(StreamWriter writer = new StreamWriter(file_path, false, Encoding.UTF8))
			{
				writer.Write(new_srt);
			}
		}


        /* Deletes selected subtitle. */
        public ActionResult delete(int? id)
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
		public ActionResult Upload(HttpPostedFileBase file, string language, int video_id)
		{
			if (file.ContentLength > 0)
			{
				 /* var video_name = (from v in video_repo.get_videos()
								  where v.id == video_id
								  select v).First().video_title; //get title of video */
				var file_name = Path.GetFileName(file.FileName);
				Debug.WriteLine("File name: " + file_name.ToString());
				var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), file_name);
				Debug.WriteLine("File path: " + path.ToString());
				var subtitle = new subtitle
				{
					subtitle_user_id = User.Identity.GetUserId(), //get user id
					subtitle_video_id = video_id, 
					subtitle_file_name = file_name,
					subtitle_date_created = DateTime.Now,
					subtitle_date_updated = DateTime.Now,
					subtitle_download_count = 0,
					subtitle_language = language
				};
				subtitle_repo.add(subtitle);
				file.SaveAs(path);
			}
			return RedirectToAction("Profile","Video", new { id = video_id });
		}

        [HttpGet]
        public int GetCount(int subtitle_id)
        {
            var comments = from v in subtitle_comment_repo.get_subtitle_comments()
                           where v.sc_sub_id == subtitle_id
                           select v;

            Debug.WriteLine(comments.Count());
            return comments.Count();
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
        [Authorize]
        public ActionResult post_comment(subtitle_comment d)
        {
            subtitle_comment c = new subtitle_comment 
            {
                sc_user_id = User.Identity.GetUserId(),
                sc_sub_id = d.sc_sub_id,
                sc_comment = d.sc_comment,
                sc_date_created = DateTime.Now
            };

            var model = new { 
                subtitle_comment = c.sc_comment, 
                user_name = User.Identity.GetUserName(),
                date_created = c.sc_date_created
            };

            subtitle_comment_repo.add(c);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /*
        [HttpPost]
        [Authorize]
        public ActionResult delete_comment(int comment_id, int subtitle_id) 
        {
            var comment_to_delete = (from c in subtitle_comment_repo.get_subtitle_comments()
                                    where c.id == comment_id
                                    select c).SingleOrDefault();

            if (comment_to_delete == null)
            {
                RedirectToAction("subtitle_profile", "subtitle", new { id = subtitle_id });
            }

            subtitle_comment_repo.delete(comment_to_delete);
            var repo = subtitle_comment_repo.get_subtitle_comments();
            
            return Json(repo, JsonRequestBehavior.AllowGet);
        }
        */
    }
}
