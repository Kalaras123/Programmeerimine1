using KooliProjekt.Services;
using KooliProjekt.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using KooliProjekt.Data;

namespace KooliProjekt.UnitTests.ControllerTests
{
    public class StatusesControllerTests
    {
        private readonly Mock<IStatusService> _statusServiceMock;
        private readonly StatusesController _controller;
        
        public StatusesControllerTests()
        {
            _statusServiceMock = new Mock<IStatusService>();
            _controller = new StatusesController(_statusServiceMock.Object);
        }

        [Fact]
        public async Task Index_should_return_view_and_data()
        {
            //Arrange
            var data = new List<Status>
            {
                new Status { Id = 1, StatusType = "Active" },
                new Status { Id = 2, StatusType = "Inactive" }
            };

            _statusServiceMock.Setup(x => x.AllStatuses()).ReturnsAsync(data);
                        
            //Act
            var result = await _controller.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Index"
                );
            Assert.Equal(data, result.Model);
        }
    }
}