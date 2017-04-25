using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.MatchLayer;

namespace TotalizatorWebApp.DAL.Abstraction.Repositories
{
    public interface IMatchRepository
    {
        List<League> GetLeagues();

        List<Stage> GetStages(int leagueId);

        List<Match> GetMatches(int stageId);
    }
}
