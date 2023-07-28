using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatSJTU.Plugin.Models
{
    public class CookieInfo
    {
        public CookieInfo()
        {

        }
        public CookieInfo(Cookie cookie)
        {
            Name = cookie.Name;
            Value = cookie.Value;
            Path = cookie.Path;
            Domain = cookie.Domain;
            Secure = cookie.Secure;
            HttpOnly = cookie.HttpOnly;
            Expired = cookie.Expired;
            Expires = cookie.Expires;
            Discard = cookie.Discard;
            Version = cookie.Version;
        }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Path { get; set; }
        public string Domain { get; set; }
        public bool Secure { get; set; }
        public bool HttpOnly { get; set; }
        public bool Expired { get; set; }
        public DateTime Expires { get; set; }
        public bool Discard { get; set; }
        public string Port { get; set; }
        public int Version { get; set; }
        public Cookie ToCookie()
        {
            return new Cookie(Name, Value, Path, Domain) { Secure = Secure, HttpOnly = HttpOnly, Expired = Expired, Expires = Expires, Discard = Discard, Version = Version };
        }
    }
}
