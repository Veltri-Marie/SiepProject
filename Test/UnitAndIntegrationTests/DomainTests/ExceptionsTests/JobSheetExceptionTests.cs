// filepath: /c:/_Code/SiepProject-dev/src/Back_ASP_SIEP.Domain/Exceptions/JobSheetExceptionTest.cs
using System;
using Exceptions.Job;
using Xunit;

namespace ack_ASP_SIEP.Tests.DomainTests.EntitiesTests
{
    public class JobSheetExceptionTest
    {
        [Fact]
        public void DefaultConstructor_InitializesCorrectly()
        {
            // Act
            var exception = new JobSheetException();

            // Assert
            Assert.NotNull(exception);
            Assert.Equal("002", exception.ERROR_CODE);
        }

        [Fact]
        public void ConstructorWithMessage_InitializesCorrectly()
        {
            // Arrange
            var message = "Test message";

            // Act
            var exception = new JobSheetException(message);

            // Assert
            Assert.NotNull(exception);
            Assert.Equal(message, exception.Message);
            Assert.Equal("002", exception.ERROR_CODE);
        }

        [Fact]
        public void ConstructorWithMessageAndInnerException_InitializesCorrectly()
        {
            // Arrange
            var message = "Test message";
            var innerException = new Exception("Inner exception");

            // Act
            var exception = new JobSheetException(message, innerException);

            // Assert
            Assert.NotNull(exception);
            Assert.Equal(message, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
            Assert.Equal("002", exception.ERROR_CODE);
        }
    }
}