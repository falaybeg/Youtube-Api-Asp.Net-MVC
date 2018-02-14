using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoutubeSampleApiApp.Models;
using YoutubeSampleApiApp.Youtube_API;
using YoutubeSampleApiApp.YoutubeAPI;

namespace YoutubeSampleApiApp.Controllers
{
    public class HomeController : Controller
    {
        VideoApi v = new VideoApi();
        PlaylistApi p = new PlaylistApi();
        PlaylistItemApi pi = new PlaylistItemApi();
        CommentThreadsApi ct = new CommentThreadsApi();
        CommentsApi c = new CommentsApi();
        ChannelBannerApi chb = new ChannelBannerApi();
        ChannelApi ch = new ChannelApi();
        SearchApi s = new SearchApi();
        ThumbnailsApi th = new ThumbnailsApi();
        ActivitiesApi a = new ActivitiesApi();
        WatermarkApi w = new WatermarkApi();


        public ActionResult Index()
        {
            w.UnsetWatermark("UCApZOIRP6xP_86O8_vmD-RA").Wait();    

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}