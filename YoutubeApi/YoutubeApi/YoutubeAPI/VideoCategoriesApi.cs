using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YoutubeSampleApiApp.Youtube_API;

namespace YoutubeSampleApiApp.YoutubeAPI
{
    public class VideoCategoriesApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public VideoCategory ListVideoCategories()
        {
            VideoCategory videoCategory = null;
            var listRequest = youtubeService.VideoCategories.List("snippet");
            listRequest.RegionCode = "US";

            var response = listRequest.Execute();
            if (response.Items.Count > 0)
            {
                foreach (var item in response.Items)
                {
                    videoCategory = new VideoCategory();
                    videoCategory.Snippet = new VideoCategorySnippet();
                    videoCategory.Snippet.ChannelId = response.Items[0].Snippet.ChannelId;
                    videoCategory.Snippet.Title = response.Items[0].Snippet.Title;
                    videoCategory.Snippet.Assignable = response.Items[0].Snippet.Assignable;
                }
            }
            else
            {
                throw new Exception("Categories not found");
            }


            return videoCategory;

        }
    }
}