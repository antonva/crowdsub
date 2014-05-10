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
        public VideoController(i_video_repository videos)
        {
            video_repo = videos;
        }

        public ActionResult profile(int id)
        {
            var model = video_repo.get_video(id);
            return View(model);
        }

        public ActionResult search(string query)
        {
            var model = from v in video_repo.get_all_videos()
                        where v.video_title.Contains(query)
                        select v;

            return View(model);
        }

        public ActionResult create_video(video newvideo)
        {
            return View();
        }


        // Help class
        // Searches for exact video profile title.

        public bool is_unique_video_title(string query)
        {
            var result = from v in video_repo.get_all_videos()
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
