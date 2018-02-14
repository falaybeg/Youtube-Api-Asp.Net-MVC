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
    public class SearchApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public SearchResult ListSearchedVideo(string query)
        {
            SearchResult result = null;

          //  query = "yazilim dersleri";
            var searchRequest = youtubeService.Search.List("snippet");
            searchRequest.Q = query;
            searchRequest.MaxResults = 50;

            var response =  searchRequest.Execute();
            if (response.Items.Count > 0)
            {
                foreach (var item in response.Items)
                {
                    result = new SearchResult();
                    result.Snippet = new SearchResultSnippet();
                    result.Snippet.PublishedAt = item.Snippet.PublishedAt.Value;
                    result.Snippet.ChannelId = item.Snippet.ChannelId;
                    result.Snippet.ChannelTitle = item.Snippet.ChannelTitle;
                    result.Snippet.Title = item.Snippet.Title;
                    result.Snippet.Description = item.Snippet.Description;
                    result.Snippet.Thumbnails = item.Snippet.Thumbnails;
                    result.Snippet.LiveBroadcastContent = item.Snippet.LiveBroadcastContent;
                }
            }

            return result;
        }
    }
}