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
    public class ChannelApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public async Task ListChannel(string channelId)
        {
            Channel channel = null;
            if(channelId != null)
            {
                var listRequest = youtubeService.Channels.List("snippet,contentDetails,statistics");
                listRequest.Id = channelId;

                var response = await listRequest.ExecuteAsync();
                if(response.Items.Count > 0)
                {
                    channel = new Channel();
                    channel.ContentDetails = new ChannelContentDetails();
                    channel.Snippet = new ChannelSnippet();
                    channel.Statistics = new ChannelStatistics();

                    channel.ContentDetails.RelatedPlaylists = response.Items[0].ContentDetails.RelatedPlaylists;
                    channel.Snippet.Title = response.Items[0].Snippet.Title;
                    channel.Snippet.Description = response.Items[0].Snippet.Description;
                    channel.Snippet.PublishedAt = response.Items[0].Snippet.PublishedAt.Value;
                    channel.Snippet.Thumbnails = response.Items[0].Snippet.Thumbnails;
                    channel.Statistics.VideoCount = response.Items[0].Statistics.VideoCount;
                    channel.Statistics.ViewCount = response.Items[0].Statistics.ViewCount;
                    channel.Statistics.CommentCount = response.Items[0].Statistics.CommentCount;
                    channel.Statistics.SubscriberCount = response.Items[0].Statistics.SubscriberCount;
                }
                else
                {
                    throw new Exception("Not found information about channel");
                }
            }
        }

        public async Task UpdateChannel(string channelId)
        {
            Channel channel = new Channel();
            channel.BrandingSettings = new ChannelBrandingSettings();
            channel.BrandingSettings.Channel = new ChannelSettings();
            channel.Id = channelId;
            channel.BrandingSettings.Channel.DefaultLanguage = "en";
            channel.BrandingSettings.Channel.Description = "Bu channel bir denemedir";
            channel.BrandingSettings.Channel.ETag = "deneme,sample";
            channel.BrandingSettings.Channel.FeaturedChannelsTitle = "Hello Channel";


            var updateRequest = youtubeService.Channels.Update(channel, "snippet");
            await updateRequest.ExecuteAsync();

        }
    }
}