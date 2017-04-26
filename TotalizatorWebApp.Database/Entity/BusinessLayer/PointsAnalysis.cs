using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.Abstract;
using TotalizatorWebApp.Database.Models.BusinessLayer;

namespace TotalizatorWebApp.Database.Entity.BusinessLayer
{
    public class PointsAnalysis: IEntity<PointsAnalysisView>
    {
        public int TotalizatorId { get; set; }

        public int Full { get; set; }

        public int GoalDif { get; set; }

        public int JustWinner { get; set; }

        public virtual Totalizator Totalizator { get; set; }

        public PointsAnalysisView Parse()
        {
            return new PointsAnalysisView()
            {
                TotalizatorId = this.TotalizatorId,
                Full = this.Full,
                GoalDif = this.GoalDif,
                JustWinner = this.JustWinner
            };
        }
    }
}