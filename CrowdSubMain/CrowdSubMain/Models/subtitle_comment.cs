using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSubMain.Models
{
	public class subtitle_comment
	{
		public int id { get; set; }
		public string sc_user_id { get; set; }
		public int sc_sub_id { get; set; }
		public string sc_comment { get; set; }
		public System.DateTime sc_date_created { get; set; }

		public virtual ApplicationUser user { get; set; }
		public virtual subtitle subtitle { get; set; }
	}
}