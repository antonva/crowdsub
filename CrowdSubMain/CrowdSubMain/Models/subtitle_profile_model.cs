using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Models
{
    public class subtitle_profile_model
    {
        public subtitle subtitle { get; set; }
        public string srt_string { get; set; }
        public IEnumerable<subtitle_comment> subtitle_comments { get; set; }
    }
}