using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public class video_repository : i_video_repository
    {
        //Database connection.
        private crowddbEntities db = new crowddbEntities();

        public bool create_video(video new_video)
        {
            throw new NotImplementedException();
        }

        public bool edit_video(video new_video)
        {
            throw new NotImplementedException();
        }

        public bool remove_video(int id)
        {
            throw new NotImplementedException();
        }

        public video get_video(int id)
        {
            return db.videos.First(a =>a.id == id);
        }

        public IQueryable<video> get_all_videos()
        {
            return db.videos;
        }
    }
}