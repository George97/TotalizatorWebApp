using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Database.Entity.MatchLayer
{
    public class League
    {
        public League()
        {
            Stages = new HashSet<Stage>();
        }

        public int LeagueId { get; set; }

        public string  Name { get; set; }

        public virtual ICollection<Stage> Stages { get; set; }
    }
}