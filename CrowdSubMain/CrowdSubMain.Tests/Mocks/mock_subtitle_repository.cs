using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSubMain;//Bætti við
using CrowdSubMain.Models;//Bætti við
using CrowdSubMain.Repositories; //Bætti við

namespace CrowdSubMain.Tests.Mocks
{
    public class mock_subtitle_repository : i_subtitle_repository //Bætti við public
    {
        private readonly List<subtitle> _subtitles;
        public mock_subtitle_repository(List<subtitle> subtitles)
        {
            _subtitles = subtitles;
        }


        public IQueryable<subtitle> get_subtitles()
        {
            throw new NotImplementedException();
        }

        public void add(subtitle sub)
        {
            throw new NotImplementedException();
        }

        public void edit(subtitle sub)
        {
            throw new NotImplementedException();
        }

        public void delete(subtitle sub)
        {
            throw new NotImplementedException();
        }
    }
}
