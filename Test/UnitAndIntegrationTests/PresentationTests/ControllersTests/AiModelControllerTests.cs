using System.Threading.Tasks;
using ApiControllers.AI;
using Dtos.Job.Response;
using Interfaces.UseCases.Job;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitAndIntegrationTests.PresentationTests.ControllersTests
{
    public class AiModelControllerTests
    {
        [Fact]
        public async Task GetJobSheet_ReturnsOkResult_WithModel()
        {
            // Arrange
            var mockUseCase = new Mock<IGetJobSheetUseCase>();
            var expectedModel = new JobSheetResponse("Test Model", "Test Description"); // Utilisation de JobSheetResponse avec les arguments requis
            mockUseCase.Setup(useCase => useCase.Execute(It.IsAny<string>())).ReturnsAsync(expectedModel);
            var controller = new AiModelController(mockUseCase.Object);

            // Act
            var result = await controller.GetJobSheet("TestJob");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<JobSheetResponse>(okResult.Value); // Utilisation de JobSheetResponse
            Assert.Equal(expectedModel.Name, returnValue.Name);
            Assert.Equal(expectedModel.Description, returnValue.Description);
        }
    }
}