using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Repositories;
using CrowdSub.Models;

namespace CrowdSub.Tests.Mocks
{
    public class mock_user_repository : i_user_repository
    {
        private readonly List<user> _users;
        public mock_user_repository(List<user> users)
        {
            _users = users;
        }

        public IQueryable<user> get_users()
        {
            //just for testing..
            return _users.AsQueryable();
        }

        public bool create_user(user new_user)
        {
 	        throw new NotImplementedException();
        }

        public bool edit_user(int id)
        {
 	        throw new NotImplementedException();
        }

        public bool delete_user(int id)
        {
 	        throw new NotImplementedException();
        }

        public user get_user_by_name(string name)
        {
 	        throw new NotImplementedException();
        }

        public user get_user_by_id(int id)
        {
 	        throw new NotImplementedException();
        }

        public user get_user_by_email(string email)
        {
 	        throw new NotImplementedException();
        }

        public int get_user_count()
        {
 	        throw new NotImplementedException();
        }

        public int get_user_subtitles()
        {
 	        throw new NotImplementedException();
        }

        public int get_user_requests()
        {
 	        throw new NotImplementedException();
        }
        
public  List<user> users { get; set; }}
}
