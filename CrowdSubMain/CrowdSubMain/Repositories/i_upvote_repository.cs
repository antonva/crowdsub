using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Repositories
{
	interface i_upvote_repository
	{
		IQueryable<upvote> get_upvotes();
		bool add(int request_id, int user_id);
		bool delete(int upvote_id);
	}
}
