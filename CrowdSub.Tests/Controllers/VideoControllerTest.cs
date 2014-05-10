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
    public class VideoControllerTest
    {
        [TestMethod]
        public void get_video_profile_by_id()
        {
            // Arrange
            List<video> videos = new List<video>();
            for (int i = 0; i < 4; i++)
            {
                videos.Add(new video
                {
                    id = i,
                    video_created_by_user_id = i,
                    video_year_published = i,
                    video_type = i.ToString(),
                    video_date_created = DateTime.Now,
                    video_date_updated = DateTime.Now,
                    video_title = "Video" + i.ToString()
                });
            }

            mock_video_repository mock_video_repo = new mock_video_repository(videos);
            var controller = new VideoController(mock_video_repo);

            // Act
            var id = 3;
            var result = controller.Profile(id);

            // Assert
            var view_result = (ViewResult)result;
            video model = view_result.Model as video;
            // Id is equal to requested id.
            Assert.IsTrue(model.id == id);
            // Id is not equal to requested id + 1 (error case).
            Assert.IsFalse(model.id == id + 1);

        }

        [TestMethod]
        public void get_video_profile_by_id_null_exception()
        {
            // Arrange
            List<video> videos = new List<video>();
            for (int i = 0; i < 4; i++)
            {
                videos.Add(new video
                {
                    id = i,
                    video_created_by_user_id = i,
                    video_year_published = i,
                    video_type = i.ToString(),
                    video_date_created = DateTime.Now,
                    video_date_updated = DateTime.Now,
                    video_title = "Video" + i.ToString()
                });
            }

            mock_video_repository mock_video_repo = new mock_video_repository(videos);
            var controller = new VideoController(mock_video_repo);

            // Act
            var id = 5;
            var result = controller.Profile(id);

            // Assert
            var view_result = (ViewResult)result;
            video model = view_result.Model as video;
            // Id is null.
            Assert.IsNull(model);
        }
    }
}
