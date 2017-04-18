using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalizatorWebApp.Context;
using TotalizatorWebApp.Models;
using TotalizatorWebApp.Models.View;

namespace TotalizatorWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
                return View();
        }

        [HttpGet]
        public JsonResult GetMatches()
        {
            using (TotalizatorContext db = new TotalizatorContext())
            {
                var matches = db.Matches.Select((m) => new MatchView()
                {
                    Id = m.MatchId,
                    HomeTeamName = m.HomeTeam.Name,
                    GuestTeamName = m.GuestTeam.Name,
                    MatchDate = m.Date
                }).ToList<MatchView>();

                return Json(matches, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetTotalizators()
        {
            using (TotalizatorContext db = new TotalizatorContext())
            {
                var totalizators = db.Totalizators.Select((t) => new TotalizatorView()
                {
                    Id = t.Id,
                    HomeTeamName = t.Match.HomeTeam.Name,
                    GuestTeamName = t.Match.GuestTeam.Name,
                    MatchDate = t.Match.Date,
                    HomeTeamGoals = 0,
                    GuestTeamPoints = 0
                }).ToList<TotalizatorView>();

                return Json(totalizators, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public void AddTotalizator(int MatchId)
        {
            using (TotalizatorContext db = new TotalizatorContext())
            {
                Match match = db.Matches.Where(m => m.MatchId == MatchId).Single();
                Totalizator totalizator = new Totalizator()
                {
                    MatchId = MatchId,
                    Match = match
                };

                db.Totalizators.Add(totalizator);
                db.SaveChanges();
            }
        }
    }

    
}