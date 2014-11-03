using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERA.UI.LanguageSample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //to do
            //测试 粗暴做法
            ViewBag.LanguageCode = "zh-cn";
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                ViewBag.LanguageCode = Request["id"];
            }
            return View();
        }

        public ActionResult OpenModal()
        {
            return Json(
                new
                {
                    Message = "LinkText".ToLocalString("1")
                }
                );
        }
    }
}
