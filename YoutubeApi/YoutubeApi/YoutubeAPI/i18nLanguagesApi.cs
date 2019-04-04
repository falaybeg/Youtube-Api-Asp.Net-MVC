using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoutubeSampleApiApp.Youtube_API;

namespace YoutubeSampleApiApp.YoutubeAPI
{
    public class I18nLanguagesApi
    {
        private static YouTubeService youtubeService = YoutubeApi.Auth();

        public I18nLanguage ListVideoCategories()
        {

            I18nLanguage i18Language = null;
            var listRequest = youtubeService.I18nLanguages.List("snippet");
            listRequest.Hl = ""; // we can set default

            var response = listRequest.Execute();
            if (response.Items.Count > 0)
            {
                foreach (var item in response.Items)
                {
                    i18Language = new  I18nLanguage();
                    i18Language.Snippet = new  I18nLanguageSnippet();
                    i18Language.Snippet.Hl = response.Items[0].Snippet.Hl;
                    i18Language.Snippet.Name = response.Items[0].Snippet.Name;
                }
            }
            else
            {
                throw new Exception("Categories not found");
            }

            return i18Language;
        }
    }
}