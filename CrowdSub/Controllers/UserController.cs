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
    public class UserController : Controller
    {
        private readonly i_user_repository user_repo;

        // Normal constructor.
        public UserController()
        {
            var users = new user_repository();
            user_repo = users;
        }

        // Test constructor, takes a repository as argument.
        public UserController(i_user_repository users)
        {
            user_repo = users;
        }

        // GET: /User/
        public ActionResult index()
        {
            var model = (from u in user_repo.get_users()
                          orderby u.user_name descending
                          select u).Take(12);

            return View(model);
        }
    }
}
