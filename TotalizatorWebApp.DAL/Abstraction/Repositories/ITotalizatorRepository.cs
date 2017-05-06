using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Models.BusinessLayer;
using TotalizatorWebApp.Database.Models.MatchLayer;
using TotalizatorWebApp.Database.Models.UserLayer;

namespace TotalizatorWebApp.DAL.Abstraction.Repositories
{
    public interface ITotalizatorRepository
    {

        int GetNextIndex();

        int AddTotalizator(int organaizerId, int stage, string tTitle, PointsAnalysisView tPoints, string tAccess);

        void AddUser(int toalizatorId, int userId);

        Totalizator Get(int id);

        List<TotalizatorWithUsersView> GetAllWithUsers();

        List<UserView> GetTotalizatorUsers(int totalId);

        List<Totalizator> GetValidForUser(int userId,DateTime date);

        int SetManagerId(int totalizatorId, int userId);

        void SetForecast(MatchResultView res, int totalManagerId);

        bool UserHasAccess(int userId, int totalId);
    }
}
