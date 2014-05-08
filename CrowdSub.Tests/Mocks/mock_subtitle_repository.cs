using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub;
using CrowdSub.Models;

namespace CrowdSub.Tests.Mocks
{
	public class mock_subtitle_repository
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

	}
}
