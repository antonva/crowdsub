using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public interface i_user_repository
    {
        IQueryable<user> get_users();
        
        //CRUD
        bool create_user();
        bool edit_user();
        bool delete_user();
        bool get_user_by_id();

        //Search
        

        //Misc
        int get_user_count();
    }
}
