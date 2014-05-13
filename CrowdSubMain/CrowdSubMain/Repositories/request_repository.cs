using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Repositories
{
	public class request_repository : i_request_repository
	{
		private crowd_sub_context db = new crowd_sub_context();
		public IQueryable<Models.request> get_requests()
		{
			return db.requests;
		}

		public bool add(Models.request req)
		{
			throw new NotImplementedException();
		}

		public bool edit(Models.request req)
		{
			throw new NotImplementedException();
		}

		public bool delete(int id)
		{
			int? request_id = db.requests.Where(x => x.id == id).FirstOrDefault().id;
			if(request_id == null)
			{
				var request_del = (from r in db.requests
								   where r.id == id
								   select r).FirstOrDefault();
				db.requests.Remove(request_del);
				db.SaveChanges();
				return true;
			}
			return false;
		}
	}
}