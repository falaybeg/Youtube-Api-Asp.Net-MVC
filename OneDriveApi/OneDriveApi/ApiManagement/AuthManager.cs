using KoenZomers.OneDrive.Api;
using KoenZomers.OneDrive.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OneDriveDeneme_23_02_2018.ApiManagement
{
    public class AuthManager
    {

        private static OneDriveApi oneDrive;

        public static OneDriveApi OneApi
        {
            get
            {
                if (oneDrive == null)
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


        // Authentication of One Drive API 
        public static OneDriveApi Auth(/*clientId, secretId*/)
        {
            string clientId = "424ec5f6-e554-41dd-9027-77e9d1bf04a3\t";
            string secretId = "swkeztzXQK4099;MJER9+)@";

            oneDrive = new OneDriveConsumerApi(clientId, secretId);

            return oneDrive;
        }


        // We take AccessToken by using this method 
        public static async Task<OneDriveAccessToken> GetToken(string code)
        {
            oneDrive.AuthorizationToken = code;
            var x = await oneDrive.GetAccessToken();

            return x;
        }

        // Creating new folder for OneDrive Disk
        public static async Task<OneDriveItem> CreateFolder(string folderName)
        {
            var data = await OneApi.GetFolderOrCreate(folderName);
            return data;
        }
    }
}