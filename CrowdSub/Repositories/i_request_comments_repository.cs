using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public interface i_request_comments_repository
    {
        //comment
        IQueryable<request> get_comment();

        //get comments by user id
        bool get_comment_by_id();

        //edit comment by userid
        bool edit_comment_by_id();

        //delete comment by id
        bool delete_comment_by_id();




    }
}
