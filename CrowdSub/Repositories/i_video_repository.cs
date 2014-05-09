using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSub.Repositories
{
    interface i_video_repository
    {
        bool create_video();
        bool edit_video();
        bool get_video();
        bool get_all_videos();
        bool remove_video();
        bool search_for_video();
    }
}
