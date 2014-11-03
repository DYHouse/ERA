using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERA.UI.LanguageSample
{
    public class DefaultContext
    {
        private string languageCode = "zh-CN";
        private readonly string LANGUAGE_COOKIE = "LANGUAGE_COOKIE";
        public string LanageCode
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[LANGUAGE_COOKIE];
                if (cookie != null)
                {
                    return cookie.Value;
                }
                return languageCode;
            }
            set
            {
                languageCode = value;
                HttpCookie cookie = HttpContext.Current.Request.Cookies[LANGUAGE_COOKIE];
                if (cookie == null)
                {
                    cookie = new HttpCookie(LANGUAGE_COOKIE);
                    cookie.Value = languageCode;
                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Current.Request.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Value = languageCode;
                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Current.Request.Cookies.Add(cookie);
                }
            }
        }
    }
}