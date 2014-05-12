using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSub.Models;
using System.Web.Mvc;

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


        public request add(request req)
        {
            throw new NotImplementedException();
        }


        public request edit(int id, request req)
        {
            throw new NotImplementedException();
        }

        public bool del(int id)
        {
            int? request_id = db.requests.Where(x => x.id == id).FirstOrDefault().id;
            if(request_id != null)
            {
                var request_del = (from r in db.requests
                                   where r.id == id
                                    select r).FirstOrDefault();
                db.requests.Remove(request_del);
                db.SaveChanges();

                return true;
            }
            return false;
        }
    }
}