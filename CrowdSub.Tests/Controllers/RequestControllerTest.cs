using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrowdSub.Tests.Mocks;
using CrowdSub.Models;
using System.Web.Mvc;
using CrowdSub.Controllers;
using CrowdSub;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrowdSub.Tests.Controllers
{
    [TestClass]
    public class RequestControllerTest
    {
        [TestMethod]
        public void request_create()
        {
            //Arrange
            /* Creating video object
             * Video object must be available to create Request
             */
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
            var video_controller = new VideoController(mock_video_repo);

            List<request> request = new List<request>();

            mock_request_repository mock_request_repo = new mock_request_repository(request);
            var request_controller = new RequestController(mock_request_repo);
 
            //Act
            var content = new FormCollection();

            content.Add("request_user_id", "1");
            content.Add("request_video_id", "1");
            content.Add("request_date_created", "DateTime.Now");
            content.Add("request_lang", "1");
            content.Add("request_link", "request_link_string");
            content.Add("request_name", "Request1");
            content.Add("request_type", "Hearing impared");

            var result = request_controller.create(content);
           
            //Assert
            var view_result = (ViewResult)result;

            Assert.IsNotNull(view_result.Model);
            List<request> model = (view_result.Model as IEnumerable<request>).ToList();
            Assert.IsTrue(model.Count == 1);

        }

        [TestMethod]
        public void request_edit()
        {
            //Arrange
            List<request> request = new List<request>();
            request.Add(new request
            {
                request_name = "request1",
                id = 1
            });

            mock_request_repository mock_request_repo = new mock_request_repository(request);
            var request_controller = new RequestController(mock_request_repo);

            

            //Act
            
            
            var changes = new FormCollection();
            var changename = "Request2";
            changes.Add("request_name", changename);
            var id = 1;

            var result = request_controller.edit(id, changes);

            //Assert
            var view_result = (ViewResult)result;

            request model = view_result.Model as request;
            Assert.IsTrue(model.request_name == changename);

        }

        [TestMethod]
        public void request_delete()
        {
            //Arrange

             //Act

            //Assert
        }

        [TestMethod]
        public void request_add_upvote()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void request_remove_upvote()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
