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
	public class UserControllerTest
	{
		[TestMethod]
		public void get_10_users()
		{
            // Arrange
            List<user> users = new List<user>();
            for (int i = 0; i < 13; i++)
            {
                users.Add( new user
                    {
                        id = i,
                        user_name = "user" + i.ToString(),
                        user_password = i.ToString(),
                        user_role = i,
                        user_date_created = DateTime.Now,
                        user_email = "user@user." + i.ToString()
                    });
            }

            mock_user_repository mock_user_repo = new mock_user_repository(users);
            var controller = new UserController(mock_user_repo);
            
            // Act

            var result = controller.Index();
            

            // Assert

            var view_result = (ViewResult)result;
            List<user> model = (view_result.Model as IEnumerable<user>).ToList();
            Assert.IsTrue(model.Count == 10);
		}
        [TestMethod]
        public void get_11_users()
        {
            // Arrange
            List<user> users = new List<user>();
            for (int i = 0; i < 15; i++)
            {
                users.Add(new user
                {
                    id = i,
                    user_name = "user" + i.ToString(),
                    user_password = i.ToString(),
                    user_role = i,
                    user_date_created = DateTime.Now,
                    user_email = "user@user." + i.ToString()
                });
            }

            Mocks.mock_user_repository mock_user_repo = new Mocks.mock_user_repository(users);
            var controller = new UserController(mock_user_repo);

            // Act

            var result = controller.Index();


            // Assert

            var view_result = (ViewResult)result;
            List<user> model = (view_result.Model as IEnumerable<user>).ToList();
            Assert.IsTrue(model.Count == 11);
        }
	}
}
