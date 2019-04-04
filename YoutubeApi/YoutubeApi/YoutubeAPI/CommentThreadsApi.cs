using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoutubeSampleApiApp.Youtube_API;
using Google.Apis.YouTube.v3;
using System.Threading.Tasks;
using static Google.Apis.YouTube.v3.ActivitiesResource;
using Google.Apis.YouTube.v3.Data;

namespace YoutubeSampleApiApp.YoutubeAPI
{
    public class CommentThreadsApi
    {
        YouTubeService youtubeService = YoutubeApi.Auth();

        public async Task CreateCommentThread()
        {
            CommentThread comment = null;
            comment = new CommentThread();
            comment.Snippet = new CommentThreadSnippet();
            comment.Snippet.TopLevelComment = new Comment();
            comment.Snippet.TopLevelComment.Snippet = new CommentSnippet();

            comment.Snippet.ChannelId = "UCApZOIRP6xP_86O8_vmD-RA";
            comment.Snippet.VideoId = "f-x6_3QO1c0";
            comment.Snippet.TopLevelComment.Snippet.TextDisplay = "Deneme bir yorumdur";

            var createRequest = youtubeService.CommentThreads.Insert(comment, "snippet");
            await createRequest.ExecuteAsync();

        }
        public async Task UpdateCommentThread(string commentId)
        {
            CommentThread comment = null;
            if (commentId != null)
            {
                comment = new CommentThread();
                comment.Snippet = new CommentThreadSnippet();
                comment.Snippet.TopLevelComment = new Comment();
                comment.Snippet.TopLevelComment.Snippet = new CommentSnippet();
                comment.Id = commentId;
                comment.Snippet.TopLevelComment.Snippet.TextDisplay = "Deneme bir yorumdur";

                var updateRequest = youtubeService.CommentThreads.Update(comment, "snippet");
                await updateRequest.ExecuteAsync();

            }
        }

        public async Task<CommentThreadListResponse> ListCommentThreads(string videoId)
        {
            CommentThreadListResponse commentThread = null;
            if (videoId != null)
            {
                var listRequest = youtubeService.CommentThreads.List("snippet,replies");
                listRequest.VideoId = videoId;

                var response = await listRequest.ExecuteAsync();
                if (response.Items.Count > 0)
                {
                    foreach (var item in response.Items)
                    {
                        commentThread = new CommentThreadListResponse();
                        response.Items = commentThread.Items;
                        response.Kind = commentThread.Kind;
                    }
                }
            }
            else
            {
                throw new Exception("Not found Commets");
            }
            return commentThread;
        }
    }
}


    

    
