using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdvance01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "اطلاعات درباره نرم افزار";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "اطلاعات تماس";

            return View();
        }
    }
}