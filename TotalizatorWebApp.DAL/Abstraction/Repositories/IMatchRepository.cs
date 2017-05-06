using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Database.Models.API;
using TotalizatorWebApp.Database.Models.MatchLayer;

namespace TotalizatorWebApp.DAL.Abstraction.Repositories
{
    public interface IMatchRepository
    {
        League GetLeague(int id);

        List<League> GetLeagues();

        List<Stage> GetValidStages(int leagueId, DateTime date);

        List<Match> GetMatches(int stageId);

        List<MatchResultView> GetBlunkResults(int stageId);

        int SetMatchResult(List<FixtureView> results);

        void setPoints(int stageId, List<FixtureView> matchRes);
    }
}
