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

        public IQueryable<video> get_videos()
        {
            return db.videos;
        }
    }
}