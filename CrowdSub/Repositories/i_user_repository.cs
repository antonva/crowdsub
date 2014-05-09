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
        bool create_user(user new_user);
        bool edit_user(int id);
        bool delete_user(int id);
        
        //Search
        user get_user_by_name(string name);
        user get_user_by_id(int id);
        user get_user_by_email(string email);

        //Misc
        int get_user_count();
        int get_user_subtitles();
        int get_user_requests();
    }
}
