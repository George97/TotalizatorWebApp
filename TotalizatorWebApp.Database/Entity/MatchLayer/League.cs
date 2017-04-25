using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.Abstract;
using TotalizatorWebApp.Database.Models;


namespace TotalizatorWebApp.Database.Entity.MatchLayer
{
    public class League: IEntity<LeagueView>
    {
        public League()
        {
            Stages = new HashSet<Stage>();
        }

        public int LeagueId { get; set; }

        public string  Name { get; set; }

        public virtual ICollection<Stage> Stages { get; set; }

        public LeagueView Parse()
        {
            return new LeagueView()
            {
                LeagueId = this.LeagueId,
                Name = this.Name
            };
        }
    }
}