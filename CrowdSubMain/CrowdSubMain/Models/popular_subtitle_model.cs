using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSubMain.Models
{
    public class popular_subtitle_model
    {
        public IEnumerable<subtitle> subtitles { get; set; }
        public video video { get; set;}
        public int total_download_count { get; set; }
    }
}