using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoutubeSampleApiApp.Models.YoutubeModel
{
    public class SnippetResult
    {
        [JsonProperty("channelId")]
        public  string ChannelId { get; set; }
       
        [JsonProperty("channelTitle")]
        public  string ChannelTitle { get; set; }
      
        [JsonProperty("description")]
        public  string Description { get; set; }
       
        [JsonProperty("liveBroadcastContent")]
        public  string LiveBroadcastContent { get; set; }
     
        [JsonProperty("publishedAt")]
        public  string PublishedAtRaw { get; set; }
       
        [JsonIgnore]
        public  DateTime? PublishedAt { get; set; }
       
        [JsonProperty("thumbnails")]
        public  ThumbnailDetails Thumbnails { get; set; }

        [JsonProperty("title")]
        public  string Title { get; set; }
      
        public  string ETag { get; set; }
    }
}
