using ChatSJTU.Plugin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatSJTU.Plugin.Services
{
    public static class GlobalCookie
    {
        public static CookieContainer CookieContainer { get; set; }

        static GlobalCookie()
        {
            _fileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "cookie.json");
        }

        private static string _fileName;

        public static void Save()
        {
            File.WriteAllText(_fileName, JsonConvert.SerializeObject(CookieContainer.GetAllCookies().Select(i => new CookieInfo(i))));
        }

        public static CookieContainer Read()
        {
            CookieContainer = new CookieContainer();
            if (File.Exists(_fileName))
            {
                var json = File.ReadAllText(_fileName);
                var result = JsonConvert.DeserializeObject<List<CookieInfo>>(json);
                foreach (var cookie in result)
                {
                    CookieContainer.Add(cookie.ToCookie());
                }
            }
            return CookieContainer;
        }
    }
}
