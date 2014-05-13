using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSubMain.Models
{
	public class upvote
	{
		public int id { get; set; }
		public int upvote_request_id { get; set; }
		public string upvote_user_id { get; set; }
		public System.DateTime upvote_date_create { get; set; }

		public virtual ApplicationUser user { get; set; }
		public virtual request request { get; set; }
	}
}