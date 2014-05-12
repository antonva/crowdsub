using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdSub.Controllers
{
    public class HomeController : Controller
    {
		[HttpGet]
        public ActionResult index()
        {
			//passes user to home page
			//home page must have:
			//actionLinks for topDownloads, topRequests, recentUploads, allRequests
			//searchBar with language filter

            return View();
        }

        [HttpGet]
        public ActionResult about()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult users()
        {
            CrowdSub.Models.user u = new CrowdSub.Models.user();

            return View();
        }

		[HttpGet]
		public ActionResult help()
		{
			//show some help shit
			//that shit is hardcoded mane
			//coded so hard fffssttjj

			return View();
		}

		[HttpGet]
		public ActionResult faq()
		{
			//show some frequently asked questions and the answer to
			//those questions, that shit is hardcoded mane

			return View();
		}

		[HttpGet]
        public ActionResult contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult all_requests()
        {
            return View();
        }

        [HttpGet]
        public ActionResult top_downloads()
        {
            return View();
        }

        [HttpGet]
        public ActionResult recent()
        {
            return View();
        }

        [HttpGet]
        public ActionResult top_requests()
        {
            return View();
        }

    }
}