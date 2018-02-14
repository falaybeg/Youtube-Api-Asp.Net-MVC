using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YoutubeSampleApiApp.Youtube_API;

namespace YoutubeSampleApiApp.YoutubeAPI
{
    public class CaptionsApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        // caption should be max 100MB

        public async Task ListCaption(string videoId)
        {
            Caption caption = null;
            var listRequest = youtubeService.Captions.List("snippet", videoId);
           
            var response = await listRequest.ExecuteAsync();
            if (response.Items.Count > 0)
            {
                caption = new Caption();
                caption.Snippet = new CaptionSnippet();
                caption.Snippet.VideoId = response.Items[0].Snippet.VideoId;
                caption.Snippet.ETag = response.Items[0].Snippet.ETag;
                caption.Snippet.LastUpdated = response.Items[0].Snippet.LastUpdated;
                caption.Snippet.TrackKind = response.Items[0].Snippet.TrackKind;
                caption.Snippet.Language = response.Items[0].Snippet.Language;
                caption.Snippet.AudioTrackType = response.Items[0].Snippet.AudioTrackType;
                caption.Snippet.Status = response.Items[0].Snippet.Status;
                caption.Snippet.IsCC = response.Items[0].Snippet.IsCC;
                caption.Snippet.IsLarge = response.Items[0].Snippet.IsLarge;
            }
            else
            {
                throw new Exception("Video not found");
            }
        }
        public async Task CreateCaption(string videoId)
        {
            Caption caption = new Caption();
            caption.Snippet = new CaptionSnippet();
            caption.Snippet.VideoId = videoId;
            // caption.Id = videoId;
            caption.Snippet.Language = "English";
            caption.Snippet.Name = "English Caption";
            caption.Snippet.IsDraft = false;
            var filePath = @"D:\caption.srt";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var createRequest = youtubeService.Captions.Insert(caption, "snippet", fileStream, "*/*");
                await createRequest.UploadAsync();
            }
        }
        public async Task UpdateCaption(string videoId)
        {
            Caption caption = new Caption();
            caption.Snippet = new CaptionSnippet();
            caption.Snippet.VideoId = videoId;
            // caption.Id = videoId;
            caption.Snippet.Language = "Turkish";
            caption.Snippet.Name = "New Caption";
            caption.Snippet.IsDraft = true;
            var filePath = @"D:\caption.srt";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var createRequest = youtubeService.Captions.Insert(caption, "snippet", fileStream, "*/*");
                await createRequest.UploadAsync();
            }
        }
        public async Task DeleteCaption(string captionId)
        {
            var deleteRequest = youtubeService.Captions.Delete(captionId);
            await deleteRequest.ExecuteAsync();
        }

        // doesn't work 
        public async Task DownloadCaption(string captionId)
        {
            
            var downloadRequest = youtubeService.Captions.Download(captionId);
            //await downloadRequest.DownloadAsync()
        }
    }
}