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
	}
}
