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

namespace YandexDiskApiSample.YandexDisk
{
    public class ApiManager
    {
   
        public static  string access_token  ;
        private static IDiskApi api;

        public static IDiskApi yandexApi {

            get
            {
                if(api == null)
                {
                    Auth();
                }
                return api;
            }
            set
            {
                api = value;
            }

        }

        // Created instance after authentication 
        public static IDiskApi Auth()
        {
            api = new DiskHttpApi(access_token);
            return api;
        }

        // Yandex Disk redirection link for authentication and login
        public static string RedirectUri(string clientId)
        {
          string redirectUrl = @"https://oauth.yandex.com/authorize?response_type=token&client_id="+clientId;

            return redirectUrl;
        }


        public static Task UploadLink(string link, bool stream)
        {
            var upload = yandexApi.Files.GetUploadLinkAsync(link, stream);
            return upload;
        }


        public static Task UploadFile(Link link, FileStream stream)
        {
            var upload = yandexApi.Files.UploadAsync(link,stream);
            return upload;
        }

        public static Stream DownloadFile(Link link)
        {
            var download = yandexApi.Files.DownloadAsync(link);
            return download.Result;
        }

        public static Link GetDownloadLink(string path)
        {
            var downloadLink = yandexApi.Files.GetDownloadLinkAsync(path);
            return downloadLink.Result;
        }

        public static Link GetUploadLink(string path, bool overwrite)
        {
            var getUpload = yandexApi.Files.GetUploadLinkAsync(path, overwrite);
            return getUpload.Result;
        }

        public static Link DeleteFile(DeleteFileRequest file)
        {
            var delete = yandexApi.Commands.DeleteAsync(file);
            return delete.Result;
        }
        public static Link CreateFolder(string folderName)
        {
            var createFolder = yandexApi.Commands.CreateDictionaryAsync(folderName);
            return createFolder.Result;
        }

        public static Link CopyFile(CopyFileRequest file)
        {
            var copy = yandexApi.Commands.CopyAsync(file);
            return copy.Result;
        }

        public static Link MoveFile(MoveFileRequest file)
        {
            var move = yandexApi.Commands.MoveAsync(file);
            return move.Result;
        }

        public static Link EmptyTrash(string path)
        {
            var emptyTrash = yandexApi.Commands.EmptyTrashAsync(path);
            return emptyTrash.Result;
        }

        public static Link RestoreFromTrash(RestoreFromTrashRequest file)
        {
            var restore = yandexApi.Commands.RestoreFromTrashAsync(file);
            return restore.Result;
        }

        public static Disk GetDiskInfo()
        {
            var diskInfo = yandexApi.MetaInfo.GetDiskInfoAsync();
            return diskInfo.Result;
        }

        public static FilesResourceList GetFilesInfo(FilesResourceRequest file)
        {
            var filesInfo = yandexApi.MetaInfo.GetFilesInfoAsync(file);
            return filesInfo.Result;
        }

        public static Resource GetInfo(ResourceRequest file)
        {
            var getInfo = yandexApi.MetaInfo.GetInfoAsync(file);
            return getInfo.Result;
        }

        public static LastUploadedResourceList GetLastUploadInfo(LastUploadedResourceRequest file)
        {
            var getLastUpload = yandexApi.MetaInfo.GetLastUploadedInfoAsync(file);
            return getLastUpload.Result;
        }

        public static Resource GetTrashInfo(ResourceRequest file)
        {
            var trashInfo = yandexApi.MetaInfo.GetTrashInfoAsync(file);
            return trashInfo.Result;
        }
    }
}
