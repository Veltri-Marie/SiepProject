/*
using Dtos.Job.Response;
using Dtos.Job.Response;
using Extensions.Job;
using Xunit;
*/

namespace Back_ASP_SIEP.Tests.ApplicationTests.ExtensionsTests
{
    //#TODO: Adapt tests to models instead of dtos
    public class JobExtensionsTests
    {
        [Fact]
        public void ToJobSheetResponse_MapsCorrectly()
        {
            /*
            // Arrange
            var jobSheetDetails = new JobSheetDetails("TestJob", "TestDescription");

            // Act
            var result = jobSheetDetails.ToJobSheetResponse();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("TestJob", result.Name);
            Assert.Equal("TestDescription", result.Description);
            */
        }

        [Fact]
        public void ToJobSheetResponse_HandlesNullValues()
        {
            /*
            // Arrange
            var jobSheetDetails = new JobSheetDetails(null, null);

            // Act
            var result = jobSheetDetails.ToJobSheetResponse();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Name);
            Assert.Null(result.Description);
            */
        }
    }
}