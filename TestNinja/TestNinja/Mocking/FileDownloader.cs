using System.Net;

namespace TestNinja.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string path);
    }
    public class FileDownloader: IFileDownloader
    {
        private string _setupDestinationFile;
        public void DownloadFile(string path)
        {
            var client = new WebClient();
            client.DownloadFile(string.Format(path), _setupDestinationFile);
        }
    }
}
