﻿using System;
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
    public class RequestController : Controller
    {
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

        public ActionResult create(FormCollection formdata)
        {
            //TODO....
            var model = request_repo.get_requests();

            return View(model);
        }

        public ActionResult edit(int id, FormCollection formdata)
        {
            //TODO....
           // request_repo.edit(id, formdata);
            var model = request_repo.get_requests();

            return View(model);
        }

        public ActionResult delete(int request_id)
        {
            request_repo.del(request_id);

            var model = request_repo.get_requests();

            return View(model);
        }

        public ActionResult add_upvote(int user_id)
        {
            return View();
        }

        public ActionResult remove_upvote(int user_id)
        {
            return View();
        }

        public int id { get; set; }
    }
}
