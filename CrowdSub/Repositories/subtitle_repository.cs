using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
	public class subtitle_repository : i_subtitle_repository
	{
		private crowddbEntities db = new crowddbEntities();

		public IQueryable<subtitle> get_subtitles()
		{
            return db.subtitles;
		}
	}
}