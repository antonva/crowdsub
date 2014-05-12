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
using System.Diagnostics;

namespace CrowdSub.Controllers
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

        public ActionResult profile(int id)
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

        [HttpPost]
        public ActionResult create_video(FormCollection formdata)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Movie", Value = "Movie" });
            items.Add(new SelectListItem { Text = "Tv-Show", Value = "Tv-Show" });
            items.Add(new SelectListItem { Text = "Other", Value = "Other" });

            ViewBag.items = items;

            video new_video = new video();
            
            new_video.video_title = Convert.ToString(Request.Form["Title"]);
            new_video.video_type = Convert.ToString(Request.Form["Type"]);
            new_video.video_description = Convert.ToString(Request.Form["Description"]);
            new_video.video_created_by_user_id = 69;

            video_repo.add(new_video);
            
            RedirectToAction("Create");

            return View(new_video);
        }

        [HttpGet]
        public ActionResult create_video() 
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Movie", Value = "Movie" });
            items.Add(new SelectListItem { Text = "Tv-Show", Value = "Tv-Show" });
            items.Add(new SelectListItem { Text = "Other", Value = "Other" });

            ViewBag.items = items;

            return View();
        }

        public ActionResult delete_video(int id) 
        {
            video_repo.delete(id);
            var model = video_repo.get_videos();

            return View(model);
        }


        // Help class
        // Searches for exact video profile title.

        public bool is_unique_video_title(string query)
        {
            var result = from v in video_repo.get_videos()
                         where v.video_title.Equals(query)
                         select v;

            if (result.Count() == 0)
            {
                return true;
            }
            return false;
        }
    }
}
