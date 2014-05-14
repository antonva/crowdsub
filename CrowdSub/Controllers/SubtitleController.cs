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
    enum subtitle_language_enum
    {
        English = 0,
        Icelandic = 1
    }
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
		public ActionResult profile(int id)
		{
			var model = (from s in subtitle_repo.get_subtitles()
						 where s.id == id
						 select s).FirstOrDefault();

			if (model == null) // if video profile does not exist
			{  // show user that the desired video profile could not be found
				return View("~/Views/Shared/Error.cshtml");
			}
			else
			{ // else return the appropriate video profile
				return View(model);
			}
		}

		public ActionResult subtitles_for_video(int video_id)
		{
			var model = (from s in subtitle_repo.get_subtitles()
						 where s.subtitle_video_id == video_id
						 select s);
			//if LINQ result is empty, we return error view
			if(!model.Any())
			{
				Debug.WriteLine("List is empty!");
				return View("~/Views/Shared/Error.cshtml");
			}

			return View(model);
		}

		public ActionResult delete_subtitle(int id)
		{
			subtitle_repo.delete(id);
			var model = subtitle_repo.get_subtitles();

			return View(model);
		}

        [HttpGet]
        public ActionResult edit_subtitle(int id)
        {
            var model = (from v in subtitle_repo.get_subtitles()
                         where v.id == id
                         select v).First();
            if(model.subtitle_language == 1)
            {
                model.subtitle_language = (int)subtitle_language_enum.Icelandic;
            }
            else
            {
                model.subtitle_language = (int)subtitle_language_enum.English;
            }
            
                

            return View(model);
        }


	}
}


