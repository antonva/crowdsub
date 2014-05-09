using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Repositories;
using CrowdSub.Models;
using CrowdSub.HelperClasses;

namespace CrowdSub.Tests.Mocks
{
    public class mock_video_repository : i_video_repository
    {
        private crowddbEntities db = new crowddbEntities();

        public bool create_video(video new_video)
        {

            if (search_for_video(new_video.id))
            {
                return false;
            }
            else 
            {
                db.videos.AddObject(new_video);
                return true;
            }
        }

        public bool edit_video(video new_video)
        {
            if (search_for_video(new_video.id))
            {
                return false;
            }
            else
            {
                db.videos.AddObject(new_video);
                return true;
            }
        }

        public bool remove_video(int id)
        {
            throw new NotImplementedException();
        }

        public video get_video(int id)
        {
            throw new NotImplementedException();
        }

        public List<video> get_all_videos()
        {
            throw new NotImplementedException();
        }

        bool search_for_video(int id)
        {
            if (db.videos.Search(id)) { return true; }
            else { return false; }
        }
    }
}
