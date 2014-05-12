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
        public void video_get_profile_by_id()
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
            var result = controller.profile(id);

            // Assert
            var view_result = (ViewResult)result;
            video model = view_result.Model as video;
            // Id is equal to requested id.
            Assert.IsTrue(model.id == id);
            // Id is not equal to requested id + 1 (error case).
            Assert.IsFalse(model.id == id + 1);

        }

        [TestMethod]
        public void video_fail_get_profile_by_id_null_exception()
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
            var result = controller.profile(id);

            // Assert
            var view_result = (ViewResult)result;
            video model = view_result.Model as video;
            // Id is null.
            Assert.IsNull(model);
        }

        // video_search_by_title test that passes
        [TestMethod]
        public void video_search_by_title()
        {
            //Arrange
            List<video> videos = new List<video>();
            for (int i = 0; i < 4; i++)
            {
                videos.Add(new video
                {
                    id = i,
                    video_title = "Video" + i.ToString()
                });
            }

            mock_video_repository mock_video_repo = new mock_video_repository(videos);
            var controller = new VideoController(mock_video_repo);

            //Act
            var title = "Video1";
            var result = controller.search(title);

            //Assert
            var view_result = (ViewResult)result;

            List<video> model = (view_result.Model as IEnumerable<video>).ToList();
            Assert.IsFalse(model.Count < 1);
            for (int i = 0; i < model.Count; i++)
            {
                Assert.IsTrue(model[i].video_title.Contains(title));
            }
        }
        // video_search_by_title test that fails
        [TestMethod]
        public void video_fail_search_by_title()
        {
            //Arrange
            List<video> videos = new List<video>();
            for (int i = 0; i < 4; i++)
            {
                videos.Add(new video
                {
                    id = i,
                    video_title = "Video" + i.ToString()
                });
            }

            mock_video_repository mock_video_repo = new mock_video_repository(videos);
            var controller = new VideoController(mock_video_repo);

            //Act
            var title = "Video100";
            var result = controller.search(title);

            //Assert
            var view_result = (ViewResult)result;

            List<video> model = (view_result.Model as IEnumerable<video>).ToList();
            Assert.IsFalse(model.Count < 1);
            for (int i = 0; i < model.Count; i++)
            {
                Assert.IsTrue(model[i].video_title.Contains(title));
            }
        }

        // TODO: FIXME
        [TestMethod]
        public void video_profile_create()
        {
            //Arrange
            List<video> videos = new List<video>();

            var testvideo = new FormCollection();
            testvideo.Add("video_title", "Bathman Begins");
            testvideo.Add("video_created_by_user_id","1");
            testvideo.Add("video_year_published","1900");
            testvideo.Add("video_type","1");
            testvideo.Add("video_date_created",DateTime.Now.ToString());
            testvideo.Add("video_date_updated ",DateTime.Now.ToString());

            mock_video_repository mock_video_repo = new mock_video_repository(videos);
            var controller = new VideoController(mock_video_repo);


            //Act
            var result = controller.create_video(testvideo);

            //Assert
            var view_result = (ViewResult)result;
            Assert.IsNotNull(view_result.Model);
            List<video> model = (view_result.Model as IEnumerable<video>).ToList();
            Assert.IsTrue(model.Count == 1);
        }

        [TestMethod]
        public void video_fail_check_unique_search()
        {
            // This test should fail.
            //Arrange
            List<video> videos = new List<video>();
            
            videos.Add(new video
            {
                id = 1,
                video_title = "Video" + 1.ToString()
            });
           

            mock_video_repository mock_video_repo = new mock_video_repository(videos);
            var controller = new VideoController(mock_video_repo);
            
            //Act
            var query = "Video1";
            var result = controller.is_unique_video_title(query);

            //Assert
            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void video_delete()
        {
            // Arrange
            List<video> videos = new List<video>();

            for (int i = 0; i < 4; i++) {
                videos.Add(new video
                {
                    id = i,
                    video_title = "video" + i.ToString()
                });
            }

            mock_video_repository mock_video_repo = new mock_video_repository(videos);
            var controller = new VideoController(mock_video_repo);

            // Act

            var query = 1;
            var result = controller.delete_video(query);
            
            // Assert
            var view_results = (ViewResult)result;
            List<video> model = (view_results.Model as IEnumerable<video>).ToList();
            Assert.IsTrue(model.Count == 3);
        }

        [TestMethod]
        public void delete_video_fail() 
        { 
            // Arrange
            List<video> videos = new List<video>();

            for (int i = 0; i < 4; i++)
            {
                videos.Add(new video
                {
                    id = i,
                    video_title = "video" + i.ToString()
                });
            }

            mock_video_repository mock_video_repo = new mock_video_repository(videos);
            var controller = new VideoController(mock_video_repo);

            // Act
            var query = 5;
            var result = controller.delete_video(query);
            
            // Assert
            var view_results = (ViewResult)result;
            List<video> model = (view_results.Model as IEnumerable<video>).ToList();
            Assert.IsTrue(model.Count == 4);
        }
    }
}