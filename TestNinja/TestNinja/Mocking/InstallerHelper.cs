using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloader _fileDownloader;
        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }
        public bool DownloadInstaller(string customerName, string installerName)
        {
            var path = string.Format("http://example.com/{0}/{1}", customerName, installerName);
            try
            {
                _fileDownloader.DownloadFile(path);
                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}