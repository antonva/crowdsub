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
using System.Diagnostics;

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
		public void subtitle_fail_get_profile_by_id_not_available()
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
			var result = controller.profile(id) as ViewResult;

			// Assert:
			Assert.AreEqual("Error", result.ViewBag.Title);
		}

		[TestMethod]
		public void subtitle_get_subtitles_by_video_id()
		{
			// Arrange:
			List<subtitle> subtitles = new List<subtitle>();
			for(int i = 0; i < 250; i++) //add subtitles with the correct
			{                          //video id
				subtitles.Add(new subtitle
				{
					id = i,
					subtitle_user_id = 1,
					subtitle_video_id = 1,
					subtitle_date_created = DateTime.Now
				});
			}
			for(int i = 4; i < 7; i++) //add subtitles with the incorrect
			{                          //video id
				subtitles.Add(new subtitle
				{
					id = i,
					subtitle_user_id = 2,
					subtitle_video_id = 2,
					subtitle_date_created = DateTime.Now
				});
			}
			mock_subtitle_repository mock_subtitle_repo = new mock_subtitle_repository(subtitles);
			var controller = new SubtitleController(mock_subtitle_repo);

			// Act:
			var video_id = 1;
			var result = controller.subtitles_for_video(video_id);

			// Assert:
			var view_result = (ViewResult)result;
			List<subtitle> model = (view_result.Model as IEnumerable<subtitle>).ToList();
			//model should contain 4 subtitles
			Assert.IsTrue(model.Count == 250);
			for(int i = 0; i < model.Count; i++)
			{
				//all subtitles in model should have the correct video_id (1)
				Assert.IsTrue(model[i].subtitle_video_id == video_id);
			}
			
		}

		[TestMethod]
		public void subtitle_get_subtitles_by_video_id_empty_list()
		{
			// Arrange:
			List<subtitle> subtitles = new List<subtitle>();
			for(int i = 0; i < 3; i++) //populate list with subtitles for video_id 1
			{
				subtitles.Add(new subtitle
				{
					id = i,
					subtitle_user_id = 1,
					subtitle_video_id = 1,
					subtitle_date_created = DateTime.Now
				});
			}
			for (int i = 3; i < 6; i++) //populate list with subtitles for video_id 2
			{
				subtitles.Add(new subtitle
				{
					id = i,
					subtitle_user_id = 2,
					subtitle_video_id = 2,
					subtitle_date_created = DateTime.Now
				});
			}

			mock_subtitle_repository mock_subtitle_repo = new mock_subtitle_repository(subtitles);
			var controller = new SubtitleController(mock_subtitle_repo);

			// Act:
			var video_id = 5; //set test id to something that cannot be found
			var result = controller.subtitles_for_video(video_id) as ViewResult;

			// Assert:
			Assert.IsTrue("Error" == result.ViewBag.Title);
		}
		[TestMethod]
		public void subtitle_delete()
		{
			// Arrange:
			List<subtitle> subtitles = new List<subtitle>();
			for(int i = 0; i < 4; i++)
			{
				subtitles.Add(new subtitle
				{
					id = i,
					subtitle_video_id = 1
				});
			}

			mock_subtitle_repository mock_subtitle_repo = new mock_subtitle_repository(subtitles);
			var controller = new SubtitleController(mock_subtitle_repo);

			// Act:
			var id = 1;
			var result = controller.delete_subtitle(id);

			// Assert:
			var view_result = (ViewResult)result;
			List<subtitle> model = (view_result.Model as IEnumerable<subtitle>).ToList();
			Assert.IsTrue(model.Count == 3);
		}
	}
}
