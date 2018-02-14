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
    public class GuideCategoriesApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public GuideCategory ListVideoCategories()
        {
            GuideCategory guideCategory = null;
            var listRequest = youtubeService.GuideCategories.List("snippet");
            listRequest.RegionCode = "US";

            var response = listRequest.Execute();
            if (response.Items.Count > 0)
            {
                foreach (var item in response.Items)
                {
                    guideCategory = new  GuideCategory();
                    guideCategory.Snippet = new  GuideCategorySnippet();
                    guideCategory.Snippet.ChannelId = response.Items[0].Snippet.ChannelId;
                    guideCategory.Snippet.Title = response.Items[0].Snippet.Title;
                }
            }
            else
            {
                throw new Exception("Guide Categories not found");
            }
            return guideCategory;
        }

    }
}