using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.DAL.Services;
using TotalizatorWebApp.Database.Context;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.UserLayer;
using TotalizatorWebApp.Database.Models.BusinessLayer;
using TotalizatorWebApp.Database.Models.MatchLayer;
using TotalizatorWebApp.Database.Models.UserLayer;

namespace TotalizatorWebApp.DAL.Concrete.Repositories
{
    public class TotalizatorRepository : ITotalizatorRepository
    {
        private TotalizatorContext context;
        public TotalizatorRepository(TotalizatorContext ctx)
        {
            context = ctx;
        }

        public void AddUser(int toalizatorId, int userId)
        {
            context.TotalizatorManagers.Add(new TotalizatorManager() { TotalizatorId = toalizatorId, UserId = userId });
        }

        public int GetNextIndex()
        {
            int count = context.Totalizators.ToList().Count;
            if (count > 0)
            {
                return context.Totalizators.ToList().Last().TotalizatorId + 1;
            }
            return 1;
        }

        public List<TotalizatorWithUsersView> GetAllWithUsers()
        {
            var totalizators= context.Totalizators.ToList<Totalizator>();
            List<TotalizatorWithUsersView> res = new List<TotalizatorWithUsersView>();
            foreach (var t in totalizators)
            {
                var stage = context.Stages.SingleOrDefault(s => s.StageId == t.StageId);
                var league = context.Leagues.SingleOrDefault(l => l.LeagueId == stage.LeagueId);
                var organaizer = context.Users.Single(u => u.UserId == t.OrganaizerId);
                var users = GetTotalizatorUsers(t.TotalizatorId);
                string access = t.isPublic ?"Public" :"Private";
                var points = t.PointsAnalysis.Parse();
                res.Add(new TotalizatorWithUsersView()
                {
                    TotalizatorId = t.TotalizatorId,
                    Name = t.Name,
                    Access = access,
                    OrganaizerLogin = organaizer.Login,
                    Users = users,
                    PointsAnalysis = points,
                    Validity = t.Validity,
                    Stage = stage.Name+"  " + stage.MatchDay,
                    League = league.Name
                });
            }
            return res;
        }

        public List<UserView> GetTotalizatorUsers(int totalId)
        {
            var tManagers = context.TotalizatorManagers.Where(tm => tm.TotalizatorId == totalId).ToList();
            var users = new List<UserView>();
            foreach (var item in tManagers)
            {
                users.Add(context.Users.Single(u => u.UserId == item.UserId).Parse());
            }
            return users;

        }

        public List<Totalizator> GetValidForUser(int userId, DateTime date) //валідність по даті і по унікальності прогнозу на тоталізатор
        {
            var all = context.Totalizators.ToList();
            var tManagers = context.TotalizatorManagers.ToList();
            var forecasts = context.Forecasts.ToList();
            return getValidForUser(userId, date, all, tManagers, forecasts);
        }

        public List<Totalizator> getValidForUser(int userId, DateTime date,List<Totalizator> totalizators, List<TotalizatorManager> tManagers,List<Forecast> forecasts)
        {
            List<Totalizator> res = new List<Totalizator>();
            foreach (var t in totalizators)
            {
                if (t.Validity > date)
                {
                    bool isValid = true;
                    var totalizatorManager = tManagers.SingleOrDefault(tm => tm.TotalizatorId == t.TotalizatorId && tm.UserId == userId); // user has acces ???
                    if (totalizatorManager != null)
                    {
                        isValid = totalizatorManager.UserAccess != null ? (bool)totalizatorManager.UserAccess : isValid;
                        if (forecasts.Where(f => f.TotalizatorManagerId == totalizatorManager.TotalizatorManagerId).ToList().Count > 0)
                        {
                            isValid = false;
                        }
                    }
                    if (isValid)
                    {
                        res.Add(t);
                    }
                }
            }
            return res;
        }

        public int AddTotalizator(int organaizerId,int stage, string tTitle, PointsAnalysisView tPoints, string tAccess)
        {
            bool isPublic = true;
            DateTime ValidDate = DateService.getValidDate(stage,context);
            if(tAccess=="Private")
            {
                isPublic = false;
            }
            int totalizatorId = GetNextIndex();
            var pA = new PointsAnalysis()
            {
                Full = tPoints.Full,
                GoalDif = tPoints.GoalDif,
                JustWinner = tPoints.JustWinner,
                TotalizatorId = totalizatorId
            };
            context.PointsAnalysis.Add(pA);
            var totalizator = new Totalizator()
            {
                Name = tTitle,
                TotalizatorId = totalizatorId,
                OrganaizerId = organaizerId,
                StageId = stage,
                Validity = ValidDate,
                isPublic = isPublic
            };
            context.Totalizators.Add(totalizator);
            context.SaveChanges();
            return totalizatorId;
        }

        public Totalizator Get(int id)
        {
            return context.Totalizators.SingleOrDefault(t => t.TotalizatorId == id);
        }

        public int SetManagerId(int totalizatorId, int userId, bool access)
        {
            var index = context.TotalizatorManagers.ToList().Count;
            var manager = context.TotalizatorManagers.SingleOrDefault(tm => tm.UserId == userId && tm.TotalizatorId == totalizatorId);
            if (manager == null)
            {
                context.TotalizatorManagers.Add(new TotalizatorManager()
                {
                    TotalizatorId = totalizatorId,
                    Totalizator = context.Totalizators.SingleOrDefault(t => t.TotalizatorId == totalizatorId),
                    UserId = userId,
                    User = context.Users.SingleOrDefault(u => u.UserId == userId),
                    UserAccess = access
                });
                context.SaveChanges();
                return index + 1;
            }
            context.SaveChanges();
            return manager.TotalizatorManagerId;
        }

        public void SetForecast(List<MatchResultView> results, int totalId,int  userId)
        {
            var tM = context.TotalizatorManagers.SingleOrDefault(t => t.TotalizatorId == totalId && t.UserId == userId);
            foreach (var res in results)
            {
                int id = context.Forecasts.ToList().Count;
                context.Forecasts.Add(new Forecast()
                {
                    ForecastId = id + 1,
                    TotalizatorManagerId = tM.TotalizatorManagerId,
                    TotalizatorManager = context.TotalizatorManagers.SingleOrDefault(tm => tm.TotalizatorManagerId == tM.TotalizatorManagerId),
                    MatchId = res.MatchId,
                    Match = context.Matches.SingleOrDefault(m => m.MatchId == res.MatchId),
                    HomeTeamGoals = res.HomeTeamGoals,
                    GuestTeamGoals = res.GuestTeamPoints
                });
            }
            context.SaveChanges();
        }

        public bool UserHasAccess(int userId, int totalId)
        {
            var total = context.Totalizators.Single(t => t.TotalizatorId == totalId);
            if (total.isPublic || total.OrganaizerId == userId)
            {
                return true;
            }
            var tmanager = context.TotalizatorManagers.SingleOrDefault(tm => tm.UserId == userId && tm.TotalizatorId == totalId);
            if(tmanager != null)
            {
                if (tmanager.UserAccess == true)
                {
                    return true;
                }
            }
             return false;
        }
    }
}
