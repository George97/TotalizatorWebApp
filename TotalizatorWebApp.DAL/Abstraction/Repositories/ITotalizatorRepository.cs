using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Models.BusinessLayer;

namespace TotalizatorWebApp.DAL.Abstraction.Repositories
{
    public interface ITotalizatorRepository
    {
        List<Totalizator> GetTotalizators();

        int GetNextIndex();

        int AddTotalizator(int organaizerId, int stage, string tTitle, PointsAnalysisView tPoints, string tAccess);

        void AddUser(int toalizatorId, int userId);

        List<Totalizator> GetAll();

        Totalizator Get(int id);

        int SetManagerId(int totalizatorId, int userId);

        void SetForecast(int forecastResId, int totalManagerId);
    }
}
