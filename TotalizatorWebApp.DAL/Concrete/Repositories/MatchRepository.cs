using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.Database.Context;
using TotalizatorWebApp.Database.Entity.MatchLayer;

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
            return context.Leagues.ToList<League>();
        }

        public List<Match> GetMatches(int stageId)
        {
            return context.Matches.Where(m => m.StageId == stageId).ToList<Match>();
        }

        public List<Stage> GetStages(int leagueId)
        {
            return context.Stages.Where(s => s.LeagueId == leagueId).ToList<Stage>();
        }
    }
}
