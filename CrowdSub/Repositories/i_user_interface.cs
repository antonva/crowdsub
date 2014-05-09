using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    interface i_user_interface
    {
        IQueryable<user> get_users();
    }
}
