using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
    public interface i_video_repository
    {
        // CRUD
        bool create_video(video new_video);
        bool edit_video(video new_video);
        bool remove_video(int id);

        // Returns video or videos
        video get_video(int id);
        List<video> get_all_videos();

        // Search for video
        bool search_for_video(int id);
    }
}
