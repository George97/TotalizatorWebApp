using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalizatorWebApp.Controllers.Data;
using TotalizatorWebApp.DAL.Concrete.UnitOfWork;

namespace TotalizatorWebApp.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult GetMatchSchedule()
        {
            return View();
        }

        public ActionResult AdminPage()
        {
            //var matches = unitOfWork.MatchRepository.GetMatches(2);
            return View();
        }

        public ActionResult Totalizators()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult SetResult()
        {
            return View();
        }
    }
}