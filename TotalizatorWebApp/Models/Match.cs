using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Models
{
    public class Match
    {
        public Match()
        {
            Totalizators = new HashSet<Totalizator>();
        }

        public int MatchId { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }

        [ForeignKey("GuestTeam")]
        public int GuestTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team GuestTeam { get; set; }

        public virtual ICollection<Totalizator> Totalizators { get; set; }
    }
}