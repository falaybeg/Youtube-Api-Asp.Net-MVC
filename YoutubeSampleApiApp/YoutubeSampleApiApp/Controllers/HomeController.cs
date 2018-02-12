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

        public ActionResult Index()
        {
            //string id = "UCGLu20iKuz8ZzZ8xYv5YsXA";
            // p.GetPlaylist(id);

            string id = "7s8pMXrNDtY";
            var result = v.GetVideo(id);
            return View(result);
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