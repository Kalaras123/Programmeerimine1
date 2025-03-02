using KooliProjekt.Services;
using KooliProjekt.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using KooliProjekt.Data;
using KooliProjekt.Search;
using KooliProjekt.Models;

namespace KooliProjekt.UnitTests.ControllerTests
{
    public class OperationsControllerTests
    {
        private readonly Mock<IOperationService> _operationServiceMock;
        private readonly OperationsController _controller;
        
        public OperationsControllerTests()
        {
            _operationServiceMock = new Mock<IOperationService>();
            _controller = new OperationsController(_operationServiceMock.Object);
        }

        [Fact]
        public async Task Index_should_return_view_and_data()
        {
            //Arrange
            var data = new List<Operation>
            {
                new Operation { Id = 1, Action = "Repair", OperationDate = DateTime.Now, Cost = 100 },
                new Operation { Id = 2, Action = "Maintenance", OperationDate = DateTime.Now, Cost = 50 }
            };

            _operationServiceMock
                .Setup(x => x.AllOperations(It.IsAny<OperationsSearch>()))
                .ReturnsAsync(data);
                        
            //Act
            var result = await _controller.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Index"
                );
            var model = Assert.IsType<OperationsIndexModel>(result.Model);
            Assert.Equal(data, model.Data);
        }
    }
}