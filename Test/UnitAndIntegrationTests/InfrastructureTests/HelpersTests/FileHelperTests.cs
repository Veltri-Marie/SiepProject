using System.IO;
using System.Text;
using Helpers.File;
using InterfaceS.Helpers.File;
using Moq;
using Xunit;

namespace UnitAndIntegrationTests.InfrastructureTests.HelpersTests
{
    public class FileHelperTests
    {
        [Fact]
        public void GetFileContent_ValidPath_ReturnsContent()
        {
            // Arrange
            var mockFileHelper = new Mock<IFileHelper>();
            string testPath = "test.txt";
            string expectedContent = "Hello, World!";
            mockFileHelper.Setup(fh => fh.GetFileContent(It.IsAny<string>())).Returns(expectedContent);

            // Act
            string result = mockFileHelper.Object.GetFileContent(testPath);

            // Assert
            Assert.Equal(expectedContent, result);
        }
    }
}