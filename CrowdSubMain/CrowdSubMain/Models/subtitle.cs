using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSubMain.Models
{
	public class subtitle
	{
		public int id { get; set; }
		public string subtitle_user_id { get; set; }
		public int subtitle_video_id { get; set; }
		public string subtitle_file_name { get; set; }
		public System.DateTime subtitle_date_created { get; set; }
        public System.DateTime subtitle_date_updated { get; set; }
		public int subtitle_download_count { get; set; }
		public string subtitle_language { get; set; }
        
		public virtual ICollection<subtitle_comment> subtitle_comments { get; set; }
		public virtual ApplicationUser user { get; set; }
		public virtual video video { get; set; }
	}
}