using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalizatorWebApp.DAL.Concrete.UnitOfWork;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Database.Models;
using TotalizatorWebApp.Helpers;

namespace TotalizatorWebApp.Controllers.User
{
    public class UserController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: User
        public ActionResult Index()
        {
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

        public JsonResult GetLeagues()
        {
            var leagues = EntityListParser<League,LeagueView>.ListParser(unitOfWork.MatchRepository.GetLeagues());
            return Json(leagues, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStages(int leagueId)
        {
            var stages = EntityListParser<Stage,StageView>.ListParser(unitOfWork.MatchRepository.GetStages(leagueId));
            return Json(stages, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMatches(int stageId)
        {
            var matches = EntityListParser<Match,MatchView>.ListParser(unitOfWork.MatchRepository.GetMatches(stageId));
            return Json(matches, JsonRequestBehavior.AllowGet);
        }
    }
}