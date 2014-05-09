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
			throw new NotImplementedException();
		}
		public bool create_subtitle(int id)
		{
			//create new subtitle file with parameter as id
			//return true if create succeeded
			//false otherwise
			throw new NotImplementedException();
		}
		public bool edit_subtitle(int id)
		{
			//edit subtitle file or something
			//return true if edit succeeded
			//false otherwise
			throw new NotImplementedException();
		}
		public bool delete_subtitle(int id)
		{
			throw new NotImplementedException();
		}
		public subtitle get_subtitle_by_id(int id)
		{
			//return subtitle which has parameter as id
			//throw exception otherwise
			throw new NotImplementedException();
		}

		//Search
		public IEnumerable<subtitle> get_subtitles_by_video_id(int video_id)
		{
			throw new NotImplementedException();
		}

		//Misc
		public int get_subtitle_count()
		{
			throw new NotImplementedException();
		}
		public int get_subtitle_count_by_video_id(int video_id)
		{
			throw new NotImplementedException();
		}

	}
}