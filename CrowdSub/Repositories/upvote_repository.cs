using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public class upvote_repository : i_upvote_repository
    {
        //comment
        public IQueryable<upvote> get_upvotes()
        {
            throw new NotImplementedException();
        }

        public int get_upvotes_by_requestid()
        {
            throw new NotImplementedException();
        }

        public bool create_upvote()
        {
            throw new NotImplementedException();
        }

        public bool has_user_upvoted()
        {
            throw new NotImplementedException();
        }

        public bool delete_upvote()
        {
            throw new NotImplementedException();
        }

        public int get_upvotes_by_userid()
        {
            throw new NotImplementedException();
        }


        public upvote add(int request_id, int user_id)
        {
            throw new NotImplementedException();
        }

        public upvote remove(int request_id, int user_id)
        {
            throw new NotImplementedException();
        }
    }
}