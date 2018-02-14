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
    public class PlaylistItemApi
    {
        YouTubeService youtubeService = YoutubeApi.Auth();

        public PlaylistItem GetPlaylistItem(string playlistId)
        {
            PlaylistItem playlistItem = null;
            
            if (playlistId != null)
            {
                var itemListRequest = youtubeService.PlaylistItems.List("snippet,contentDetails,status");
                itemListRequest.PlaylistId = playlistId;
                itemListRequest.MaxResults = 50;
                
                var response = itemListRequest.Execute();
                if(response.Items.Count > 0)
                {
                    foreach(var item in response.Items)
                    {
                        playlistItem = new PlaylistItem();
                        playlistItem.Snippet = response.Items[0].Snippet;
                        playlistItem.ContentDetails = response.Items[0].ContentDetails;
                        playlistItem.Status = response.Items[0].Status;
                    }
                }
            }
            else
            {
                throw new Exception("Playlist items not found");
            }

            return playlistItem;
        }

        public async Task InsertPlaylistItem()
        {
            PlaylistItem playlistItem = new PlaylistItem();
            playlistItem.Snippet = new PlaylistItemSnippet();
            playlistItem.Snippet.ResourceId = new ResourceId();
            playlistItem.Snippet.PlaylistId = "PL9p29QaOsT3d5PtcezQoCvkQvIsV_83Gf";
            playlistItem.Snippet.ResourceId.Kind = "youtube#video";
            playlistItem.Snippet.ResourceId.VideoId = "f-x6_3QO1c0";

            var insertRequest = youtubeService.PlaylistItems.Insert(playlistItem, "snippet");
            await insertRequest.ExecuteAsync();
        }

        // it does not work
        public async Task UpdatePlaylistItem()
        {
            PlaylistItem playlistItem = new PlaylistItem();
            playlistItem.Snippet = new PlaylistItemSnippet();
            playlistItem.Snippet.ResourceId = new ResourceId();
            playlistItem.Snippet.PlaylistId = "PL9p29QaOsT3dv3GpQdwVlkT1Iv7xhJYIX";
            playlistItem.Snippet.ResourceId.Kind = "youtube#video";
            playlistItem.Snippet.ResourceId.VideoId = "uzaVE6x81GU";
            playlistItem.Status = new PlaylistItemStatus();
            playlistItem.Status.PrivacyStatus = "private";
            playlistItem.Snippet.Position = 0;

            var insertRequest = youtubeService.PlaylistItems.Update(playlistItem, "snippet");
            await insertRequest.ExecuteAsync();
        }

        // it doesn't work 
        public async Task DeletePlaylistItem(string playlistItemId) 
        {
            
            string playlistId = "PL9p29QaOsT3dv3GpQdwVlkT1Iv7xhJYIX";
          

            if (playlistItemId != null)
            {
                PlaylistItem playlistItem = new PlaylistItem();
                playlistItem.Snippet = new PlaylistItemSnippet();
                playlistItem.Snippet.PlaylistId = playlistId;
                playlistItem.Id = playlistItemId;
                var deleteRequest = youtubeService.PlaylistItems.Delete(playlistItemId);
              
                await deleteRequest.ExecuteAsync();
            }
            else
            {
                throw new Exception("Playlist Item not found");
            }
        }
    }
}