using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.Abstract;
using TotalizatorWebApp.Database.Models.MatchLayer;
using TotalizatorWebApp.Database.Entity.BusinessLayer;

namespace TotalizatorWebApp.Database.Entity.MatchLayer
{
    public class Match: IEntity<MatchView>
    {
        public Match()
        {
            Forecasts = new HashSet<Forecast>();
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

        public virtual ICollection<Forecast> Forecasts{ get; set; }

        public MatchView Parse()
        {
            return new MatchView()
            {
                Id = this.MatchId,
                HomeTeamName = this.HomeTeam.Name,
                GuestTeamName = this.GuestTeam.Name
            };
        }
    }
}