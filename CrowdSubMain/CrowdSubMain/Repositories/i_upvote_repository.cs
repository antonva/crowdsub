using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Repositories
{
	public interface i_upvote_repository
	{
		IQueryable<upvote> get_upvotes();
		void add(int request_id, int user_id);
		bool delete(int upvote_id);
	}
}
