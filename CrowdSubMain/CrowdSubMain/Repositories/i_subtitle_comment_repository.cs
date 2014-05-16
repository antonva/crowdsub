using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain.DAL;
using CrowdSubMain.Models;

namespace CrowdSubMain.Repositories
{
    interface i_subtitle_comment_repository
    {
        IQueryable<subtitle_comment> get_subtitle_comments();
        void add(subtitle_comment subtitle_comment);
        void edit(subtitle_comment subtitle_comment);
        void delete(subtitle_comment subtitle_comment);
    }
}
