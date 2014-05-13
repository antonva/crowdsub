using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CrowdSubMain.Models
{
	public enum vidtype 
	{ 
		Movie = 0,
		TvShow = 1,
		Other = 2
	}
	public class video
	{
		public int id { get; set; }
		public string video_created_by_user_id { get; set; }

        [Required(ErrorMessage = "Video title is required")]
		public string video_title { get; set; }
		public vidtype video_type { get; set; }
		public int video_year_published { get; set; }
		public System.DateTime video_date_created { get; set; }
		public System.DateTime video_date_updated { get; set; }
		public string video_description { get; set; }

		public virtual ICollection<subtitle> subtitles { get; set; }
		public virtual ApplicationUser user { get; set; }
		public virtual ICollection<request> requests { get; set; }

	}
}