using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    public class VideoServiceTests
    {
        private readonly Mock<IFileReader> _fileReader;
        private readonly Mock<IVideoRepository> _videoRepository;
        private readonly VideoService  _videoService;
        public VideoServiceTests()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
        }

        [Fact]
        public void ReadVideoTitle_NotExistaingVideo_ReturnErrorMsg()
        {
            _fileReader.Setup(v=>v.Read("video.txt")).Returns("");
            var result = _videoService.ReadVideoTitle();
            Assert.Contains("Error", result);
        }
        [Fact]
        public void GetUnprocessedVideosAsCsv_AllVideoProcced_ReturnEmtyString()
        {
            _videoRepository.Setup(v=>v.GetVideos()).Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.Equal("", result);
        }

        [Fact]
        public void GetUnprocessedVideosAsCsv_AllVideoNotProccedAndProcced_ReturnAllVideos()
        {
            _videoRepository.Setup(v => v.GetVideos()).Returns(new List<Video>
            {
                new Video{ Id=1 },
                new Video{ Id=2 },
                new Video{ Id=3 }
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.Equal("1,2,3", result);
        }
    }
}
