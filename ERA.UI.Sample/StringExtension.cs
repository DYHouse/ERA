using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using ERA.Framework.Cache;
using ERA.Framework.Language;

namespace ERA.UI.Sample
{
    public static class StringExtension
    {
        public static string ToLocalString(this string str, params string[] args)
        {
            return new LocalizedManager(new DefaultLanguageResourceProvider()
                ,new MemoryCacheManager()
                , Thread.CurrentThread.CurrentCulture.Name).T(str, args).ToString();
        }
    }
}