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


        public subtitle add(subtitle sub)
        {
            throw new NotImplementedException();
        }

        public subtitle edit(int id, subtitle sub)
        {
            throw new NotImplementedException();
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
