using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSub.Models
{
    public class video_profile_model
    {
        public video video;
        public IEnumerable<subtitle> subtitles;
    }
}