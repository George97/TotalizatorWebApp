using System;
using System.Collections.Generic;
using System.Linq;
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
using TotalizatorWebApp.Database.Entity.UserLayer;

namespace TotalizatorWebApp.Controllers.User
{
    public class UserController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SetCurrUser()
        {
            string login = String.Empty;
            UserView user = null;

            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    login = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                }
            }
            if(!String.IsNullOrEmpty(login))
            {
                user =unitOfWork.UserRepository.GetByLogin(login).Parse();
            }
                return Json(user, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateTotalizator()
        {

            return View();
        }

        [HttpPost]
        public int AddTotalizator(int organaizerId,int stage,string tTitle, PointsAnalysisView tPoints, string tAccess)
        {
            var organaizer = unitOfWork.UserRepository.Get(organaizerId);
            var index =unitOfWork.TotalizatorRepository.AddTotalizator(organaizerId, stage, tTitle, tPoints, tAccess);
            unitOfWork.Save();
            return index;
        }
        public ActionResult ShowTotalizators()
        {
            return View();
        }

        public JsonResult GetAllTotalizators()
        {
            var t = unitOfWork.TotalizatorRepository.GetAll().ToList();
            List<TotalizatorView> totalizators = null;
            if (t.Count > 0)
            {
                totalizators = EntityListParser<Totalizator, TotalizatorView>.ListParser(t);

            }
            return Json(totalizators, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTotalizator(int tId)
        {
            var totalizator = unitOfWork.TotalizatorRepository.Get(tId).Parse();
           
            return Json(totalizator, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowRating()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetLeague(int LeagueId)
        {
            var league = (unitOfWork.MatchRepository.GetLeague(LeagueId)).Parse();
            return Json(league, JsonRequestBehavior.AllowGet);
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

        public JsonResult GetBlankPointAnalysisView()
        {
            var pointAnalysis = new PointsAnalysisView();
            return Json(pointAnalysis, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllUsers()
        {
            var users = EntityListParser<Database.Entity.UserLayer.User, UserView>.ListParser(unitOfWork.UserRepository.GetUsers());
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SetTotalizatorUser(int userId,int totalizatorId)
        {
            unitOfWork.TotalizatorRepository.AddUser(userId, totalizatorId);
        }

        public JsonResult GetNextTotalizatorId()
        {
            var nextIndex = unitOfWork.TotalizatorRepository.GetNextIndex();
            return Json(nextIndex, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBlunkResults(int stageId)
        {
            var matchResults = unitOfWork.MatchRepository.GetBlunkResults(stageId);
            return Json(matchResults, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectToForecast(string name)
        {
            return RedirectToAction("ForecastPage", name);
        }

        public ActionResult ForecastPage()
        {
            return View();
        }
        public int SetTManagerId(int tid, int userId)
        {
            var i =unitOfWork.TotalizatorRepository.SetManagerId(tid, userId);
            return i;
        }

       [HttpPost]
        public void SetForecast(MatchResultView matchResult,int tmanagerId)
        {
            int id =unitOfWork.MatchRepository.setForecasrResult(matchResult);
            unitOfWork.TotalizatorRepository.SetForecast(id, tmanagerId);
            unitOfWork.Save();
        }

    }
}