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
            return _videos.First(a => a.id == id);
        }

        public IQueryable<video> get_all_videos()
        {
            return _videos.AsQueryable();
        }
    }
}
