using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;
using System.Web.Mvc;

namespace CrowdSubMain.Repositories
{
	interface i_video_repository
	{
		IQueryable<video> get_videos();
		void add(video video);
		void edit(video video);
		bool delete(int id);
	}
}
