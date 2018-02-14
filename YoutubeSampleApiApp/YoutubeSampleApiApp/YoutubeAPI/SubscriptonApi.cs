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
    public class SubscriptonApi
    {
        YouTubeService youtubeService = YoutubeApi.Auth();

        public  Subscription ListSubcription(string channelId)
        {
            Subscription subscription = null;
            var listSubsciption = youtubeService.Subscriptions.List("snippet,contentDetails");
            listSubsciption.ChannelId = channelId;
            listSubsciption.MaxResults = 50; 

            var response =  listSubsciption.Execute();
            if(response.Items.Count > 0)
            {
                subscription = new Subscription();
                subscription.Snippet = new SubscriptionSnippet();
                subscription.ContentDetails = new SubscriptionContentDetails();
                subscription.Snippet.ChannelTitle = response.Items[0].Snippet.ChannelTitle;
                subscription.Snippet.Description = response.Items[0].Snippet.Description;
                subscription.Snippet.PublishedAt = response.Items[0].Snippet.PublishedAt.Value;
                subscription.Snippet.Thumbnails = response.Items[0].Snippet.Thumbnails;
                subscription.ContentDetails.TotalItemCount = response.Items[0].ContentDetails.TotalItemCount;
            }
            else
            {
                throw new Exception("Subscriptions not found");
            }
            return subscription;
        }

        public async Task CreateSubcription(string channelId)
        {
            Subscription subscription = new Subscription();
            subscription.Snippet = new SubscriptionSnippet();
            subscription.Snippet.ResourceId = new ResourceId();
            subscription.Snippet.ResourceId.ChannelId = channelId;
            subscription.Snippet.ResourceId.Kind = "youtube#video";

            var subscriptionRequest = youtubeService.Subscriptions.Insert(subscription, "snippet");
            await subscriptionRequest.ExecuteAsync();
        }

        public async Task DeleteSubcription(string channelId)
        {
            var deleteRequest = youtubeService.Subscriptions.Delete(channelId);
            await deleteRequest.ExecuteAsync();
        }

    }
}