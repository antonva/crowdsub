using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrowdSubMain.Models;
using CrowdSubMain.Repositories;
using System.Diagnostics;
using Microsoft.AspNet.Identity;

namespace CrowdSubMain.Controllers
{
    [HandleError]
    public class VideoController : Controller
    {
		private readonly i_video_repository video_repo;
        private readonly i_subtitle_repository subtitle_repo;
		private readonly i_request_repository request_repo;

		// Normal Constructor
		public VideoController()
		{
			video_repository videos = new video_repository();
            subtitle_repository subtitles = new subtitle_repository();
			request_repository requests = new request_repository();
			video_repo = videos;
            subtitle_repo = subtitles;
			request_repo = requests;
		}

		// Test constructor, takes a repository as argument.
		public VideoController(i_video_repository videos)
		{
			video_repo = videos;
		}

        [HandleError]
		public ActionResult Profile(int id)
		{
            //TODO: check valid id and redirect to 404
			var _video = (from v in video_repo.get_videos()
						 where v.id == id
						 select v).FirstOrDefault();
            if (video == null)
            {
                return View("~/Error");
            }

            var _subtitles = subtitle_for_video(id); //get subtitles for video
			var _requests = requests_for_video(id); //get requests for video
            var model = new profile_view_model 
			{
				video = _video,
				subtitles = _subtitles,
				requests = _requests
			};

			return View(model);
		}

        [HandleError]
		public ActionResult search(string search, string language)
		{
			Debug.WriteLine("query: " + search);
            Debug.WriteLine("language: " + language);

            
            

            if(language == "null") /* if no specific language is selected*/
            {
                List<search_pair> search_pairs = new List<search_pair>();

                IEnumerable<video> video_enum = (from v in video_repo.get_videos()
                                                 where v.video_title.Contains(search)
                                                 select v);
                List<video> videos = video_enum.ToList();

                foreach (var video in videos)
                {
                    IEnumerable<subtitle> subtitle_enum = (from s in subtitle_repo.get_subtitles()
                                                           where s.subtitle_video_id == video.id
                                                           select s);
                    List<subtitle> subtitles = subtitle_enum.ToList();
                    search_pairs.Add(new search_pair
                    {
                        video_pair = video,
                        subtitle_pair = subtitles
                    });
                }
                video_language_search model = new video_language_search { search_pairs = search_pairs };
                return View(model);                 
            }
            else
            {
                List<search_pair> search_pairs = new List<search_pair>();

                IEnumerable<video> video_enum = (from v in video_repo.get_videos()
                                                 where v.video_title.Contains(search)
                                                 select v);

                List<video> videos = video_enum.ToList();
                foreach (var video in videos)
                {
                    IEnumerable<subtitle> subtitle_enum = (from s in subtitle_repo.get_subtitles()
                                                           where s.subtitle_video_id == video.id
                                                           where s.subtitle_language.Contains(language)
                                                           select s);
                    List<subtitle> subtitles = subtitle_enum.ToList();


                    search_pairs.Add(new search_pair
                    {
                        video_pair = video,
                        subtitle_pair = subtitles
                    });
                }
                video_language_search model = new video_language_search { search_pairs = search_pairs };
                return View(model);
            }

         
		}

        [HandleError]
        public ActionResult top_downloads() 
        {
            var model = (from v in video_repo.get_videos()
                        orderby v.requests
                        select v);

            return View();
        }

        [HandleError]
        public IEnumerable<subtitle> subtitle_for_video(int id) 
        {
            var model = (from v in subtitle_repo.get_subtitles()
                        where v.subtitle_video_id == id
                        select v).ToList();

            return model;
        }

		public IEnumerable<request> requests_for_video(int id)
		{
			var model = (from r in request_repo.get_requests()
						 where r.request_video_id == id
						 select r).ToList();
			return model;
		}

        /* // GET: /Video/
        public ActionResult Index()
        {
            return View(db.videos.ToList());
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
        } */

        // GET: /Video/Create 
        [Authorize]    
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Movie", Value = "Movie" });
            items.Add(new SelectListItem { Text = "Tv-Show", Value = "Tv-Show" });
            items.Add(new SelectListItem { Text = "Other", Value = "Other" });

            ViewBag.items = items;

            return View();
        }

        // POST: /Video/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize] 
        public ActionResult Create([Bind(Include="id,video_created_by_user_id,video_title,video_type,video_year_published,video_date_created,video_date_updated,video_description,poster_link")] video video)
        {
            if (ModelState.IsValid)
            {
                string user_id = User.Identity.GetUserId(); // Get the user id
                string user_name = User.Identity.GetUserName();
                video.video_created_by_user_id = user_id;   // Add the user id to the video object
                video.video_date_created = DateTime.Now;    // Add current time to the object being created
                video.video_date_updated = DateTime.Now;    // Add curretn time to the object being created

                if (video.poster_link == null) 
                {
                    video.poster_link = "http://ia.media-imdb.com/images/M/MV5BODg0NjQ5ODQ3OF5BMl5BanBnXkFtZTcwNjU4MjkzNA@@._V1_SX300.jpg";
                }

				video_repo.add(video); // Add video to repo
                
                return RedirectToAction("Profile", new { id = video.id});
            }

            return View(video);
        }

        // GET: /Video/Edit/5
        [Authorize] 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			video video = video_repo.get_videos().Where(x => x.id == id).FirstOrDefault();
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: /Video/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize] 
        public ActionResult Edit([Bind(Include="id,video_created_by_user_id,video_title,video_type,video_year_published,video_date_created,video_date_updated,video_description, poster_link")] video video)
        {
            string user_id = User.Identity.GetUserId(); // Get the user id
            string user_name = User.Identity.GetUserName();
            video.video_created_by_user_id = user_id;   // Add the user id to the video object
            video.video_date_created = DateTime.Now;    // Add current time to the object being created
            video.video_date_updated = DateTime.Now;    // Add curretn time to the object being created

            if (video.poster_link == null)
            {
                video.poster_link = "http://ia.media-imdb.com/images/M/MV5BODg0NjQ5ODQ3OF5BMl5BanBnXkFtZTcwNjU4MjkzNA@@._V1_SX300.jpg";
            }

            video_repo.edit(video); // Add video to repo

            return RedirectToAction("Profile", new { id = video.id });
        }

        // GET: /Video/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			video video = video_repo.get_videos().Where(x => x.id == id).FirstOrDefault();
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: /Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
			video video = video_repo.get_videos().Where(x => x.id == id).FirstOrDefault();
			video_repo.delete(video);
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
