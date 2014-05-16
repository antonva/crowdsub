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
using Microsoft.AspNet.Identity;

namespace CrowdSubMain.Controllers
{
    public class RequestController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private readonly i_request_repository request_repo;

		// Normal constructor.
		public RequestController()
		{
			var requests = new request_repository();
			request_repo = requests;
		}

		// Test constructor, takes a repository as argument.
		public RequestController(i_request_repository requests)
		{
			request_repo = requests;
		}

        // GET: /Request/
        public ActionResult Index()
        {
            return View(request_repo.get_requests().ToList());
        }

        // GET: /Request/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            request request = request_repo.get_requests().Where(x => x.id == id).FirstOrDefault();
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: /Request/Create
        public ActionResult Create(int video_id)
        {
			var request = new request();
			request.request_video_id = video_id;
            return View(request);
        }

        // POST: /Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize]
        [HttpPost]
        public ActionResult Create(string request_lang, int video_id)
        {
			var request = new request
			{
				request_user_id = User.Identity.GetUserId(),
				request_video_id = video_id,
				request_language = request_lang,
				request_date_created = DateTime.Now,
				request_date_updated = DateTime.Now
			};
            if (ModelState.IsValid)
            {
                request_repo.add(request);
                return RedirectToAction("Profile", "Video", new { id = video_id});
            }

            return RedirectToAction("Profile", "Video", new { id = video_id});
        }

        // GET: /Request/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            request request = request_repo.get_requests().Where(x => x.id == id).FirstOrDefault();
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: /Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,request_user_id,request_lang,request_video_id,request_date_created")] request request)
        {
            if (ModelState.IsValid)
            {
                request_repo.edit(request);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // GET: /Request/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            request request = request_repo.get_requests().Where(x => x.id == id).FirstOrDefault();
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: /Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            request request = request_repo.get_requests().Where(x => x.id == id).FirstOrDefault();
            request_repo.delete(request);
            return RedirectToAction("Index");
        }

        public ActionResult recent_requests() 
        {
            var model = (from r in request_repo.get_requests()
                        orderby r.request_date_created
                        select r).ToList().Take(10);

            return View(model);
        }
    }
}
