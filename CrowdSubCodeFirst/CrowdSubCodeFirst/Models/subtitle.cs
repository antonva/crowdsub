using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSubCodeFirst.Models
{
	public class subtitle
	{
		public int id { get; set; }
		public int subtitle_user_id { get; set; }
		public int subtitle_video_id { get; set; }
		public string subtitle_file_path { get; set; }
		//public int subtitle_version_is_active { get; set; } MAYBE
		//public int subtitle_version { get; set; } MAYBE
		public System.DateTime subtitle_date_created { get; set; }
		public int subtitle_download_count { get; set; }
		public int subtitle_language { get; set; }

		public virtual ICollection<subtitle_comment> subtitle_comments { get; set; }
		public virtual ApplicationUser user { get; set; }
		public virtual video video { get; set; }
	}
}