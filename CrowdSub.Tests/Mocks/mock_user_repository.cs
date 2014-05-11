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
            return _users.AsQueryable();
        }
    }
}
