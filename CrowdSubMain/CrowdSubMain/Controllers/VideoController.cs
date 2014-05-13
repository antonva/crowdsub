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
    public class VideoController : Controller
    {
		private readonly i_video_repository video_repo;

		// Normal Constructor
		public VideoController()
		{
			video_repository videos = new video_repository();
			video_repo = videos;
		}

		// Test constructor, takes a repository as argument.
		public VideoController(i_video_repository videos)
		{
			video_repo = videos;
		}

		public ActionResult Profile(int id)
		{
			var model = (from v in video_repo.get_videos()
						 where v.id == id
						 select v).First();
			return View(model);
		}

		public ActionResult search(string query)
		{
			Debug.WriteLine("query: " + query);

			var model = from v in video_repo.get_videos()
						where v.video_title.Contains(query)
						select v;

			return View(model);
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

        [HttpGet]    
        public ActionResult CreateSearch() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSearch(string query)
        {
            
            return View();
        }

        // GET: /Video/Create
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
        public ActionResult Create([Bind(Include="id,video_created_by_user_id,video_title,video_type,video_year_published,video_date_created,video_date_updated,video_description")] video video)
        {
            if (ModelState.IsValid)
            {
                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Movie", Value = "Movie" });
                items.Add(new SelectListItem { Text = "Tv-Show", Value = "Tv-Show" });
                items.Add(new SelectListItem { Text = "Other", Value = "Other" });

                ViewBag.items = items;

                string user_id = User.Identity.GetUserId(); // Get the user id
                string user_name = User.Identity.GetUserName();
                video.video_created_by_user_id = user_id;   // Add the user id to the video object
                video.video_date_created = DateTime.Now;    // Add current time to the object being created
                video.video_date_updated = DateTime.Now;    // Add curretn time to the object being created

				video_repo.add(video); // Add video to repo
                
                return RedirectToAction("Profile", new { id = video.id});
            }

            return View(video);
        }

        // GET: /Video/Edit/5
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
        public ActionResult Edit([Bind(Include="id,video_created_by_user_id,video_title,video_type,video_year_published,video_date_created,video_date_updated,video_description")] video video)
        {
            if (ModelState.IsValid)
            {
				video_repo.edit(video);
                return RedirectToAction("Index");
            }
            return View(video);
        }

        // GET: /Video/Delete/5
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
