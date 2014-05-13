using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSubMain.Repositories
{
	public class video_repository : i_video_repository
	{
		public IQueryable<Models.video> get_videos()
		{
			throw new NotImplementedException();
		}

		public bool add(Models.video video)
		{
			throw new NotImplementedException();
		}

		public bool edit(Models.video video)
		{
			throw new NotImplementedException();
		}

		public bool delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}