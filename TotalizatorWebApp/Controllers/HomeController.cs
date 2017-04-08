using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalizatorWebApp.Models;
using TotalizatorWebApp.Models.DTO;

namespace TotalizatorWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TotalizatorContext context = new TotalizatorContext();
            var teams = context.Teams.ToArray<Team>();
            return View();
        }

        [HttpGet]
        public JsonResult GetMatches()
        {
                TotalizatorContext db = new TotalizatorContext();
                var matches = db.MatchSchedules.Select((m) => new MatchScheduleDTO()
                {
                    ID = m.ID,
                    HomeTeamName = m.HomeTeam.Name,
                    GuestTeamName = m.GuestTeam.Name,
                    MatchDate = m.MatchDate
                }).ToList<MatchScheduleDTO>();
                return Json(matches, JsonRequestBehavior.AllowGet);

            }
            public ActionResult CreateTotalizator()
            {
                return RedirectToAction("Index","Home");
            }
        }

    }
}