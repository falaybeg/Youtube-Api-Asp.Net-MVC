using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoutubeSampleApiApp.Youtube_API;

namespace YoutubeSampleApiApp.YoutubeAPI
{
    public class I18RegionsApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();


        public I18nRegion ListVideoCategories()
        {
            I18nRegion i18Region = null;
            var listRequest = youtubeService.I18nRegions.List("snippet");
            listRequest.Hl = ""; // we can set default

            var response = listRequest.Execute();
            if (response.Items.Count > 0)
            {
                foreach (var item in response.Items)
                {
                    i18Region = new I18nRegion();
                    i18Region.Snippet = new  I18nRegionSnippet();
                    i18Region.Snippet.Gl = response.Items[0].Snippet.Gl;
                    i18Region.Snippet.Name = response.Items[0].Snippet.Name;
                }
            }
            else
            {
                throw new Exception("Categories not found");
            }

            return i18Region;
        }
    }
}