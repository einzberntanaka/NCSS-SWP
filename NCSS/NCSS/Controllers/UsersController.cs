using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCSS.BusinessComponents.Components;
using NCSS.EntityModel.Entities;
using System.Web.Security;

namespace NCSS.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/
        UsersManager userManager = new UsersManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string loginID, string password)
        {
            USER user = userManager.LoginChecking(loginID, password);
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Session["user"] = user.Username;
                Session["role"] = user.ROLE.RoleName;


                var userCookie = new HttpCookie("user", user.Username);
                userCookie.Expires.AddDays(1);
                HttpContext.Response.Cookies.Set(userCookie);




                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.messageError = "The email and password that you entered don't match.";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
            Session.Clear();
            return RedirectToAction("Index", "Users");
        }

    }
}
