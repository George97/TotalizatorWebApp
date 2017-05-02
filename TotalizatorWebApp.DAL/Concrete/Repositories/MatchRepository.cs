﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.DAL.Services;
using TotalizatorWebApp.Database.Context;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Database.Models.MatchLayer;

namespace TotalizatorWebApp.DAL.Concrete.Repositories
{
    class MatchRepository : IMatchRepository
    {
        private TotalizatorContext context;

        public MatchRepository(TotalizatorContext ctx)
        {
            context = ctx;
        }
        public List<League> GetLeagues()
        {
            return context.Leagues.ToList();
        }

        public League GetLeague(int id)
        {
            return context.Leagues.Where(l => l.LeagueId == id).First();
        }

        public List<Match> GetMatches(int stageId)
        {
            //return context.Matches.Where(m => m.StageId == stageId).ToList();
            return context.Matches.ToList();
        }

        public List<Stage> GetValidStages(int leagueId)
        {
            List<Stage> result = new List<Stage>();
            var stages =context.Stages.Where(s => s.LeagueId == leagueId).ToList();
            foreach (var item in stages)
            {
                if(DateService.getValidDate(item.StageId, context)>= DateTime.Now)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<MatchResultView> GetBlunkResults(int stageId)
        {
            var matches = context.Matches.ToList();
            List<MatchResultView> matchRes = new List<MatchResultView>();
            foreach (var match in matches)
            {
                matchRes.Add(new MatchResultView()
                {
                    MatchId = match.MatchId,
                    GuestTeamName = match.GuestTeam.Name,
                    HomeTeamName = match.HomeTeam.Name,
                    GuestTeamPoints = 0,
                    HomeTeamGoals = 0
                });
            }
            return matchRes;
        }

        public int setForecasrResult(MatchResultView res)
        {
            int i = context.ForecastResults.ToList().Count;
            context.ForecastResults.Add(new ForecastResult()
            {
                ForecastResultId = i+1,
                MatchId = res.MatchId,
                Match = context.Matches.SingleOrDefault(m => m.MatchId== res.MatchId),
                HomeTeamGoals = res.HomeTeamGoals,
                GuestTeamGoals = res.GuestTeamPoints
            });
            context.SaveChanges();
            return i + 1;
        }
    }
}
