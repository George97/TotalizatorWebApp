using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TotalizatorWebApp.Controllers.Data;
using TotalizatorWebApp.DAL.Abstraction.UnitOfWork;
using TotalizatorWebApp.DAL.Concrete.UnitOfWork;
using TotalizatorWebApp.Models;

namespace TotalizatorWebApp.Controllers
{
    public class AccountController : Controller
    {
        [Inject]
        public IUnitOfWork unitOfWork { get; set; }

        //private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Account
        public ActionResult Login()
        {
            //var user = unitOfWork.UserRepository.Get(1);
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);
            string msg;
            var userValid = unitOfWork.UserRepository.UserExist(model.Username, model.Password,out msg);
            
            //bool userValid = unitOfWork.UserRepository.UserExist(model.Username, model.Password);
            if (userValid)
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                if (Url.IsLocalUrl(returnUrl)
                    && returnUrl.Length > 1
                    && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//")
                    && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                   if(unitOfWork.UserRepository.GetUserRole(model.Username)=="Admin")
                    {
                        return RedirectToAction("AdminPage", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", msg);
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}