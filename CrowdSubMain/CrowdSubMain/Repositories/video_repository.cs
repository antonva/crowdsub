using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;
using System.Data.Entity;

namespace CrowdSubMain.Repositories
{
	public class video_repository : i_video_repository
	{
		private crowd_sub_context db = new crowd_sub_context();
		public IQueryable<Models.video> get_videos()
		{
			throw new NotImplementedException();
		}

		public void add(Models.video video)
		{
			db.videos.Add(video);
			db.SaveChanges();
		}

		public void edit(Models.video video)
		{
			db.Entry(video).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void delete(video video)
		{
			db.videos.Remove(video);
			db.SaveChanges();
		}
	}
}