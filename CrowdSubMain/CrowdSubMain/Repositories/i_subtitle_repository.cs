using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;

namespace CrowdSubMain.Repositories
{
	public interface i_subtitle_repository
	{
		IQueryable<subtitle> get_subtitles();
		void add(subtitle sub);
		void edit(subtitle sub);
		void delete(subtitle sub);
	}
}
