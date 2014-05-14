using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain.Repositories; //Bætt við
using CrowdSubMain.Models; //Bætt við
using Microsoft.VisualStudio.TestTools.UnitTesting; //Bætt við
using CrowdSubMain.Controllers; //Bætt við

namespace CrowdSubMain.Tests.Mocks
{
    public class mock_request_repository : i_request_repository //Bætti við public
    {

        private readonly List<request> _requests;
        public mock_request_repository(List<request> requests)
        {
            _requests = requests;
        }

        public IQueryable<request> get_requests()
        {
            throw new NotImplementedException();
        }

        public void add(request req)
        {
            throw new NotImplementedException();
        }

        public void edit(request req)
        {
            throw new NotImplementedException();
        }

        public bool delete(request req)
        {
            throw new NotImplementedException();
        }
    }


} 


