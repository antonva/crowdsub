using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSubMain.Models
{
	public class request
	{
		public int id { get; set; }
		public string request_user_id { get; set; }
		public string request_lang { get; set; }
		public int request_video_id { get; set; }
		public System.DateTime request_date_created { get; set; }
        public System.DateTime request_date_updated { get; set; }
	
		public virtual ApplicationUser user { get; set; }
		public virtual video video { get; set; }
		public virtual ICollection<upvote> upvotes { get; set; }
	}
}