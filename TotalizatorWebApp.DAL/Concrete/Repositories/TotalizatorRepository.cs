using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.Database.Context;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.UserLayer;
using TotalizatorWebApp.Database.Models.BusinessLayer;

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

        public List<Totalizator> GetTotalizators()
        {
            return context.Totalizators.ToList<Totalizator>();
        }

        public int AddTotalizator(int organaizerId,int stage, string tTitle, PointsAnalysisView tPoints, string tAccess)
        {
            bool isPublic = true;
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
                Validity = DateTime.Now,
                isPublic = isPublic
            };
            context.Totalizators.Add(totalizator);
            return totalizatorId;
        }

        public List<Totalizator> GetAll()
        {
            return context.Totalizators.ToList();
        }

        public Totalizator Get(int id)
        {
            return context.Totalizators.SingleOrDefault(t => t.TotalizatorId == id);
        }

        public int SetManagerId(int totalizatorId, int userId)
        {
            var t = context.TotalizatorManagers.ToList().Count;
            context.TotalizatorManagers.Add(new TotalizatorManager()
            {
                TotalizatorId = totalizatorId,
                UserId = userId,
                UserAccess = true
            });
            return t+1;
        }

        public void SetForecast(int forecastResId, int totalManagerId)
        {
            context.Forecasts.Add(new Forecast()
            {
                TotalizatorManagerId = totalManagerId,
                ForecastResultId = forecastResId
            });
        }
    }
}
