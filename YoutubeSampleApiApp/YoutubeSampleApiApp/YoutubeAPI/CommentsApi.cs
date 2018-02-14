using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YoutubeSampleApiApp.Youtube_API;
using static Google.Apis.YouTube.v3.CommentsResource;
using static Google.Apis.YouTube.v3.CommentThreadsResource.ListRequest;

namespace YoutubeSampleApiApp.YoutubeAPI
{
    public class CommentsApi 
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();


        public async Task ListComments(string parentId)
        {
            CommentListResponse comment = null;
            
            if (parentId != null)
            {
                var listRequest = youtubeService.Comments.List("snippet");
                var response = await listRequest.ExecuteAsync();

                if(response.Items.Count > 0)
                {
                    foreach(var item in response.Items)
                    {
                        comment = new CommentListResponse();
                        comment.Items = response.Items;
                    }
                }
            }
            else
            {
                throw new Exception("Not found any comment");
            }
        }
        public async Task CreateComment(string parentId)
        {
            Comment comment = new Comment();
            comment.Snippet = new CommentSnippet();
            comment.Snippet.ParentId = parentId;
            comment.Snippet.TextOriginal = "This is sample reply to your comment.";

            var createRequest = youtubeService.Comments.Insert(comment, "snippet");
            await createRequest.ExecuteAsync();
        }
        public async Task UpdateComment()
        {
            Comment comment = new Comment();
            comment.Snippet = new CommentSnippet();
            comment.Id = "";
            comment.Snippet.TextOriginal = "This is sample reply to your comment.";

            var updateRequest = youtubeService.Comments.Update(comment, "snippet");
            await updateRequest.ExecuteAsync();
        }
        public async Task DeleteComment(string commentId)
        {
            var deleteRequest = youtubeService.Comments.Delete(commentId);
            await deleteRequest.ExecuteAsync();
        }
        public async Task MarkAsSpamComment(string commentId)
        {
            var markAsSpamRequest = youtubeService.Comments.MarkAsSpam(commentId);
            await markAsSpamRequest.ExecuteAsync();
        }
        public async Task SetModerationStatusComment(string commentId)
        {
            var moderationStatus = SetModerationStatusRequest.ModerationStatusEnum.HeldForReview;
            var setModerationRequest = youtubeService.Comments.SetModerationStatus(commentId, moderationStatus);
            await setModerationRequest.ExecuteAsync();
        }
       
    }
}