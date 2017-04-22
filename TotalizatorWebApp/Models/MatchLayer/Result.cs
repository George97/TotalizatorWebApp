using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Models.MatchLayer
{
    public class Result
    {
        public int MatchId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int GuestTeamPoints { get; set; }

        public virtual Match Match { get; set; }
    }
}