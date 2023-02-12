using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader _fileReader;
        private readonly IVideoRepository _videoRepository;
        public VideoService(IFileReader fileReader, IVideoRepository videoRepository)
        {
            _fileReader = fileReader;
            _videoRepository = videoRepository;   
        }
        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            var videos = _videoRepository.GetVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }

    public class VideoRepository : IVideoRepository
    {
         public List<Video> GetVideos()
        {
            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                return videos;
            }
        }
    }

    public  interface IVideoRepository
    {
        List<Video> GetVideos();
    }
}