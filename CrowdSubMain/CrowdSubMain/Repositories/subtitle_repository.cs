using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;
using System.Data.Entity;

namespace CrowdSubMain.Repositories
{
	public class subtitle_repository : i_subtitle_repository
	{
		private crowd_sub_context db = new crowd_sub_context();

		public IQueryable<subtitle> get_subtitles()
		{
			return db.subtitles;
		}

		public void add(subtitle sub)
		{
			throw new NotImplementedException();
		}

		public void edit(subtitle sub)
		{
			db.Entry(sub).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void delete(subtitle sub)
		{
			/* subtitle subtitle_to_delete = db.subtitles.Where(s => s.id == id).FirstOrDefault();
			if (subtitle_to_delete != null)
			{
				var subtitle_del = (from s in db.subtitles
									where s.id == id
									select s).FirstOrDefault();
				db.subtitles.Remove(subtitle_del);
				db.SaveChanges();
				return true;
			}
			return false; */

			db.subtitles.Remove(sub);
			db.SaveChanges();
		}
	}
}