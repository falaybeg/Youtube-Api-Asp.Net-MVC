using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoutubeSampleApiApp.Models.YoutubeModel
{
    public class ResourceIdResult
    {
        public  string ChannelId { get; set; }
    
        [JsonProperty("kind")]
        public  string Kind { get; set; }
       
        [JsonProperty("playlistId")]
        public  string PlaylistId { get; set; }
      
        [JsonProperty("videoId")]
        public  string VideoId { get; set; }
       
        public  string ETag { get; set; }
    }
}