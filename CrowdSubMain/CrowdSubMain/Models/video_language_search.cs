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
        //public IEnumerable<subtitle> subtitles { get; set; }
        //public IEnumerable<video> videos { get; set; }
        public IEnumerable<search_pair> search_pairs { get; set; }
    }
}