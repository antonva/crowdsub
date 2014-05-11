using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Repositories;
using CrowdSub.Models;

namespace CrowdSub.Tests.Mocks
{
    //comment
    class mock_upvote_repository : i_upvote_repository
    {
        private readonly List<upvote> _upvote;
		public mock_upvote_repository(List<upvote> upvotes)
		{
			_upvote = upvotes;
		}

        public IQueryable<upvote> get_upvotes()
        {
            throw new NotImplementedException();
        }

        public upvote add(int request_id, int user_id)
        {
            throw new NotImplementedException();
        }

        public upvote remove(int request_id, int user_id)
        {
            throw new NotImplementedException();
        }
    }
}
