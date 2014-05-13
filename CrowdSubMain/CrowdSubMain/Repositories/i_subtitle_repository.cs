using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Repositories
{
	interface i_subtitle_repository
	{
		IQueryable<subtitle> get_subtitles();
		bool add(subtitle sub);
		bool edit(subtitle sub);
		bool delete(int id);
	}
}
