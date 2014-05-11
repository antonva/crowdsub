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
    public class RequestController : Controller
    {
        private readonly i_request_repository request_repo;
        public RequestController(i_request_repository requests)
        {
            request_repo = requests;
        }
    }
}
