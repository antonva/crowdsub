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
    }
}
