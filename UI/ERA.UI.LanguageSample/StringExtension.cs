using ERA.Framework.Cache;
using ERA.Framework.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ERA.UI.LanguageSample
{
    public static class StringExtension
    {
        public static string ToLocalString(this string str, params string[] args)
        {
            return new LocalizedManager(new DefaultLanguageResourceProvider()
                , new MemoryCacheManager()
                , Thread.CurrentThread.CurrentCulture.Name).T(str, args).ToString();
        }
    }
}