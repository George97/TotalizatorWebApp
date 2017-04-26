using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.Abstract;
using TotalizatorWebApp.Database.Models.MatchLayer;

namespace TotalizatorWebApp.Database.Entity.MatchLayer
{
    public class Team:IEntity<TeamView>
    {
        public Team()
        {
            HomeMatches = new HashSet<Match>();
            GuestMatches = new HashSet<Match>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> GuestMatches { get; set; }

        public TeamView Parse()
        {
            return new TeamView()
            {
                ID = this.TeamId,
                Name = this.Name
            };
        }
    }
}