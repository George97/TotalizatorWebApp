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

        [HttpGet]
        public JsonResult GetLeague(int LeagueId)
        {
            var league = new LeagueView() { LeagueId = 1, Name = "League 1" };
            //var league = (unitOfWork.MatchRepository.GetLeague(id)).Parse();
            return Json(league, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLeagues()
        {
            List<LeagueView> leagues = new List<LeagueView>()
            {
                new LeagueView() {LeagueId =1, Name="League 1" },
                new LeagueView() {LeagueId =2, Name="League 2" },
            };
           // var leagues = EntityListParser<League,LeagueView>.ListParser(unitOfWork.MatchRepository.GetLeagues());
            return Json(leagues, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStages(int leagueId)
        {
            List<StageView> stages = new List<StageView>()
            {
                new StageView() {StageId=1,LeagueName="League 1",Name="Round 1" },
                new StageView() {StageId=2,LeagueName="League 1",Name="Round 2" }
            };
            List<StageView> stages2 = new List<StageView>()
            {
                new StageView() {StageId=1,LeagueName="League 2",Name="Round 12" },
                new StageView() {StageId=2,LeagueName="League 2",Name="Round 23" }
            };

            //var stages = EntityListParser<Stage,StageView>.ListParser(unitOfWork.MatchRepository.GetStages(leagueId));
            if(leagueId ==1)
                return Json(stages, JsonRequestBehavior.AllowGet);
            else
                return Json(stages2, JsonRequestBehavior.AllowGet);
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
            List<UserView> users = new List<UserView>()
            {
                new UserView() { UserId=1,Login="login1",Password="pass1",FullName="Yura",Points=10 },
                new UserView() { UserId=2,Login="login2",Password="pass1",FullName="Taras",Points=10 },
                new UserView() { UserId=3,Login="login3",Password="pass1",FullName="Diana",Points=10 },
                new UserView() { UserId=4,Login="login4",Password="pass1",FullName="Vasia",Points=10 },
                new UserView() { UserId=5,Login="login5",Password="pass1",FullName="Vova",Points=10 }
            };

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SetTotalizatorUser(int userId,int totalizatorId)
        {

        }

        public JsonResult GetNextTotalizatorId()
        {
            var nextIndex = unitOfWork.TotalizatorRepository.GetNextIndex();
            return Json(nextIndex, JsonRequestBehavior.AllowGet);
        }
    }
}