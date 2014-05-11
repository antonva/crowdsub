using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrowdSub;
using CrowdSub.Controllers;
using CrowdSub.Models;
using System.Web.Mvc;
using CrowdSub.Tests.Mocks;

namespace CrowdSub.Tests.Controllers
{
	[TestClass]
	public class SubtitleControllerTest
	{
		[TestMethod]
		public void subtitle_get_profile_by_id()
		{
			// Arrange:
			List<subtitle> subtitles = new List<subtitle>();
			for(int i = 0; i < 4; i++)
			{
				subtitles.Add(new subtitle
				{
					id = i,
					subtitle_user_id = 1,
					subtitle_video_id = i,
					subtitle_date_created = DateTime.Now
				});
			}

			mock_subtitle_repository mock_subtitle_repo = new mock_subtitle_repository(subtitles);
			var controller = new SubtitleController(mock_subtitle_repo);

			// Act:
			var id = 3;
			var result = controller.profile(id);

			// Assert:
			var view_result = (ViewResult)result;
			subtitle model = view_result.Model as subtitle;
			//Id should be equal to requested id
			Assert.IsTrue(model.id == id);
			//Id should not be equal to requested id + 1
			Assert.IsFalse(model.id == id + 1);
		}

		[TestMethod]
		public void subtitle_fail_get_profile_by_id_null_exception()
		{
			// Arrange:
			List<subtitle> subtitles = new List<subtitle>();
			for(int i = 0; i < 4; i++)
			{
				subtitles.Add(new subtitle
				{
					id = i,
					subtitle_user_id = 1,
					subtitle_video_id = i,
					subtitle_date_created = DateTime.Now
				});
			}

			mock_subtitle_repository mock_subtitle_repo = new mock_subtitle_repository(subtitles);
			var controller = new SubtitleController(mock_subtitle_repo);

			// Act:
			var id = 5;
			var result = controller.profile(id);

			// Assert:
			var view_result = (ViewResult)result;
			subtitle model = view_result.Model as subtitle;
			// Id should be null
			Assert.IsNull(model);
		}

		[TestMethod]
		public void subtitle_get_subtitles_by_video_id()
		{
			// Arrange:
			

			// Act:

			// Assert:
		}
	}
}
