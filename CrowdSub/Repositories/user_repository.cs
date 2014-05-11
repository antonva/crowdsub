using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public class user_repository : i_user_repository
    {
        private crowddbEntities db = new crowddbEntities();

        public IQueryable<user> get_users()
        {
            return db.users;
        }
    }
}