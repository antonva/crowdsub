using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSubMain.Repositories
{
	public class upvote_repository : i_upvote_repository
	{
		public IQueryable<Models.upvote> get_upvotes()
		{
			throw new NotImplementedException();
		}

		public bool add(int request_id, int user_id)
		{
			throw new NotImplementedException();
		}

		public bool delete(int upvote_id)
		{
			throw new NotImplementedException();
		}
	}
}