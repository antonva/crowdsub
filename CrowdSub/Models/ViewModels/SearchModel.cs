using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrowdSub.Models
{
	public class SearchModel
	{
		[Required]
		public string query;
		// public string language;
	}
}