using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TotalizatorWebApp.DAL.Concrete.UnitOfWork;
using TotalizatorWebApp.Helpers;
using TotalizatorWebApp.Models;
//using TotalizatorWebApp.Context;
//using TotalizatorWebApp.Models.BusinessLayer;
//using TotalizatorWebApp.Models.MatchLayer;
//using TotalizatorWebApp.Models.UserLayer;
using TotalizatorWebApp.Models.View;

namespace TotalizatorWebApp.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //        return View();
        //}

        //public ActionResult UserExist()
        //{
        //    string login = "Nilan";
        //    string pass = "1111";
        //    var user =unitOfWork.UserRepository.GetUser(login, pass);
        //    if (user != null)
        //    {
        //        return RedirectToAction("Index", "User", user.Parse());
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Login(LoginViewModel model, string returnUrl)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var userValid = unitOfWork.UserRepository.UserExist(model.Username, model.Password);
        //    if (userValid)
        //    {
        //        FormsAuthentication.SetAuthCookie(model.Username, false);
        //        if (Url.IsLocalUrl(returnUrl)
        //            && returnUrl.Length > 1
        //            && returnUrl.StartsWith("/")
        //            && !returnUrl.StartsWith("//")
        //            && !returnUrl.StartsWith("/\\"))
        //        {
        //            return Redirect(returnUrl);
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "User");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "The user name or password provided is incorrect.");
        //    }
        //    return View(model);
        //}

        //public ActionResult LogOff()
        //{
        //    FormsAuthentication.SignOut();

        //    return RedirectToAction("Login", "Home");
        //}

    }

    
}