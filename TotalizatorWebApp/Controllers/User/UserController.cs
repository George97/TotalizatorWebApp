using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web.Script.Serialization;
using System.Web;
using System.Web.Mvc;
using TotalizatorWebApp.DAL.Concrete.UnitOfWork;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Database.Models.BusinessLayer;
using TotalizatorWebApp.Database.Models.MatchLayer;
using TotalizatorWebApp.Database.Models.UserLayer;
using TotalizatorWebApp.Database.Entity;
using TotalizatorWebApp.Helpers;
using System.Web.Security;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using System.Reflection;
using TotalizatorWebApp.Models;
using TotalizatorWebApp.Database.Models.API;
using Ninject;
using TotalizatorWebApp.DAL.Abstraction.UnitOfWork;

namespace TotalizatorWebApp.Controllers.User
{
    public class UserController : Controller
    {
        //private static readonly object locker = new object();

        //[Inject]
        //public IUnitOfWork unitOfWork { get; set; }

        // GET: User
        //[Authorize]
        public ActionResult Index()
        {
            //var user = UnitOfWork.UserRepository.Get(1);
           // unitOfWork.TotalizatorRepository.SetManagerId(1, 1);
           //var user = unitOfWork.UserRepository.Get(1);
            return View();
        }

        public ActionResult CreateTotalizator()
        {

            return View();
        }


        public ActionResult ShowTotalizators()
        {
            return View();
        }

        public ActionResult ShowRating()
        {
            return View();
        }

        public ActionResult MakeForecast()
        {
            return View();
        }

    }
}