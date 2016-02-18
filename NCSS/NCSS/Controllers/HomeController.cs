using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCSS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            if (Request.Cookies["user"] != null)
                return View();
            else
                return RedirectToAction("Index","Users");
        }

    }
}
