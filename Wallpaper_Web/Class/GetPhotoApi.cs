using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Wallpaper_Web.Class
{
    public class GetPhotoApi
    {
        public ArrayList GetUrl(string word)
        {
            /* API: https://pixabay.com/api/docs/ */
            JObject json;
            ArrayList listJson = new ArrayList();
            string apiKey = "24144474-e2b6769400ef593a25b428e1c";
            string urlname, urlFile, savPath;
            urlname = "https://pixabay.com/api/?key=" + apiKey + "&q=" + word;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlname);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                json = JObject.Parse(result);
                foreach (var item in json["hits"])
                {
                    listJson.Add(item["largeImageURL"]);
                }
            }

            

            //savPath = @"D:\Program_files\C#\Проекты\Wallpaper\Wallpaper\Wallpaper\Photo\";
            //urlFile = "photo.jpg";
            //if (GetUrlFile(urlname, savPath + urlFile))
            //{
            //    Console.WriteLine("FIle " + urlFile + " complite ");
            //}

            return listJson;
        }

        static bool GetUrlFile(string address, string FileNme)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            try
            {
                client.DownloadFile(address, FileNme);
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
