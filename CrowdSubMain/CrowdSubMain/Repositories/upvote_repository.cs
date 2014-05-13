using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Repositories
{
	public class upvote_repository : i_upvote_repository
	{
		private crowd_sub_context db = new crowd_sub_context();
		public IQueryable<Models.upvote> get_upvotes()
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