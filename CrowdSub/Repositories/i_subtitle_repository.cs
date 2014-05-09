using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Models;

namespace CrowdSub.Repositories
{
	public interface i_subtitle_repository
	{
		//test function which should return all subtitles in database
		IQueryable<subtitle> get_subtitles();

		//CRUD
		bool create_subtitle(int id);
		bool edit_subtitle(int id);
		bool delete_subtitle(int id);
		subtitle get_subtitle_by_id(int id);

		//Search
		IEnumerable<subtitle> get_subtitles_by_video_id(int video_id);

		//Misc
		int get_subtitle_count();
		int get_subtitle_count_by_video_id(int video_id);
	}
}
