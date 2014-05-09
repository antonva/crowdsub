using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
	public class subtitle_repository : i_subtitle_repository
	{
		//TODO: connect to database
		private crowddbEntities db = new crowddbEntities();

		//CRUD
		public IQueryable<subtitle> get_subtitles()
		{
			//just for testing..
			return db.subtitles;
		}
		bool create_subtitle(int id)
		{
			//create new subtitle file with parameter as id
			//return true if create succeeded
			//false otherwise
			return true;
		}
		bool edit_subtitle(int id)
		{
			//edit subtitle file or something
			//return true if edit succeeded
			//false otherwise
			return true;
		}
		bool delete_subtitle(int id)
		{
			return true;
		}
		subtitle get_subtitle_by_id(int id)
		{
			//return subtitle which has parameter as id
			//throw exception otherwise
			return null;
		}

	}
}