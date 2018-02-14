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
    public class ActivitiesApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public Activity ListActivities(string channelId)
        {
            Activity activity = null;

            if(channelId != null)
            {
                var listRequest = youtubeService.Activities.List("snippet,contentDetails");
                listRequest.ChannelId = channelId;
                listRequest.MaxResults = 50;

                var response = listRequest.Execute();
                if(response.Items.Count > 0)
                {
                    foreach(var item in response.Items)
                    {
                        activity = new Activity();
                        activity.Snippet = new ActivitySnippet();

                        activity.Snippet.PublishedAt = response.Items[0].Snippet.PublishedAt.Value;
                        activity.Snippet.ChannelId = response.Items[0].Snippet.ChannelId;
                        activity.Snippet.ChannelTitle = response.Items[0].Snippet.ChannelTitle;
                        activity.Snippet.Title = response.Items[0].Snippet.Title;
                        activity.Snippet.Description = response.Items[0].Snippet.Description;
                        activity.Snippet.Thumbnails = response.Items[0].Snippet.Thumbnails;
                        activity.Snippet.Type = response.Items[0].Snippet.Type;

                        activity.ContentDetails = new ActivityContentDetails();
                        activity.ContentDetails.Like = response.Items[0].ContentDetails.Like;

                    }
                }
            }
            return activity;
        }

        public async Task CreateActivity()
        {
            Activity body = new Activity();
            body.Snippet = new ActivitySnippet();
            body.Snippet.Description = "This is sample Activity";
            body.ContentDetails = new ActivityContentDetails();
            body.ContentDetails.Bulletin.ResourceId.Kind = "youtube#video";

            var createRequest = youtubeService.Activities.Insert(body, "snippet");
            await createRequest.ExecuteAsync();
        }

    }
}