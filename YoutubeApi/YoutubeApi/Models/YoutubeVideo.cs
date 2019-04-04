using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoutubeSampleApiApp.Youtube_API;

namespace YoutubeSampleApiApp.Models
{
    public class YoutubeVideo
    {


        public string Id { get; set; }
        public string title { get; set; }

        public string description { get; set; }
        public DateTime publishedDate { get; set; }
        public string channelId { get; set; }
        public ThumbnailDetails Thumbnails { get; set; }


        //public YoutubeVideo(string id)
        //{
        //    this.Id = id;
        //    YoutubeApi.GetVideoInfo(this);
        //}
    }
}