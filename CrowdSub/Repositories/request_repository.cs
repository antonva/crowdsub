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
        public IQueryable<request> get_requests()
        {
            //just for testing
            return db.requests;
        }

        public bool create_request(request create_request)
        {
            throw new NotImplementedException();
        }

        public bool edit_request(request edited_request)
        {
            throw new NotImplementedException();
        }

        public bool delete_request()
        {
            throw new NotImplementedException();
        }

        public bool get_request_by_user_id()
        {
            throw new NotImplementedException();
        }

        public bool get_request_by_request_id()
        {
            throw new NotImplementedException();
        }

        public int get_request_by_upvotes()
        {
            throw new NotImplementedException();
        }

        public int get_requests_count()
        {
            throw new NotImplementedException();
        }

        public bool show_all_fullfied_requests()
        {
            throw new NotImplementedException();
        }

        public bool show_all_not_fullfied_requests()
        {
            throw new NotImplementedException();
        }

        public bool request_is_fullfied()
        {
            throw new NotImplementedException();
        }

        public bool request_is_not_fullfied()
        {
            throw new NotImplementedException();
        }
    }
}