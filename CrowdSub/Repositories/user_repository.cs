using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public class user_repository : i_user_repository
    {
        //TODO: connect to database
        private crowddbEntities db = new crowddbEntities();

        public IQueryable<user> get_users()
        {
            //just for testing..
            return db.users;
        }
        //CRUD
		public bool create_user(user new_user)
        {
            return true;
        }
		public bool edit_user(int id)
        {
            return true;
        }
		public bool delete_user(int id)
        {
            return true;
        }
        //Search
		public user get_user_by_name(string name)
        {
            return null;
        }
		public user get_user_by_id(int id)
        {
            return null;
        }
		public user get_user_by_email(string email)
        {
            return null;
        }
        //Misc
		public int get_user_count()
        {
            return 0;
        }
		public int get_user_subtitles()
        {
            return 0;
        }
		public int get_user_requests()
        {
            return 0;
        }
    }
}