using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSub.Repositories;
using CrowdSub.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrowdSub.Controllers;




namespace CrowdSub.Tests.Mocks
{
    [TestClass]
    public class mock_request_repository : i_request_repository
    {
        [TestMethod]
        private readonly List<request> _request;
        public mock_request_repository(List<request> request)
        {
            _request = request;
        }

        public IQueryable<request> get_requests()
        {
            //Arrange
            List<request> requests = new List<request>();
            for(int i = 0; i <_request.Count; i++)
            {
                request.Add(new request
                {
                    id = i,
                    request_name = "User" + i.ToString(),
                    request_link = "Link" + i.ToString(),
                    request_type = "Hearing impaired" + i.ToString(),
                    request_lang = i,
                    request_video_id = i,
                    request_date_created = DateTime.Now,
                });

                //Act

                //Assert
            }
        }

        public bool create_request(request create_request)
        {
            //Arrange
            create_request = new request{
                id = 1,
                request_user_id = 1,
                request_name = "User",
                request_link = "www.test.com",
                request_type = "Should be int type",

            }
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public bool edit_request(request edited_request)
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public bool delete_request()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public bool get_request_by_user_id()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public bool get_request_by_request_id()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public int get_request_by_upvotes()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public int get_requests_count()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public bool show_all_fullfied_requests()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public bool show_all_not_fullfied_requests()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public bool request_is_fullfied()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public bool request_is_not_fullfied()
        {
            //Arrange
            //Act
            //Assert
            throw new NotImplementedException();
        }

        public List<request> request { get; set; }
    }
}
