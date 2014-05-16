using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Models
{
    public class video_language_search
    {
        public IEnumerable<search_pair> search_pairs { get; set; }
        public string language_parameter { get; set; }
        //public int english_subtitle_count { get; set; }
        //public int icelandic_subtitle_count { get; set; }
    }
}