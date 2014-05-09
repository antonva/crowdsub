using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public class request_repository : i_request_repository
    {
        //TODO: connect to database

        public IQueryable<request> get_requests()
        {
            //just for testing...
            return null;
        }
    }
}