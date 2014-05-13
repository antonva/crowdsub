using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSubMain.Models
{
	public enum language
	{
		English = 0,
		Icelandic = 1
	}

	public class request
	{
		public int id { get; set; }
		public int request_user_id { get; set; }
		//public string request_name { get; set; } WAT
		//public string request_link { get; set; } MAYBE
		public language request_lang { get; set; }
		public int request_video_id { get; set; }
		public System.DateTime request_date_created { get; set; }
		//public int request_type { get; set; } MAYBE

		public virtual ApplicationUser user { get; set; }
		public virtual video video { get; set; }
		public virtual ICollection<upvote> upvotes { get; set; }
	}
}