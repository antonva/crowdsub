using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub;
using CrowdSub.Models;
using CrowdSub.Repositories;

namespace CrowdSub.Tests.Mocks
{
	public class mock_subtitle_repository : i_subtitle_repository
	{
		private readonly List<subtitle> _subtitles;
		public mock_subtitle_repository(List<subtitle> subtitles)
		{
			_subtitles = subtitles;
		}
		public IQueryable<subtitle> get_subtitles()
		{
			return _subtitles.AsQueryable();
		}
		public bool create_subtitle(int id)
		{
			throw new NotImplementedException();
		}

		public bool edit_subtitle(int id)
		{
			throw new NotImplementedException();
		}

		public bool delete_subtitle(int id)
		{
			throw new NotImplementedException();
		}

		public subtitle get_subtitle_by_id(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<subtitle> get_subtitles_by_video_id(int video_id)
		{
			throw new NotImplementedException();
		}

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
