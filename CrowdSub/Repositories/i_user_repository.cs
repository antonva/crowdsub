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
        //TODO: connect to database

        public IQueryable<user> get_subtitles()
        {
            //just for testing..
            return null;
        }
    }
}
