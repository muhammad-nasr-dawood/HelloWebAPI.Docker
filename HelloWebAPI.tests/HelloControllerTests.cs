using Xunit;
using Microsoft.AspNetCore.Mvc;
using HelloWebAPI.Controllers;

namespace HelloWebAPI.Tests   // match your .csproj’s default namespace
{
    public class HelloControllerTests
    {
        [Fact]
        public void Get_ReturnsHelloFromDotNetWebAPI()
        {
            // Arrange
            var controller = new HelloController();

            // Act
            var actionResult = controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(actionResult);

            // Assert
            Assert.Equal("Hello from .NET Web API!", okResult.Value);
        }
    }
}
