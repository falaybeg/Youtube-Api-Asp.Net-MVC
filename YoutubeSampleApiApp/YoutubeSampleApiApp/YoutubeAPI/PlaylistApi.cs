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

    public class PlaylistApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public Playlist GetPlaylistList(string channelId)
        {
            Playlist playList = null;
            if (channelId != null)
            {
                var listRequest = youtubeService.Playlists.List("snippet,contentDetails");
                listRequest.ChannelId = channelId;
                listRequest.MaxResults = 25;

                var response =   listRequest.Execute();
                if(response.Items.Count > 0)
                {
                    foreach(var item in response.Items)
                    {
                        playList = new Playlist();
                        playList.Snippet = response.Items[0].Snippet;
                        playList.ContentDetails = response.Items[0].ContentDetails;
                    }
                }
            }
            else
            {
                throw new Exception("Playlist not found");
            }
            return playList;
        }

        public async Task CreatePlayList()
        {
            Playlist playlist = new Playlist();
            playlist.Snippet = new PlaylistSnippet();
            playlist.Status = new PlaylistStatus();

            playlist.Snippet.Title = "Playlist New";
            playlist.Snippet.Description = "It has been created with Youtube API v3";
            playlist.Status.PrivacyStatus = "public";

            if (playlist != null)
            {
                var insertRequest = youtubeService.Playlists.Insert(playlist, "snippet,status");
                await insertRequest.ExecuteAsync();
            }
            else
            {
                throw new Exception("Playlist Information is not enough");
            }
        }

        public async Task DeletePlaylist(string id)
        {
            if (id != null)
            {
                var deleteRequest = youtubeService.Playlists.Delete(id);
                await deleteRequest.ExecuteAsync();
            }
            else
                throw new Exception("Playlist not found");
        }

        public async Task UpdatePlaylist(string playlistId)
        {
            Playlist playlist = new Playlist();
            playlist.Snippet = new PlaylistSnippet();
            playlist.Status = new PlaylistStatus();

            playlist.Id = playlistId;
            playlist.Snippet.Title = "Sample Deneme";
            playlist.Snippet.Description = "It has been created with Youtube API v3";
            playlist.Status.PrivacyStatus = "public";


            var updateRequest = youtubeService.Playlists.Update(playlist, "snippet,status");
            await updateRequest.ExecuteAsync();

        }
    }
}