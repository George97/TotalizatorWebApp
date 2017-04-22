using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Models.BusinessLayer
{
    public class PointsAnalysis
    {
        public int TotalizatorId { get; set; }

        public int Full { get; set; }

        public int GoalDif { get; set; }

        public int JustWinner { get; set; }

        public virtual Totalizator Totalizator { get; set; }
    }
}