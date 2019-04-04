using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Reflection;

namespace YoutubeSampleApiApp.Youtube_API
{
    public class YoutubeApi
    {
        private static YouTubeService ytService = Auth();
        
        public static YouTubeService Auth()
        {
            UserCredential credential;
            using (var stream = new FileStream("youtube_client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[]
                    {
                        YouTubeService.Scope.Youtube,
                        YouTubeService.Scope.YoutubeForceSsl,
                        YouTubeService.Scope.YoutubeUpload,
                        YouTubeService.Scope.Youtubepartner
                    },
                    "user",
                    CancellationToken.None,
                    new FileDataStore("ExampleYoutubeApp")
                ).Result;
            }

            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApiKey = "AIzaSyD6WcIzb523-YYMz2vCXBJMeG4S7OGvM7Y",
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
            });

            return service;
        }
    }
}