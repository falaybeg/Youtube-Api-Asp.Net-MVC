using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YoutubeSampleApiApp.Youtube_API;

namespace YoutubeSampleApiApp.YoutubeAPI
{
    public class ChannelBannerApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        // max file size 6 MB and jpeg, png... etc files

        public async Task CreateBanner()
        {
            var filePath = @"C:\Users\Admin\Pictures\willing.jpg";

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var createRequest = youtubeService.ChannelBanners.Insert(null,fileStream,"image/jpg");
                await createRequest.UploadAsync();
            }
        }
    }
}