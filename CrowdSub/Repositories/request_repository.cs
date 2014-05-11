using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public class request_repository : i_request_repository
    {
        //Connection to database
        private crowddbEntities db = new crowddbEntities();

        //Returns requests as a queriable linq object.
        public IQueryable<request> get_requests()
        {
            return db.requests;
        }
    }
}