using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalizatorWebApp.Database.Models.MatchLayer
{
    public class MatchResultView
    {
        public int MatchId { get; set; }

        public string HomeTeamName { get; set; }

        public string GuestTeamName { get; set; }

        public int HomeTeamGoals { get; set; }

        public int GuestTeamPoints { get; set; }
    }
}
