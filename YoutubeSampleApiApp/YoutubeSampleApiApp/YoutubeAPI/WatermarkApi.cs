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
    public class WatermarkApi
    {
        // we can upload max 10 MB and also image/jpeg, image/png
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public async Task SetWatermark(string channelId)
        {
            InvideoBranding body = new InvideoBranding();
            body.Timing = new InvideoTiming();
            body.Timing.Type = "offsetFromStart"; // from start 
            body.Timing.OffsetMs = 500; // after 10 second
            var filePath = @"D:\willing.jpg"; 

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var setRequest = youtubeService.Watermarks.Set(body, channelId, fileStream, "image/jpeg");
                await setRequest.UploadAsync();
            }
        }

        public async Task UnsetWatermark(string channelId)
        {
            var unsetRequest = youtubeService.Watermarks.Unset(channelId);
            await unsetRequest.ExecuteAsync();
        }
    }
}