using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoutubeSampleApiApp.Youtube_API;

namespace YoutubeSampleApiApp.YoutubeAPI
{
    public class VideoAbuseReportReasons
    {

        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public VideoAbuseReportReason ListVideoCategories()
        {
            VideoAbuseReportReason videoAbuseReportReason = null;
            var listRequest = youtubeService.VideoAbuseReportReasons.List("snippet");
            listRequest.Hl = ""; // it is default from system

            var response = listRequest.Execute();
            if (response.Items.Count > 0)
            {
                foreach (var item in response.Items)
                {
                    videoAbuseReportReason = new VideoAbuseReportReason();
                    videoAbuseReportReason.Snippet = new  VideoAbuseReportReasonSnippet();
                    videoAbuseReportReason.Snippet.Label = response.Items[0].Snippet.Label;
                    videoAbuseReportReason.Snippet.SecondaryReasons = response.Items[0].Snippet.SecondaryReasons;
                }
            }
            else
            {
                throw new Exception("VideoAbuseReportReason not found");
            }

            return videoAbuseReportReason;
        }
    }
}