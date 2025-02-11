using System;
using Entities.Job;
using Xunit;

namespace Back_ASP_SIEP.Tests.DomainTests.EntitiesTests
{
    public class JobSheetTests
    {
        [Fact]
        public void JobSheet_InitializesCorrectly()
        {
            // Arrange
            var name = "TestJob";
            var description = "TestDescription";

            // Act
            var jobSheet = new JobSheet(name, description);

            // Assert
            Assert.Equal(name, jobSheet.Name);
            Assert.Equal(description, jobSheet.Description);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now), jobSheet.Date);
        }

        [Fact]
        public void JobSheet_DefaultDateIsToday()
        {
            // Arrange
            var name = "TestJob";
            var description = "TestDescription";

            // Act
            var jobSheet = new JobSheet(name, description);

            // Assert
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now), jobSheet.Date);
        }

        [Fact]
        public void JobSheet_HandlesNullValues()
        {
            // Arrange
            string name = null;
            string description = null;

            // Act
            var jobSheet = new JobSheet(name, description);

            // Assert
            Assert.Null(jobSheet.Name);
            Assert.Null(jobSheet.Description);
            Assert.Equal(DateOnly.FromDateTime(DateTime.Now), jobSheet.Date);
        }
    }
}