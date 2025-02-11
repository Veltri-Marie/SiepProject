using System;
using System.Threading.Tasks;
using Interfaces.Repositories;
using InterfaceS.Helpers.File;
using Microsoft.SemanticKernel;
using Moq;
using Repositories.Job;
using Xunit;
/*
namespace Back_ASP_SIEP.Tests.InfrastructureTests.RepositoriesTests
{
    public class JobSheetRepositoryTests
    {
        [Fact]
        public async Task GetFormatedSheetAsync_ReturnsNonNullResult_WhenJobNameIsValid()
        {
            // Arrange
            var mockKernel = new Mock<Kernel>();
            var mockFileHelper = new Mock<IFileHelper>();
            var jobName = "TestJob";
            var fileContent = "{ \"name\": \"x\", \"description\": \"x\" }";

            // Simuler la réponse de FunctionResult
            var mockFunctionResult = new Mock<FunctionResult>();
            mockFunctionResult.Setup(fr => fr.ToString()).Returns("Test result");

            // Mock de GetFileContent
            mockFileHelper.Setup(fh => fh.GetFileContent(It.IsAny<string>())).Returns(fileContent);

            // Correction de InvokePromptAsync pour retourner un objet valide
            mockKernel.Setup(k => k.InvokePromptAsync(It.IsAny<string>(), It.IsAny<KernelArguments>()))
                    .ReturnsAsync(mockFunctionResult.Object);

            var repository = new JobSheetRepository(mockKernel.Object, mockFileHelper.Object);

            // Act
            var result = await repository.GetFormatedSheetAsync(jobName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test result", result);

        }

        [Fact]
        public async Task GetFormatedSheetAsync_ThrowsException_WhenJobNameIsInvalid()
        {
            // Arrange
            var mockKernel = new Mock<Kernel>();
            var mockFileHelper = new Mock<IFileHelper>();
            var jobName = "InvalidJob";
            var fileContent = "{ \"name\": \"x\", \"description\": \"x\" }";

            mockFileHelper.Setup(fh => fh.GetFileContent(It.IsAny<string>())).Returns(fileContent);
            mockKernel.Setup(k => k.InvokePromptAsync(It.IsAny<string>(), It.IsAny<KernelArguments>()))
                      .ThrowsAsync(new Exception("Job not found"));

            var repository = new JobSheetRepository(mockKernel.Object, mockFileHelper.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => repository.GetFormatedSheetAsync(jobName));
        }

        [Fact]
        public async Task GetFormatedSheetAsync_ThrowsException_WhenFileContentCannotBeRetrieved()
        {
            // Arrange
            var mockKernel = new Mock<Kernel>();
            var mockFileHelper = new Mock<IFileHelper>();
            var jobName = "TestJob";

            mockFileHelper.Setup(fh => fh.GetFileContent(It.IsAny<string>())).Throws(new Exception("File not found"));

            var repository = new JobSheetRepository(mockKernel.Object, mockFileHelper.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => repository.GetFormatedSheetAsync(jobName));
        }
    }
}*/