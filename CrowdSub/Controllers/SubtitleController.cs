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
	public class SubtitleController : Controller
	{
		private readonly i_subtitle_repository subtitle_repo;

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
				return View("~/Views/Shared/could_not_be_found");
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
						 select s).DefaultIfEmpty();


			return View(model);
		}

		public ActionResult delete_subtitle(int id)
		{
			subtitle_repo.delete(id);
			var model = subtitle_repo.get_subtitles();

			return View(model);
		}

	}
}


