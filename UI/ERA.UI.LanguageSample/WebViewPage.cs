using ERA.Framework.Cache;
using ERA.Framework.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ERA.UI.LanguageSample
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public  Localizer T
        {
            get
            {
                return new LocalizedManager(new DefaultLanguageResourceProvider(),
                    new MemoryCacheManager(),
                    Thread.CurrentThread.CurrentCulture.Name).T;
            }
        }

        public override void InitHelpers()
        {
            base.InitHelpers();
        }
    }
    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}