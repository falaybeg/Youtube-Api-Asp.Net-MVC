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
    public class ThumbnailsApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        // Picture should be max 2MB 
        // my accout is not eligible for custom thumbnail 
        public async Task SetThumbnail(string videoId)
        {
            if (videoId != null)
            {
                var filePath = @"D:\willing.jpg";
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var setRequest = youtubeService.Thumbnails.Set(videoId, fileStream, "image/jpeg");
                    await setRequest.UploadAsync();
                }
            }  
            else
            {
                throw new Exception("Video not found");
            }
        }
    }
}