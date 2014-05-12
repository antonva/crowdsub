using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Models;
using System.Web.Mvc;

namespace CrowdSub.Repositories
{
    public interface i_request_repository
    {
        IQueryable<request> get_requests();
        request add(request req);
        request edit(int id, request req);
        bool del(int id);



        
    }
}
