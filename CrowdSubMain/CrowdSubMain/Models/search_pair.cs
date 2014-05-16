using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.DAL;
using CrowdSubMain.Models;

namespace CrowdSubMain.Models
{
    /*Main purpose of this class it so we can have access to both
     * videos and subtitles in a view*/
    public class search_pair
    {
        public List<subtitle> subtitle_pair { get; set; }
        public video video_pair { get; set; }
    }
}