using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Database.Entity.MatchLayer
{
    public class Team
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
    }
}