using KooliProjekt.Services;
using KooliProjekt.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using KooliProjekt.Data;

namespace KooliProjekt.UnitTests.ControllerTests
{
    public class CarsControllerTests
    {
        private readonly Mock<ICarService> _carServiceMock;
        private readonly CarsController _controller;

        public CarsControllerTests()
        {
            _carServiceMock = new Mock<ICarService>();
            _controller = new CarsController(_carServiceMock.Object);
        }

        [Fact]
        public async Task Index_should_return_view_and_data()
        {
            //Arrange
            var data = new List<Car>
            {
                new Car { Id = 1, Mark = "Audi", Model = "A4", RegistrationNumber = "123ABC" },
                new Car { Id = 2, Mark = "BMW", Model = "X5", RegistrationNumber = "456DEF" }
            };
            _carServiceMock.Setup(x => x.AllCars()).ReturnsAsync(data);

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