using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoutubeSampleApiApp.Models.YoutubeModel;

namespace YoutubeSampleApiApp.Models.YoutubeModel
{
    public class SearchResultViewModel
    {
        //public SnippetResult SnippetResult { get; set; }
        //public ResourceIdResult ResourceIdResult { get; set; }

            // -------------- ResourceId Model ---------------

        public  string Kind { get; set; }
        public  string PlaylistId { get; set; }
        public  string VideoId { get; set; }
        public  string ETag { get; set; }


        // ------ Snippet Result Model --------------
        public  string ChannelId { get; set; }

        public  string ChannelTitle { get; set; }

        public  string Description { get; set; }

        public  string LiveBroadcastContent { get; set; }

        public  string PublishedAtRaw { get; set; }

        public  DateTime? PublishedAt { get; set; }

        public  ThumbnailDetails Thumbnails { get; set; }

        public  string Title { get; set; }



    }
}