using KooliProjekt.Services;
using KooliProjekt.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using KooliProjekt.Data;

namespace KooliProjekt.UnitTests.ControllerTests
{
    public class WorkersControllerTests
    {
        private readonly Mock<IWorkerService> _workerServiceMock;
        private readonly WorkersController _controller;

        public WorkersControllerTests()
        {
            _workerServiceMock = new Mock<IWorkerService>();
            _controller = new WorkersController(_workerServiceMock.Object);
        }

        [Fact]
        public async Task Index_should_return_view_and_data()
        {
            //Arrange
            var data = new List<Worker>
            {
                new Worker { Id = 1, WorkerName = "John Doe", Email = "john.doe@example.com"},
                new Worker { Id = 2, WorkerName = "Jane Doe", Email = "jane.doe@example.com" }
            };
            _workerServiceMock.Setup(x => x.AllWorkers()).ReturnsAsync(data);
            
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