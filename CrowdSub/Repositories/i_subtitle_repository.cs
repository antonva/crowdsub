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
		IQueryable<subtitle> get_subtitles();
        subtitle add(subtitle sub);
        subtitle edit(int id, subtitle sub);
        bool del(int id);
	}
}
