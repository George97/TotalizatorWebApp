using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Models.MatchLayer
{
    public class Match
    {

        public Match(Match m)
        {
            MatchId = m.MatchId;
            Date = m.Date;
            HomeTeamId = m.HomeTeamId;
            GuestTeamId = m.GuestTeamId;
            HomeTeam = m.HomeTeam;
            GuestTeam = m.GuestTeam;
        }

        public int MatchId { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }

        [ForeignKey("GuestTeam")]
        public int GuestTeamId { get; set; }

        [ForeignKey("Stage")]
        public int StageId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team GuestTeam { get; set; }

        public virtual Stage Stage { get; set; }

        public virtual Result Result { get; set; }

    }
}