using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Repositories
{
	public class video_repository : i_video_repository
	{
        private crowd_sub_context db = new crowd_sub_context();

        public IQueryable<video> get_videos()
		{
            return db.videos;
		}

		public void add(video video)
		{
            db.videos.Add(video);
            db.SaveChanges();
		}

		public void edit(video video)
		{
			throw new NotImplementedException();
		}

		public bool delete(int id)
		{
            video video_to_delete = db.videos.Where(x => x.id == id).FirstOrDefault();
            if (video_to_delete != null)
            {
                var video_del = (from v in db.videos
                                 where v.id == id
                                 select v).FirstOrDefault();

                db.videos.Remove(video_del);
                db.SaveChanges();

                return true;
            }
            return false;
		}
	}
}