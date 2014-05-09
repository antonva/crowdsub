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
        //test function which should return all requests in database
        IQueryable<request> get_requests();
    }
}
