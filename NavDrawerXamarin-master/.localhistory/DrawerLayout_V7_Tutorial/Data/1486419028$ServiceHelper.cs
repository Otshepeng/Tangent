using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.IO;

namespace SharedPreferences
{
    public class ServiceHelper
    {
        // POST a JSON string
        public string POST(string url, string jsonContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            long length = 0;
            string results = null;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        results = reader.ReadToEnd();
                    }

                }
            }
            catch (WebException ex)
            {
                // Log exception and throw as for GET example above
            }

            return results;
        }

        public string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            request.ContentType = @"application/json";
            request.Headers.Add(HttpRequestHeader.Authorization, "token b7ec34e136bb6d28a4421e422e852b99cc834d17");

            long length = 0;
            string results = null;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        results = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                // Log exception and throw as for GET example above
            }

            return results;
        }
    }
}