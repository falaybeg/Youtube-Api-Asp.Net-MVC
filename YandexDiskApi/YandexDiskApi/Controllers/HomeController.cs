using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YandexDisk.Client;
using YandexDisk.Client.Http;
using YandexDisk.Client.Protocol;
using YandexDiskApiSample.YandexDisk;

namespace YandexDiskApiSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string access_token)
        {
            ApiManager.access_token = access_token;
            return View();
        }

        // Authenticate YandexDisk API
        public ActionResult Auth()
        {
            // Paste clientId which was taken from Yandex Developer page.
            string clientId = "Paste Client ID code";
            string redirectLink = ApiManager.RedirectUri(clientId);
            return Redirect(redirectLink);
        }

        // Upload file from your computer to YandexDrive account
        public ActionResult UploadFile()
        {
            string path = @"D:\willing.jpg";
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);

            Link link = ApiManager.GetUploadLink("resources/upload", false);

            ApiManager.UploadFile(link, stream);
            return View("Index");
        }

        // Delete file from your account
        public ActionResult DeleteFile()
        {
            DeleteFileRequest file = new DeleteFileRequest();
            // file.Path = "Folder/Deniz.jpg";
            file.Path = "Deniz.jpg";
            ApiManager.DeleteFile(file);

            return View("Index");
        }

        // Create new folder in your YandexDrive account
        public ActionResult CreateFolder()
        {
            string folderName = "SampleFolder";
            ApiManager.CreateFolder(folderName);

            return View("Index");
        }
        
        // Copy files from one folder to another one. 
        public ActionResult CopyFile()
        {
            CopyFileRequest file = new CopyFileRequest();
            file.From = "Photo.jpg";
            file.Path = "/Music/Photo.jpg";
            ApiManager.CopyFile(file);

            return View("Index");
        }

        // Move files from one folder to another one. 
        public ActionResult MoveFile()
        {
            MoveFileRequest file = new MoveFileRequest();
            file.From = "Sea.jpg";
            file.Path = "/Music/Sea.jpg";
            ApiManager.MoveFile(file);

            return View("Index");
        }

        // Empty your trash (delete permanently your files)
        public ActionResult EmptyTrash()
        {
            string specificFile = "SampleFolder";
            // specificFile = null;  --> it will be clear completely
            ApiManager.EmptyTrash(specificFile);
            return View("Index");
        }


        // Restore deleted item from trash  
        public ActionResult RestoreFromTrash()
        {
            RestoreFromTrashRequest restoreFile = new RestoreFromTrashRequest();
            restoreFile.Path = "deniz.jpg";
            restoreFile.Name = "Deneme.jpg";
            //restoreFile.Overwrite = true;
            ApiManager.RestoreFromTrash(restoreFile);
            return View("Index");
        }

        // Get information about your last uploaded file
        public ActionResult GetLastUploadInfo(LastUploadedResourceRequest lastInfo)
        {
            List<MediaType> list = new List<MediaType>();
            list.Add(MediaType.Image);
            list.Add(MediaType.Data);


            lastInfo.Limit = 25;
            ApiManager.GetLastUploadInfo(lastInfo);
            return View("Index");
        }
        // Get information about your YandexDrive trash
        public ActionResult GetTrashInfo()
        {
            Resource infor = new Resource();
            return View("Index");
        }
    }
}