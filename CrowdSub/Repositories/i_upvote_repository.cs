using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public interface i_upvote_repository
    {
        IQueryable<upvote> get_upvote();

        int get_upvotes_by_requestid();
        
        bool create_upvote();

        //If the user has upvoted the subtitle, can he downvoted (unlike) it?
        //Takes in parameter for request id and user id
        bool has_user_upvote();
        
        bool delete_upvote();

        //Possibly a function which gets all the upvotes which the user has made
        //int get_upvotes_by_userid();

    }
}
