using Moq;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;
        public InstallerHelperTests()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Fact]
        public void DownloadInstaller_FileSuccessDownloaded_ReturnTrue()
        {
            _fileDownloader.Setup(f => f.DownloadFile("path"));
            var result = _installerHelper.DownloadInstaller("name", "destination");
            Assert.True(result);
        }

        [Fact]
        public void DownloadInstaller_FileFailDownloaded_ReturnFalse()
        {
            _fileDownloader.Setup(f => f.DownloadFile(It.IsAny<string>())).Throws(new WebException());
            var result = _installerHelper.DownloadInstaller("name", "destination");
            Assert.False(result);
        }
    }

}
