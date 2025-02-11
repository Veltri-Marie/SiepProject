/*
using System.Text.Json;
using System.Threading.Tasks;
using Dtos.Job.Details;
using Dtos.Job.Response;
using Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using UseCases.Job;
using Xunit;
using Exceptions.Job;
*/

namespace Back_ASP_SIEP.Tests.ApplicationTests.UseCasesTests
{
    //#TODO: Adapt tests to models instead of dtos
    public class GetJobSheetUseCaseTestsTest
    {
        // Test if the Execute method returns a non-null result when the job name is valid
        [Fact]
        public async Task Execute_ReturnsNonNullResult_WhenJobNameIsValid()
        {
            /*
            // Arrange
            var mockRepository = new Mock<IJobSheetRepository>();
            var mockLogger = new Mock<ILogger<GetJobSheetUseCase>>();
            var jobName = "TestJob";
            var jobSheetDetails = new JobSheetDetails("JobName", "JobDescription"); // Initialize with required parameters
            var jsonFormatedString = JsonSerializer.Serialize(jobSheetDetails);

            mockRepository.Setup(repo => repo.GetFormatedSheetAsync(jobName))
                .ReturnsAsync(jsonFormatedString);

            var useCase = new GetJobSheetUseCase(mockRepository.Object, mockLogger.Object);

            // Act
            var result = await useCase.Execute(jobName);

            // Assert
            Assert.NotNull(result);
            */
        }

        // Test if the Execute method throws JobSheetException when the job name is invalid
        [Fact]
        public async Task Execute_ThrowsJobSheetException_WhenJobNameIsInvalid()
        {
            /*
            // Arrange
            var mockRepository = new Mock<IJobSheetRepository>();
            var mockLogger = new Mock<ILogger<GetJobSheetUseCase>>();
            var jobName = "InvalidJob";

            mockRepository.Setup(repo => repo.GetFormatedSheetAsync(jobName))
                .ThrowsAsync(new JobSheetException("Job not found"));

            var useCase = new GetJobSheetUseCase(mockRepository.Object, mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<JobSheetException>(() => useCase.Execute(jobName));
            */
        }

        // Test if the Execute method throws JobSheetException when the repository throws an exception
        [Fact]
        public async Task Execute_ThrowsJobSheetException_WhenRepositoryThrowsException()
        {
            /*
            // Arrange
            var mockRepository = new Mock<IJobSheetRepository>();
            var mockLogger = new Mock<ILogger<GetJobSheetUseCase>>();
            var jobName = "TestJob";

            mockRepository.Setup(repo => repo.GetFormatedSheetAsync(jobName))
                .ThrowsAsync(new Exception("Repository error"));

            var useCase = new GetJobSheetUseCase(mockRepository.Object, mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<JobSheetException>(() => useCase.Execute(jobName));
            */
        }

        // Test if the Execute method throws JobSheetException when the job name is null
        [Fact]
        public async Task Execute_ThrowsJobSheetException_WhenJobNameIsNull()
        {
            /*
            // Arrange
            var mockRepository = new Mock<IJobSheetRepository>();
            var mockLogger = new Mock<ILogger<GetJobSheetUseCase>>();
            var jobName = "";

            mockRepository.Setup(repo => repo.GetFormatedSheetAsync(jobName))
                .ThrowsAsync(new JobSheetException("Job not found"));

            var useCase = new GetJobSheetUseCase(mockRepository.Object, mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<JobSheetException>(() => useCase.Execute(jobName));
        */
        }

        // Test if the Execute method throws ThrowsJobSheetException when the job name is null
        [Fact]
        public async Task Execute_ThrowsArgumentNullException_WhenJobNameIsNull()
        {
            /*
            // Arrange
            var mockRepository = new Mock<IJobSheetRepository>();
            var mockLogger = new Mock<ILogger<GetJobSheetUseCase>>();
            string jobName = null;

            var useCase = new GetJobSheetUseCase(mockRepository.Object, mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<JobSheetException>(() => useCase.Execute(jobName));
            */
        }

        // Test if the Execute method throws ThrowsJobSheetException when the job name is empty
        [Fact]
        public async Task Execute_ThrowsArgumentException_WhenJobNameIsEmpty()
        {
            /*
            // Arrange
            var mockRepository = new Mock<IJobSheetRepository>();
            var mockLogger = new Mock<ILogger<GetJobSheetUseCase>>();
            var jobName = "";

            var useCase = new GetJobSheetUseCase(mockRepository.Object, mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<JobSheetException>(() => useCase.Execute(jobName));
            */
        }

        // Test if the Execute method throws ThrowsJobSheetException when the JSON is malformed
        [Fact]
        public async Task Execute_ThrowsJobSheetException_WhenJsonIsMalformed()
        {
            /*
            // Arrange
            var mockRepository = new Mock<IJobSheetRepository>();
            var mockLogger = new Mock<ILogger<GetJobSheetUseCase>>();
            var jobName = "TestJob";
            var malformedJson = "{ invalid json }";

            mockRepository.Setup(repo => repo.GetFormatedSheetAsync(jobName))
                .ReturnsAsync(malformedJson);

            var useCase = new GetJobSheetUseCase(mockRepository.Object, mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<JobSheetException>(() => useCase.Execute(jobName));
            */
        }

        // Test if the Execute method throws JobSheetException when the job name contains special characters
        [Fact]
        public async Task Execute_ThrowsJobSheetException_WhenJobNameContainsSpecialCharacters()
        {
            /*
            // Arrange
            var mockRepository = new Mock<IJobSheetRepository>();
            var mockLogger = new Mock<ILogger<GetJobSheetUseCase>>();
            var jobName = "Invalid@Job#Name";

            mockRepository.Setup(repo => repo.GetFormatedSheetAsync(jobName))
                .ThrowsAsync(new JobSheetException("Job not found"));

            var useCase = new GetJobSheetUseCase(mockRepository.Object, mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<JobSheetException>(() => useCase.Execute(jobName));
            */
        }
    }
}