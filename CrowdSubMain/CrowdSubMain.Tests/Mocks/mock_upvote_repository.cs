using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain.Repositories; //Bætti við
using CrowdSubMain.Models; //Bætti við



namespace CrowdSubMain.Tests.Mocks
{
    public class mock_upvote_repository : i_upvote_repository  //Bætti við public
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

        public void add(int request_id, int user_id)
        {
            throw new NotImplementedException();
        }

        public bool delete(int upvote_id)
        {
            throw new NotImplementedException();
        }
    }
    
}
