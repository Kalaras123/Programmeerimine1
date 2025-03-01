using KooliProjekt.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Xunit;

namespace KooliProjekt.UnitTests.ControllerTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_should_return_correct_view()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) || 
                result.ViewName == "Index"
                );
        }

        [Fact]
        public void Privacy_should_return_correct_view()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Privacy() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Privacy"
                );
        }

        [Fact]
        public void Error_should_return_correct_view_with_httpcontext()
        {
            //Arrange
            var controller = new HomeController();
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var result = controller.Error() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Error"
                );
        }

        [Fact]
        public void Error_should_return_correct_view_with_current_activity()
        {
            //Arrange
            var controller = new HomeController();
            Activity.Current = new Activity("activity").Start();

            //Act
            var result = controller.Error() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Error"
                );
        }
    }
}