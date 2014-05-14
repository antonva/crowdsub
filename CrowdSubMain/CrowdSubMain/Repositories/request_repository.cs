using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;
using System.Data.Entity;

namespace CrowdSubMain.Repositories
{
	public class request_repository : i_request_repository
	{
		private crowd_sub_context db = new crowd_sub_context();
		public IQueryable<Models.request> get_requests()
		{
			return db.requests;
		}

		public void add(request req)
		{
			db.requests.Add(req);
			db.SaveChanges();
		}

		public void edit(request request)
		{
            db.Entry(request).State = EntityState.Modified;
            db.SaveChanges();
		}

		public bool delete(request request)
		{
			if(request != null)
			{
				db.requests.Remove(request);
				db.SaveChanges();
				return true;
			}
			return false;
		}
	}
}