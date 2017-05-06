using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.MatchLayer;

namespace TotalizatorWebApp.Database.Entity.BusinessLayer
{
    public class Forecast
    {
        public int ForecastId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int GuestTeamGoals { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        [ForeignKey("TotalizatorManager")]
        public int TotalizatorManagerId { get; set; }

        public TotalizatorManager TotalizatorManager { get; set; }
    }
}