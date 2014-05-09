using CrowdSub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSub.Repositories
{
    public class request_comments_repository : i_request_comments_repository 
    {
        //TODO: connect to database
        private crowddbEntities db = new crowddbEntities();

        public IQueryable<Models.request> get_comment()
        {
            throw new NotImplementedException();
        }

        public bool get_comment_by_id()
        {
            throw new NotImplementedException();
        }

        public bool edit_comment_by_id()
        {
            throw new NotImplementedException();
        }

        public bool delete_comment_by_id()
        {
            throw new NotImplementedException();
        }
    }
}