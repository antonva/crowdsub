using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain.Repositories; //Bætti við
using CrowdSubMain.Models; //Bætti við

namespace CrowdSubMain.Tests.Mocks
{
    public class mock_video_repository : i_video_repository //Bætti við public
    {
        private readonly List<video> _videos;
        public mock_video_repository(List<video> videos)
        {
            _videos = videos;
        }

        public IQueryable<video> get_videos()
        {
            throw new NotImplementedException();
        }

        public void add(video video)
        {
            throw new NotImplementedException();
        }

        public void edit(video video)
        {
            throw new NotImplementedException();
        }

        public void delete(video video)
        {
            throw new NotImplementedException();
        }
    }
}
