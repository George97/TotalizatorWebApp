using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalizatorWebApp.Database.Models.BusinessLayer
{
    public class PointsAnalysisView
    {
        public int TotalizatorId { get; set; }

        public int Full { get; set; }

        public int GoalDif { get; set; }

        public int JustWinner { get; set; }

    }
}
