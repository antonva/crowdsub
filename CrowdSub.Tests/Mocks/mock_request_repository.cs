using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Repositories;
using CrowdSub.Models;

namespace CrowdSub.Tests.Mocks
{
    public class mock_request_repository : i_request_repository
    {
        private readonly List<request> _request;
        public mock_request_repository(List<request> request)
        {
            _request = request;
        }

        public IQueryable<request> get_requests()
        {
            throw new NotImplementedException();
        }

        public bool create_request()
        {
            throw new NotImplementedException();
        }

        public bool edit_request()
        {
            throw new NotImplementedException();
        }

        public bool delete_request()
        {
            throw new NotImplementedException();
        }

        public bool get_request_by_user_id()
        {
            throw new NotImplementedException();
        }

        public bool get_request_by_request_id()
        {
            throw new NotImplementedException();
        }

        public int get_request_by_upvotes()
        {
            throw new NotImplementedException();
        }

        public int get_requests_count()
        {
            throw new NotImplementedException();
        }

        public bool show_all_fullfied_requests()
        {
            throw new NotImplementedException();
        }

        public bool show_all_not_fullfied_requests()
        {
            throw new NotImplementedException();
        }

        public bool request_is_fullfied()
        {
            throw new NotImplementedException();
        }

        public bool request_is_not_fullfied()
        {
            throw new NotImplementedException();
        }

        public List<request> request { get; set; }
    }
}
