using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.DAL.Services;
using TotalizatorWebApp.Database.Context;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Database.Entity.UserLayer;
using TotalizatorWebApp.Database.Models.API;
using TotalizatorWebApp.Database.Models.MatchLayer;

namespace TotalizatorWebApp.DAL.Concrete.Repositories
{
    public class MatchRepository : IMatchRepository
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
            return context.Matches.Where(m => m.StageId == stageId).ToList();
            //return context.Matches.ToList();
        }

        public List<Stage> GetValidStages(int leagueId, DateTime date)
        {
            List<Stage> result = new List<Stage>();
            var stages =context.Stages.Where(s => s.LeagueId == leagueId).ToList();
            foreach (var item in stages)
            {
                if(DateService.getValidDate(item.StageId, context)>= date)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<MatchResultView> GetBlunkResults(int stageId)
        {
            var matches = context.Matches.Where(m => m.StageId == stageId);
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

        //public int setForecast(MatchResultView res)
        //{
        //    int i = context.Forecasts.ToList().Count;
        //    context.Forecasts.Add(new Forecast()
        //    {
        //        ForecastId = i+1,
        //        MatchId = res.MatchId,
        //        Match = context.Matches.SingleOrDefault(m => m.MatchId== res.MatchId),
        //        HomeTeamGoals = res.HomeTeamGoals,
        //        GuestTeamGoals = res.GuestTeamPoints
        //    });
        //    context.SaveChanges();
        //    return i + 1;
        //}

        public int SetMatchResult(List<FixtureView> results)
        {
            int stageId = 0;
            int matchday = results[0].matchday;
            var stageMatches = context.Matches.Where(m => m.Stage.MatchDay == matchday).ToList();
            foreach (var res in results)
            {
                var match = getCurrMatch(res, stageMatches);

                if(match!= null)
                {
                    stageId = match.StageId;
                    var resultCopy = context.Results.SingleOrDefault(r => r.MatchId == match.MatchId);
                    if (resultCopy == null)
                    {
                        context.Results.Add(new Result()
                        {
                            MatchId = match.MatchId,
                            Match = match,
                            HomeTeamGoals = res.result.goalsHomeTeam,
                            GuestTeamGoals = res.result.goalsAwayTeam
                        });
                    }
                }

            }
            context.SaveChanges();
            return stageId;
        }

        Match getCurrMatch(FixtureView res, List<Match> matches)
        {
            foreach (var m in matches)
            {
                if(res.awayTeamName == m.GuestTeam.Name && res.homeTeamName == m.HomeTeam.Name)
                {
                    return m;
                }
            }
            return null;
        }

        public void setPoints(int stageId,List<FixtureView> matchRes)
        {
            var total = context.Totalizators.Where(t => t.StageId == stageId).ToList();
            foreach (var t in total)
            {
                var tManagers = context.TotalizatorManagers.Where(tm => tm.TotalizatorId == t.TotalizatorId).ToList();
                foreach (var manager in tManagers)
                {
                    var user = manager.User;
                    var pointsRules = manager.Totalizator.PointsAnalysis;
                    var forecasts = context.Forecasts.Where(f => f.TotalizatorManagerId == manager.TotalizatorManagerId).ToList();
                    user.Points += calculateUserPoints(forecasts, matchRes, pointsRules);
                    //context.Users.Attach(user); ????
                    //context.Entry(user).Property(u => u.Points).IsModified = true;
                }
            }
            context.SaveChanges();
        }

        public double  calculateUserPoints(List<Forecast> forecasts, List<FixtureView> matchRes, PointsAnalysis pointsRules)
        {
            if (!EntityHelper.isValidRules(pointsRules))
            {
                throw new ArgumentException("Incorrect values. Please, enter some positive numbers");
            }
            double sum = 0;
            foreach (var forecast in forecasts)
            {
                var currRes = matchRes.Single(m => m.awayTeamName == forecast.Match.GuestTeam.Name && m.homeTeamName == forecast.Match.HomeTeam.Name);
                if (forecast.GuestTeamGoals == currRes.result.goalsAwayTeam && forecast.HomeTeamGoals == currRes.result.goalsHomeTeam)
                {
                    sum += pointsRules.Full;
                }
                else
                {
                    string winnerResName = getWinnerName(currRes.homeTeamName, currRes.result.goalsHomeTeam,
                                                         currRes.awayTeamName, currRes.result.goalsAwayTeam);

                    string winnerUserName = getWinnerName(forecast.Match.HomeTeam.Name, forecast.HomeTeamGoals,
                                                          forecast.Match.GuestTeam.Name, forecast.GuestTeamGoals);

                    if (winnerResName == winnerUserName)
                    {
                        if (forecast.GuestTeamGoals - forecast.HomeTeamGoals == currRes.result.goalsAwayTeam - currRes.result.goalsHomeTeam)
                        {
                            sum += pointsRules.GoalDif;
                        }
                        else
                        {
                            sum += pointsRules.JustWinner;
                        }
                    }
                }

            }
            var s = sum / (double)matchRes.Count;
            return sum / (double)matchRes.Count;
        }
        
        private string getWinnerName(string team1, int golTeam1, string team2, int goalTeam2)
        {
            if(golTeam1 == goalTeam2)
            {
                return null;
            }
            return golTeam1 > goalTeam2 ? team1 : team2;
        }
    }
}
