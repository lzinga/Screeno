using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Screeno;

namespace ScreenoExample.Controllers
{
    public class HomeController : Controller
    {
        [TakeScreen]
        public ActionResult Index()
        {
            return View();
        }
    }
}