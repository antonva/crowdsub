using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public interface i_request_repository
    {
        IQueryable<request> get_requests()
        {
            //just for testing
            return db.requests;
        }

        //CRUD
        bool create_request();
        bool edit_request();
        bool delete_request();
        bool get_request_by_user_id();

        //Search
        bool get_request_by_request_id();
        int get_request_by_upvotes();

        //MISC
        int get_requests_count();
        bool show_all_fullfied_requests();
        bool show_all_not_fullfied_requests();
        bool request_is_fullfied();
        bool request_is_not_fullfied();
    }
}
