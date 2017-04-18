using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Models
{
    public class Forecast
    {
        public int UserId { get; set; }

        public int TotalizatorId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int GuestTeamPoints { get; set; }

        public User User { get; set; }

        public Totalizator Totalizator { get; set; }
    }
}