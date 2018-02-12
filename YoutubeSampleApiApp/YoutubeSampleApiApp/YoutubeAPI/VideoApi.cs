using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using YoutubeSampleApiApp.Models;

namespace YoutubeSampleApiApp.Youtube_API
{
    public class VideoApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public async Task UploadVideo()
        {
            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = "Default Video Title";
            video.Snippet.Description = "Default Video Description";
            video.Snippet.Tags = new string[] { "tag1", "tag2" };
            video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            video.Status = new VideoStatus();
            video.Status.PrivacyStatus = "unlisted"; // or "private" or "public"
            var filePath = @"Introduction.mp4"; // Replace with path to actual movie file.

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                await videosInsertRequest.UploadAsync();
            }
        }

        public async Task DeleteVideo(string id)
        {
            UserCredential credential;
            using (var stream = new FileStream("youtube_client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] 
                    {
                        
                        YouTubeService.Scope.YoutubeReadonly
                   
                    },
                    "user",
                    CancellationToken.None
                );
            }

            youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApiKey = "AIzaSyD6WcIzb523-YYMz2vCXBJMeG4S7OGvM7Y",
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
            });


            var videosInsertRequest = youtubeService.Videos.Delete(id.ToString());
            await videosInsertRequest.ExecuteAsync();
                     
        }

        public YoutubeVideo GetVideo(string id)
        {
            YoutubeVideo video = null;
            var videoRequest = youtubeService.Videos.List("snippet");
            videoRequest.Id = id;

            var response = videoRequest.Execute();
            if (response.Items.Count > 0)
            {
                video = new YoutubeVideo();
                video.title = response.Items[0].Snippet.Title;
                video.description = response.Items[0].Snippet.Description;
                video.publishedDate = response.Items[0].Snippet.PublishedAt.Value;
                video.channelId = response.Items[0].Snippet.ChannelId;
                video.Thumbnails = response.Items[0].Snippet.Thumbnails;
            }
            else
            {
                throw new Exception("Video not found");
            }
            return video;
        }

        public List<YoutubeVideo> GetAllVideo()
        {
            YoutubeVideo videos = null;

            return null;
        }
    }
}