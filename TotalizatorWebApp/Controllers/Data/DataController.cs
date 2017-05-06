﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TotalizatorWebApp.DAL.Concrete.UnitOfWork;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Database.Models.API;
using TotalizatorWebApp.Database.Models.BusinessLayer;
using TotalizatorWebApp.Database.Models.MatchLayer;
using TotalizatorWebApp.Database.Models.UserLayer;
using TotalizatorWebApp.Helpers;

namespace TotalizatorWebApp.Controllers.Data
{
    public class DataController : Controller
    {
        private static readonly object locker = new object();

        //public static UnitOfWork UnitOfWork { get; set; }
        private UnitOfWork unitOfWork = new UnitOfWork();

        [HttpPost]
        public int AddTotalizator(int organaizerId, int stage, string tTitle, PointsAnalysisView tPoints, string tAccess)
        {
            var organaizer = unitOfWork.UserRepository.Get(organaizerId);
            var index = unitOfWork.TotalizatorRepository.AddTotalizator(organaizerId, stage, tTitle, tPoints, tAccess);
            unitOfWork.Save();
            return index;
        }

        [HttpGet]
        public JsonResult GetAllValidTotalizators(int userId)
        {
            DateTime date = new DateTime(2017, 04, 05);
            var t = unitOfWork.TotalizatorRepository.GetValidForUser(userId, date).ToList();
            List<TotalizatorView> totalizators = null;
            if (t.Count > 0)
            {
                totalizators = EntityListParser<Totalizator, TotalizatorView>.ListParser(t);

            }
            return Json(totalizators, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllTotalizatorsWithUsers()
        {
            var total = unitOfWork.TotalizatorRepository.GetAllWithUsers();

            return Json(total, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTotalizator(int tId)
        {
            var totalizator = unitOfWork.TotalizatorRepository.Get(tId).Parse();

            return Json(totalizator, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLeague(int LeagueId)
        {
            var league = (unitOfWork.MatchRepository.GetLeague(LeagueId)).Parse();
            return Json(league, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLeagues()
        {
            var leagues = EntityListParser<League, LeagueView>.ListParser(unitOfWork.MatchRepository.GetLeagues());
            return Json(leagues, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetStages(int leagueId)
        {
            DateTime date = new DateTime(2017, 04, 05);
            var stages = EntityListParser<Stage, StageView>.ListParser(unitOfWork.MatchRepository.GetValidStages(leagueId, date));
            return Json(stages, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetMatches(int stageId)
        {
            var matches = EntityListParser<Match, MatchView>.ListParser(unitOfWork.MatchRepository.GetMatches(stageId));
            return Json(matches, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetBlankPointAnalysisView()
        {
            var pointAnalysis = new PointsAnalysisView();
            return Json(pointAnalysis, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            var users = EntityListParser<Database.Entity.UserLayer.User, UserView>.ListParser(unitOfWork.UserRepository.GetUsers());
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetBlunkResults(int stageId)
        {
            var matchResults = unitOfWork.MatchRepository.GetBlunkResults(stageId);
            return Json(matchResults, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserNotifications(int userId)
        {
            var notifications = EntityListParser<Notification, NotificationView>.ListParser(unitOfWork.UserRepository.GetNotifications(userId));
            return Json(notifications, JsonRequestBehavior.AllowGet);
        }

        public int SetTManagerId(int tid, int userId)
        {
            var i = unitOfWork.TotalizatorRepository.SetManagerId(tid, userId);
            unitOfWork.Save();
            return i;
        }

        [HttpPost]
        public void SetForecast(MatchResultView matchResult, int tmanagerId)
        {
            lock (locker)
            {
                unitOfWork.TotalizatorRepository.SetForecast(matchResult, tmanagerId);
                unitOfWork.Save();
            }
        }

        [HttpPost]
        public void SendRequest(int userId, int totalId, int orgId)
        {
            unitOfWork.UserRepository.SetRequest(userId, totalId, orgId);
            unitOfWork.Save();
        }


        [HttpPost]
        public void AcceptUser(int userId, int totalId)
        {
            unitOfWork.UserRepository.AcceptUser(userId, totalId);
            unitOfWork.Save();
        }

        [HttpPost]
        public void RejectUser(int userId, int totalId)
        {
            unitOfWork.UserRepository.RejectUser(userId, totalId);
            unitOfWork.Save();
        }

        [HttpPost]
        public void RemoveNotification(int nId)
        {
            unitOfWork.UserRepository.RemoveNotification(nId);
            unitOfWork.Save();
        }

        public bool UserHasAccess(int userId, int totalId)
        {
            return unitOfWork.TotalizatorRepository.UserHasAccess(userId, totalId);
        }

        [HttpPost]
        public void PostResult(IEnumerable<FixtureView> results)
        {
            int stageId =unitOfWork.MatchRepository.SetMatchResult(results.ToList());
            unitOfWork.MatchRepository.setPoints(stageId,results.ToList());
        }

        [HttpPost]
        public void BanUser(int userId) 
        {
            unitOfWork.UserRepository.BanUser(userId);
        }

        public bool UserExist(string Username, string Password, out string msg)
        {
            msg = String.Empty;
            return unitOfWork.UserRepository.UserExist(Username, Password,out msg);
        }

        public string GetUserRole(string Username)
        {
            return unitOfWork.UserRepository.GetUserRole(Username);
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
            if (!String.IsNullOrEmpty(login))
            {
                user = unitOfWork.UserRepository.GetByLogin(login).Parse();
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }

    }
}