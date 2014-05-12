using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Repositories;
using CrowdSub.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrowdSub.Controllers;




namespace CrowdSub.Tests.Mocks
{
    public class mock_request_repository : i_request_repository
    {
        private readonly List<request> _requests;
		public mock_request_repository(List<request> requests)
		{
			_requests = requests;
		}

        public IQueryable<request> get_requests()
        {
            return _requests.AsQueryable();
        }


        public request add(request req)
        {
            _requests.Add(req);
            int id = _requests.OrderByDescending(x => x.id).First().id;
            return _requests.Where(x => x.id == id).FirstOrDefault();
        }

        public request edit(int id, request req)
        {
            throw new NotImplementedException();
        }

        public bool del(int id)
        {
            //var req = (from r in _requests
            //           where r.id == id
            //           select r).FirstOrDefault();

            //_requests.Remove(req);

            //return true;
            throw new NotImplementedException();
        }
    }
}
