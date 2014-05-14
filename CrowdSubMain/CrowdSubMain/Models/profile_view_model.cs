using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Models
{
    public class profile_view_model
    {
        public video video { get; set; }
        public IEnumerable<subtitle> subtitles { get; set; }
    }
}