using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoutubeSampleApiApp.Models;
using YoutubeSampleApiApp.Youtube_API;

namespace YoutubeSampleApiApp.Controllers
{
    public class HomeController : Controller
    {
        VideoApi p = new VideoApi();
       
        public ActionResult Index()
        {


            string id = "uF-wQm0Pi9o";
            
            var result = p.GetVideoInfo(id);

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