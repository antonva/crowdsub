﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrowdSubMain.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Group 12";

			return View();
		}

        [HttpGet]
        public ActionResult help()
        {
            return View();
        }

        [HttpGet]
        public ActionResult faq()
        {
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