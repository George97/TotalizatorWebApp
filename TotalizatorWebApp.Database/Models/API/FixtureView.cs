using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalizatorWebApp.Database.Models.API
{
    public class FixtureView
    {
        public string awayTeamName { get; set; }

        public string homeTeamName { get; set; }

        public DateTime date { get; set; }

        public int matchday { get; set; }

        public ResultView result { get; set; }

        public string status { get; set; }
    }
}
