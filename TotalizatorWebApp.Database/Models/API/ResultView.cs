using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalizatorWebApp.Database.Models.API
{
    public class ResultView
    {
        public int goalsAwayTeam { get; set; }

        public int goalsHomeTeam { get; set; }

        public HalfTimeView halfTime { get; set; }
    }
}
