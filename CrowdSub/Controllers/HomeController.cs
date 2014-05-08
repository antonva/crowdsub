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
        public ActionResult Index()
        {
			//passes user to home page
			//home page must have:
			//actionLinks for topDownloads, topRequests, recentUploads, allRequests
			//searchBar with language filter

            return View();
        }

		public ActionResult search_for_title_or_user(string search_query) //View done
		{
			//search database for both user and title, populate list with corresponding results
			//send list to view as model, add razor declaration at the top

			return View();
		}


		[HttpGet]
		public ActionResult video_profile(int? video_id) //nullable id  //View done
		{
			//get title from video table, create video_profile_model
			//with the correct data and send it to the view
			//operations (buttons on the page):
			//edit subtitle
			//upload subtitle
			//download subtitle
			//export as different format (maybe at the moment)
			//request subtitle

			return View();
		}

		public ActionResult edit_subtitle(int? subtitle_id) //nullable id
		{
			//get subtitle from subtitle table, create edit_subtitle_model
			//with the correct data and send it to the view
			//operations:
			//save changes
			//submit comment

			return View();
		}

		public ActionResult upload_subtitle(int? video_id) //nullable id
		{
			//get video from video table, send title to view as a string
			//maybe show poster?
			//allow user to write in the version
			//browse for SRT file OR write subtitle in textedit (maybe at the moment)
			//press upload button, if subtitle exists for version
			//then this file will become the current version, else it will
			//become the first version

			return View();
		}

		[HttpGet]
		public ActionResult request_subtitle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult request_subtitle(int? video_id) //nullable id
		{
			//get video from video table, send title to view as a string
			//maybe show poster?
			//allow user to select version
			//then press submit

			return View();
		}

		[HttpGet]
		public ActionResult get_top_downloads()
		{
			//get 10 most downloaded subtitle files
			//using LINQ query

			return View();
		}

		[HttpGet]
		public ActionResult get_top_requests()
		{
			//get 10 most upvoted requests from database
			//using LINQ query

			return View();
		}

		[HttpGet]
		public ActionResult get_recent_uploads()
		{
			//get newest subtitles
			//using LINQ query

			return View();
		}

		[HttpGet]
		public ActionResult get_all_subtitles()
		{
			//get all subtitles
			//using LINQ query
			//maybe use paging?

			return View();
		}

		[HttpGet]
		public ActionResult get_all_requests()
		{
			//get all requests
			//using LINQ query
			//maybe use paging?

			return View();
		}

		[HttpGet]
		public ActionResult create_video_profile()
		{
			return View();
		}

		[HttpPost]
		public ActionResult create_video_profile(FormCollection form)
		{
			//user fills out form which contains
			//title, type (DropDown), year (DropDown),
			//imdb URL (auto fill-in maybe?), spoken language (DropDown)
			//create button will submit that shit

			//redirect user to the video profile he created
			return RedirectToAction("show_video_profile"); //add video id as second parameter
		}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Users()
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
		public ActionResult FAQ()
		{
			//show some frequently asked questions and the answer to
			//those questions, that shit is hardcoded mane

			return View();
		}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}