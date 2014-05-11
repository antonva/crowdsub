using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Repositories;
using CrowdSub.Models;

namespace CrowdSub.Tests.Mocks
{
    public class mock_video_repository : i_video_repository
    {
        private readonly List<video> _videos;
        public mock_video_repository(List<video> videos)
        {
            _videos = videos;
        }

        public IQueryable<video> get_videos()
        {
            return _videos.AsQueryable();
        }

        public video add(video video)
        {
            _videos.Add(video);
            int id = _videos.OrderByDescending(x => x.id).First().id;
            return _videos.Where(x => x.id == id).FirstOrDefault();
        }


        public video edit(int id, System.Web.Mvc.FormCollection formdata)
        {
            throw new NotImplementedException();
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
