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
        IQueryable<upvote> get_upvotes();
        upvote add(int request_id, int user_id);
        upvote remove(int request_id, int user_id);
    }
}
