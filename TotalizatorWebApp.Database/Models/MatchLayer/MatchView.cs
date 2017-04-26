using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Database.Models.MatchLayer
{
    public class MatchView
    {
        public int Id { get; set; }
        public string HomeTeamName { get; set; }
        public string GuestTeamName { get; set; }
        public DateTime? MatchDate { get; set; }

    }
}