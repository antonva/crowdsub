using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSub.Models
{
    public class top_downloads_model
    {
        public video video;
        public subtitle subtitles;
        public request requests; //bætti þessu við ATHUGA hvort það þurfi annað view model eða þetta í lagi?
    }
}