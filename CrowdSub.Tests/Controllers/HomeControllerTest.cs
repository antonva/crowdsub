using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrowdSub;
using CrowdSub.Controllers;

namespace CrowdSub.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void homecontroller_index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void homecontroller_about()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.about() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void homecontroller_contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
