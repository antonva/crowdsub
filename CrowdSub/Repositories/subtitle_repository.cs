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


        public subtitle add(subtitle sub)
        {
			db.subtitles.Add(sub);
			db.SaveChanges();
			subtitle sub_to_return = (from s in db.subtitles
									  orderby s.id descending
									  select s).First();
			return sub_to_return;
        }

        public bool delete(int id)
        {
			subtitle subtitle_to_delete = db.subtitles.Where(x => x.id == id).FirstOrDefault();
			if(subtitle_to_delete != null)
			{
				db.subtitles.Remove(subtitle_to_delete);
				db.SaveChanges();
				return true;
			}
			return false;
        }
    }
}