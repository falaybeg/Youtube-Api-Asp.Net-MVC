using KoenZomers.OneDrive.Api;
using KoenZomers.OneDrive.Api.Entities;
using KoenZomers.OneDrive.Api.Enums;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace OneDriveDeneme_23_02_2018.Controllers
{
    public class ApiManager
    {
        
        private static OneDriveApi oneDrive;
        public static OneDriveApi OneApi {
            get
            {
                if(oneDrive == null)
                {
                    Auth();
                }
                return oneDrive;
            }
            set
            {
                oneDrive = value;
            }

        }


        public static OneDriveApi Auth(/*clientId, secretId*/)
        {
            // paster codes which were given from Microsoft Developer page
            string clientId = "clientId code";
            string secretId = "secretId code";
            oneDrive = new OneDriveConsumerApi(clientId, secretId);

            return oneDrive;
        }

        // Get Access Token
        public async Task<string> GetToken(string code)
        {
            // one.AuthenticationRedirectUrl = "http://localhost:50000/";
            oneDrive.AuthorizationToken = code;
            var x = await oneDrive.GetAccessToken();
            return x.AccessToken.ToString();
        }


        /// <summary>
        /// Here is our OneDrive Operation Methods
        /// </summary>
        public static OneDriveDrive GetDrive()
        {
            var getDriveResult = oneDrive.GetDrive();
            return getDriveResult.Result;
        }

        /// <summary>
        ///  Get your OneDrive root path
        /// </summary>
        /// <returns></returns>
        public static OneDriveItem GetDriveRoot()
        {
            var rootDriveResult = oneDrive.GetDriveRoot();
            return rootDriveResult.Result;
        }

        public static OneDriveItemCollection GetAllDriveRootChildren()
        {
            var rootChildrenResult = oneDrive.GetDriveRootChildren();
            return rootChildrenResult.Result;
        }

        public static OneDriveItemCollection GetAllChildrenByPath(string path)
        {
            var childrenResult = oneDrive.GetChildrenByPath(path);
            return childrenResult.Result;
        }

        public static OneDriveItemCollection GetChildrenByFolderId(string folderId)
        {
            var childrenResult = oneDrive.GetChildrenByFolderId(folderId);
            return childrenResult.Result;
        }

        public static OneDriveItem[] GetAllChildrenFromDriveByFolderId(string driveId, string folderId)
        {
            var childrenResult = oneDrive.GetAllChildrenFromDriveByFolderId(driveId,folderId);
            return childrenResult.Result;
        }

        public static OneDriveItemCollection GetChildrenByParentItem(OneDriveItem path)
        {
            var childrenResult = oneDrive.GetChildrenByParentItem(path);
            return childrenResult.Result;
        }

        public static OneDriveItem GetItem(string path)
        {
            var itemResult = oneDrive.GetItem(path);
            return itemResult.Result;
        }

        public static OneDriveItem GetItemById(string Id)
        {
            var itemResult = oneDrive.GetItemById(Id);
            return itemResult.Result;
        }

        public static OneDriveItemCollection GetDriveCameraRollFolder()
        {
            var driveCameraResult = oneDrive.GetDriveCameraRollFolder();
            return driveCameraResult.Result;
        }

        public static OneDriveItemCollection GetDriveDocumentsFolder()
        {
            var driveDocumentResult = oneDrive.GetDriveDocumentsFolder();
            return driveDocumentResult.Result;
        }

        public static OneDriveItemCollection GetDrivePhotosFolder()
        {
            var drivePhotoResult = oneDrive.GetDrivePhotosFolder();
            return drivePhotoResult.Result;
        }


        public static OneDriveItemCollection GetDrivePhotosFolder(string folderId)
        {
            var drivePhotoResult = oneDrive.GetDrivePhotosFolder();
            return drivePhotoResult.Result;
        }

        public static OneDriveItemCollection GetDrivePublicFolder()
        {
            var childrenByFolder = oneDrive.GetDrivePublicFolder();
            return childrenByFolder.Result;
        }

        public static async Task<IList<OneDriveItem>> Search(string query)
        {
            IList<OneDriveItem> searchResult = await oneDrive.Search(query);
            return searchResult;
        }

        public static async Task<IList<OneDriveItem>> Search(string query, string path)
        {
            IList<OneDriveItem> searchResult = await oneDrive.Search(query, path);
            return searchResult;
        }

        public static Task<bool> Delete(string oneDriveItemPath)
        {
            var deleteResult = oneDrive.Delete(oneDriveItemPath);
            return deleteResult;
        }

        public static Task<bool> Delete(OneDriveItem oneDriveItemPath)
        {
            var deleteResult = oneDrive.Delete(oneDriveItemPath);
            return deleteResult;
        }

        public static Task<bool> Copy(string sourceItemPath, string destinationItemPath, string destinationName = null)
        {
            var copyResult = oneDrive.Copy(sourceItemPath, destinationItemPath, destinationName);
            return copyResult;
        }
        public static Task<bool> Copy(OneDriveItem sourceItemPath, OneDriveItem destinationItemPath, string destinationName = null)
        {
            var copyResult = oneDrive.Copy(sourceItemPath, destinationItemPath, destinationName);
            return copyResult;
        }

        public static Task<bool> Move(string sourceItemPath, string destinationItemPath)
        {
            var moveResult = oneDrive.Move(sourceItemPath, destinationItemPath);
            return moveResult;
        }

        public static Task<bool> Move(OneDriveItem sourceItemPath, OneDriveItem destinationItemPath)
        {
            var moveResult = oneDrive.Move(sourceItemPath, destinationItemPath);
            return moveResult;
        }

        public static Task<bool> Rename(string oneDriveItemPath, string name)
        {
            var renameResult = oneDrive.Rename(oneDriveItemPath, name);
            return renameResult;
        }

        public static Task<bool> Rename(OneDriveItem itemPath, string name)
        {
            var renameResult = oneDrive.Rename(itemPath, name);
            return renameResult;
        }

        public static Task<bool> DownloadItem(string itemPath, string saveTo)
        {
            var downloadResult = oneDrive.DownloadItem(itemPath, saveTo);
            return downloadResult;
        }

        public static Stream DownloadItem(string itemPath)
        {
            var downloadResult = oneDrive.DownloadItem(itemPath);
            return downloadResult.Result;
        }

        public static Task<bool> DownloadItemAndSaveAs(string itemPath, string saveAs)
        {
            var downloadResult = oneDrive.DownloadItemAndSaveAs(itemPath, saveAs);
            return downloadResult;
        }

        public static Task<bool> DownloadItemAndSaveAs(OneDriveItem itemPath, string saveAs)
        {
            var downloadResult = oneDrive.DownloadItemAndSaveAs(itemPath, saveAs);
            return downloadResult;
        }

        public static OneDriveItem UploadFile(string filePath, string oneDriveFolder)
        {
            var uploadResult = oneDrive.UploadFile(filePath, oneDriveFolder);
            return uploadResult.Result;
        }

        public static OneDriveItem UploadFileAs(string filePath, string fileName, string oneDriveFolder)
        {
            var uploadResult = oneDrive.UploadFileAs(filePath, fileName, oneDriveFolder);
            return uploadResult.Result;
        }

        public static OneDriveItem UploadFileAs(Stream stream, string fileName, string oneDriveFolder)
        {
            var uploadResult = oneDrive.UploadFileAs(stream, fileName, oneDriveFolder);
            return uploadResult.Result;
        }

        public static OneDriveItem UploadFileAs(Stream stream, string fileName, OneDriveItem oneDriveItem)
        {
            var uploadResult = oneDrive.UploadFileAs(stream, fileName, oneDriveItem);
            return uploadResult.Result;
        }

        public static OneDriveItem CreateFolder(string parentPath, string folderName)
        {
            var createResult = oneDrive.CreateFolder(parentPath, folderName);
            return createResult.Result;
        }

        public static OneDrivePermission ShareItem(OneDriveItem item, OneDriveLinkType linkType)
        {
            var shareResult = oneDrive.ShareItem(item, linkType);
            return shareResult.Result;
        }

        public static OneDriveItemCollection GetChildrenFromDriveByFolderId(string driveId, string folderId)
        {
            var childrenResult = oneDrive.GetChildrenFromDriveByFolderId(driveId, folderId);
            return childrenResult.Result;
        }
    }
}