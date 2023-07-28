using ChatSJTU.Plugin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using Teru.Code.Extensions;

namespace ChatSJTU.Plugin.Services
{
    public static class WebNew
    {
        public static WebResult Get(HttpClient client, string url, Dictionary<string, string> queryparas)
        {
            return Get(client, BuildUrl(url, queryparas));
        }

        public static WebResult Get(HttpClient client, string url, Dictionary<string, string> queryparas, Dictionary<string, string> headers)
        {
            ProcessHeaders(client, headers);
            var task = client.GetAsync(BuildUrl(url, queryparas));
            task.Wait();
            return GetFinalResult(task.GetAwaiter().GetResult());
        }

        public static WebResult Get(HttpClient client, string url)
        {
            var task = client.GetAsync(url);
            task.Wait();
            return GetFinalResult(task.GetAwaiter().GetResult());
        }
        public static WebResult Post(HttpClient client, string url, string content)
        {
            var httpcontent = new StringContent(content);
            httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var task = client.PostAsync(url, httpcontent);
            task.Wait();
            return GetFinalResult(task.GetAwaiter().GetResult());
        }

        public static WebResult Post(HttpClient client, string url, Dictionary<string, string> queryparas, Dictionary<string, string> headers, string content)
        {
            ProcessHeaders(client, headers);
            var httpcontent = new StringContent(content);
            httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var task = client.PostAsync(BuildUrl(url, queryparas), httpcontent);
            task.Wait();
            return GetFinalResult(task.GetAwaiter().GetResult());
        }

        public static WebResult PostJson(HttpClient client, string url, Dictionary<string, string> queryparas, Dictionary<string, string> headers, string content)
        {
            ProcessHeaders(client, headers);
            var httpcontent = new StringContent(content);
            httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var task = client.PostAsync(BuildUrl(url, queryparas), httpcontent);
            task.Wait();
            return GetFinalResult(task.GetAwaiter().GetResult());
        }

        public static void ProcessHeaders(HttpClient client, Dictionary<string, string> headers)
        {
            if (headers.ContainsKey("Accept-Encoding"))
            {
                client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue(headers["Accept-Encoding"]));
                headers.Remove("Accept-Encoding");
            }
            //if (headers.ContainsKey("User-Agent"))
            //{
            //    req.UserAgent = headers["User-Agent"];
            //    headers.Remove("User-Agent");
            //}
            //if (headers.ContainsKey("Referer"))
            //{
            //    req.Referer = headers["Referer"];
            //    headers.Remove("Referer");
            //}
            //if (headers.ContainsKey("Connection") && headers["Connection"] == "keep-alive")
            //{
            //    req.KeepAlive = true;
            //    headers.Remove("Connection");
            //}
            if (headers.ContainsKey("Content-Type"))
            {
                headers.Remove("Content-Type");
            }
            if (headers.ContainsKey("Host"))
            {
                headers.Remove("Host");
            }
            if (headers.ContainsKey("Content-Length"))
            {
                headers.Remove("Content-Length");
            }
            if (headers.ContainsKey("Cache-Control"))
            {
                headers.Remove("Cache-Control");
            }
            client.DefaultRequestHeaders.Clear();
            foreach (var i in headers)
            {
                client.DefaultRequestHeaders.Add(i.Key, i.Value);
            }
        }

        public static WebResult GetFinalResult(HttpResponseMessage responseMessage)
        {
            return new WebResult(responseMessage.StatusCode, true, responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult(), null, responseMessage.Headers);
        }

        public static string BuildUrl(string url, Dictionary<string, string> queryparas)
        {
            StringBuilder builder1 = new StringBuilder();
            builder1.Append(url);

            if (queryparas.Count > 0)
            {
                builder1.Append("?");
                int i = 0;
                foreach (var item in queryparas)
                {
                    if (i > 0)
                        builder1.Append("&");
                    builder1.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
            }
            return builder1.ToString();
        }

        public static string BuildForm(Dictionary<string, string> formdata, bool urlencode)
        {
            StringBuilder builder = new StringBuilder();

            if (formdata.Count > 0)
            {
                int i = 0;
                foreach (var item in formdata)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, urlencode ? item.Value.UrlEncode() : item.Value);
                    i++;
                }
            }
            return builder.ToString();
        }
    }

}
