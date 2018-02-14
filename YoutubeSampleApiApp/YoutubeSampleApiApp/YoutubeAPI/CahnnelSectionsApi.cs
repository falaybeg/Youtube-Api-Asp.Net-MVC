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
    public class CahnnelSectionsApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public ChannelSection ListSection(string channelId)
        {
            ChannelSection result = null;

            //  query = "yazilim dersleri";
            var searchRequest = youtubeService.ChannelSections.List("snippet,contentDetails");
            searchRequest.Id = channelId;

            var response = searchRequest.Execute();
            if (response.Items.Count > 0)
            {
                foreach (var item in response.Items)
                {
                    result = new ChannelSection();
                    result.Snippet = new ChannelSectionSnippet();
                    result.ContentDetails = new ChannelSectionContentDetails();

                    result.Snippet.Type = response.Items[0].Snippet.Type;
                    result.Snippet.Style = response.Items[0].Snippet.Style;
                    result.Snippet.ChannelId = response.Items[0].Snippet.ChannelId;
                    result.Snippet.Position = response.Items[0].Snippet.Position;
                    result.ContentDetails.Playlists = response.Items[0].ContentDetails.Playlists;
                }
            }

            return result;
        }
        public async Task CreateSection()
        {
            // list is to add playlist in your ChannelSection
            List<string> playlist = new List<string>();
            playlist.Add("PL9p29QaOsT3d5PtcezQoCvkQvIsV_83Gf");

            ChannelSection body = new ChannelSection();
            body.ContentDetails = new ChannelSectionContentDetails();
            body.Snippet = new ChannelSectionSnippet();
            body.Targeting = new ChannelSectionTargeting();
            body.Snippet.DefaultLanguage = "English";
            body.Snippet.Type = "singlePlaylist";
            body.Snippet.Style = "horizontalRow";
            body.Snippet.Position = 0;
            body.ContentDetails.Playlists = playlist;

            var createRequest = youtubeService.ChannelSections.Insert(body, "snippet,targeting");
            await createRequest.ExecuteAsync();

        }
        public async Task UpdateSection()
        {
            List<string> playlist = new List<string>();
            playlist.Add("PL9p29QaOsT3d5PtcezQoCvkQvIsV_83Gf");

            ChannelSection body = new ChannelSection();
            body.ContentDetails = new ChannelSectionContentDetails();
            body.Snippet = new ChannelSectionSnippet();
            body.Targeting = new ChannelSectionTargeting();
            body.Snippet.DefaultLanguage = "English";
            body.Snippet.Type = "singlePlaylist";
            body.Snippet.Style = "horizontalRow";
            body.Snippet.Position = 0;
            body.ContentDetails.Playlists = playlist;

            var createRequest = youtubeService.ChannelSections.Update(body, "snippet,targeting");
            await createRequest.ExecuteAsync();
        }
        public async Task DeleteSection(string sectionId)
        {
            var deleteRequest = youtubeService.ChannelSections.Delete(sectionId);
            await deleteRequest.ExecuteAsync();
        }

    }
}