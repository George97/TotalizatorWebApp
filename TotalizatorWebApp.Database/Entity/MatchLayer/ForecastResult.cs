using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Database.Entity.MatchLayer
{
    public class ForecastResult
    {
        public int ForecastResultId { get; set; }

        public int MatchId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int GuestTeamGoals { get; set; }

        public virtual Match Match { get; set; }
    }
}