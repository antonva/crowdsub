using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Repositories
{
	public interface i_request_repository
	{
		IQueryable<request> get_requests();
		void add(request req);
		bool edit(request req);
		bool delete(int id);
	}
}
