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
using static Google.Apis.YouTube.v3.VideosResource.RateRequest;

namespace YoutubeSampleApiApp.Youtube_API
{
    public class VideoApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

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
        public async Task CreateVideo()
        {
            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = "Default Video Title";
            video.Snippet.Description = "Default Video Description";
            video.Snippet.Tags = new string[] { "tag1", "tag2" };
            video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            video.Status = new VideoStatus();
            video.Status.PrivacyStatus = "public"; // or "private" or "public"
            var filePath = @"D:\Introduction.mp4"; // Replace with path to actual movie file.

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                await videosInsertRequest.UploadAsync();
            }
        }

        public async Task UpdateVideo()
        {
            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Id = "uzaVE6x81GU";
            video.Snippet.Title = "Kayhan Tutorial";
            video.Snippet.Description = "Bu videoda yazilim egitimi verilmektedir";
            video.Snippet.CategoryId = "2"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            video.Snippet.DefaultLanguage = "en";
            video.Snippet.Tags = new string[] { "sample", "deneme" };
            video.Status = new VideoStatus();
            video.Status.PrivacyStatus = "public";

            var updateRequest = youtubeService.Videos.Update(video, "snippet,status");
            await updateRequest.ExecuteAsync();
        }

        public async Task DeleteVideo(string id)
        {
            var videosInsertRequest = youtubeService.Videos.Delete(id.ToString());
            await videosInsertRequest.ExecuteAsync();
        }

        public List<YoutubeVideo> GetAllVideo()
        {
            YoutubeVideo videos = null;

            return null;
        }

        public async Task RateVideo(string id)
        {
            /*
             RatingEnum.Like
             RatingEnum.Dislike
             RatingEnum.None
             */
            var rateRequest = youtubeService.Videos.Rate(id, RatingEnum.None);
            await rateRequest.ExecuteAsync();
        }

        public async Task GetRatingVideo(string id)
        {
            var getRatingRequest = youtubeService.Videos.GetRating(id);
            await getRatingRequest.ExecuteAsync();
        }

        public async Task ReportAbuseVideo()
        {
            // here we have to get VideoAbuseReportReasons list from another service.
            VideoAbuseReport report = new VideoAbuseReport();
            report.ReasonId = "30";
            report.VideoId = "0XeKFxFhHbQ";

            var reportRequest = youtubeService.Videos.ReportAbuse(report);
            await reportRequest.ExecuteAsync();
        }


    }
}