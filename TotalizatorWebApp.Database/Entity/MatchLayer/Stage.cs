using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.Abstract;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Models.MatchLayer;

namespace TotalizatorWebApp.Database.Entity.MatchLayer
{
    public class Stage:IEntity<StageView>
    {
        public Stage()
        {
            Matches = new HashSet<Match>();
            Totalizators = new HashSet<Totalizator>();
        }

        public int StageId { get; set; }

        public string Name { get; set; }

        [ForeignKey("League")]
        public int LeagueId { get; set; }

        public virtual League League { get; set; }

        public virtual ICollection<Match> Matches { get; set; }

        public virtual ICollection<Totalizator> Totalizators { get; set; }

        public StageView Parse()
        {
            return new StageView()
            {
                StageId = this.StageId,
                Name = this.Name,
                LeagueName = this.League.Name
            };
        }
    }
}