using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Models;
using System.Web.Mvc;


namespace CrowdSub.Repositories
{
    public interface i_video_repository
    {
        IQueryable<video> get_videos();
        video add(video video);
        video edit(int id, video video);
        bool delete(int id);
    }
}
