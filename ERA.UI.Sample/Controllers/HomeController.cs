using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERA.UI.Sample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.MessageOne = "test1".ToLocalString();
            ViewBag.MessageTwo = "test2".ToLocalString("test".ToLocalString());
            ViewBag.MessageThree = "test3".ToLocalString("test".ToLocalString());
            return View();
        }

    }
}
