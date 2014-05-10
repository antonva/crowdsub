using CrowdSub.Models;
using CrowdSub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSub.Tests.Mocks
{
    class mock_request_comments_repository : i_request_comments_repository
    {
        //TODO: connect to database


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
