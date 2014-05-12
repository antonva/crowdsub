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
            var model = from v in video_repo.get_videos()
                        where v.video_title.Contains(query)
                        select v;

            return View(model);
        }

        public ActionResult create_video(FormCollection formdata)
        {
            video model = new video();
            var q = video_repo.get_videos();
            
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
