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
using TotalizatorWebApp.Database.Models.UserLayer;

namespace TotalizatorWebApp.DAL.Concrete.Repositories
{
    class TotalizatorRepository : ITotalizatorRepository
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
                res.Add(new TotalizatorWithUsersView()
                {
                    Name = t.Name,
                    Access = access,
                    OrganaizerLogin = organaizer.Login,
                    Users = users,
                    Validity = t.Validity,
                    Stage = stage.Name,
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

        public List<Totalizator> GetValidForUser(int userId)
        {
            List<Totalizator> res = new List<Totalizator>();
            var all = context.Totalizators.ToList();
            foreach (var t in all)
            {
                if(t.Validity> DateTime.Now)
                {
                    bool isValid = true;
                    var totalizatorManager = context.TotalizatorManagers.Where(tm => tm.TotalizatorId == t.TotalizatorId);
                    foreach (var item in totalizatorManager)
                    {
                        if(item.UserId == userId)
                        {
                            isValid = false;
                        }
                    }
                    if(isValid)
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
            return totalizatorId;
        }

        public Totalizator Get(int id)
        {
            return context.Totalizators.SingleOrDefault(t => t.TotalizatorId == id);
        }

        public int SetManagerId(int totalizatorId, int userId)
        {
            var index = context.TotalizatorManagers.ToList().Count;
            context.TotalizatorManagers.Add(new TotalizatorManager()
            {
                TotalizatorId = totalizatorId,
                Totalizator =  context.Totalizators.SingleOrDefault(t => t.TotalizatorId == totalizatorId),
                UserId = userId,
                User = context.Users.SingleOrDefault(u => u.UserId == userId),
                UserAccess = true
            });
            return index + 1;
        }

        public void SetForecast(int forecastResId, int totalManagerId)
        {
            context.Forecasts.Add(new Forecast()
            {
                TotalizatorManagerId = totalManagerId,
                TotalizatorManager = context.TotalizatorManagers.SingleOrDefault(tm => tm.TotalizatorManagerId == totalManagerId),
                ForecastResultId = forecastResId,
                ForecastResult = context.ForecastResults.SingleOrDefault(fr => fr.ForecastResultId == forecastResId)
                
            });
        }
    }
}
