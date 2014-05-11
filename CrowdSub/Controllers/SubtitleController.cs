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

        public ActionResult profile(int id)
        {
			var model = (from s in subtitle_repo.get_subtitles()
						 where s.id == id
						 select s).FirstOrDefault();

			return View(model);
        }
    }
}
