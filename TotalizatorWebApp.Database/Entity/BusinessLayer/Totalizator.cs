using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Database.Entity.UserLayer;

namespace TotalizatorWebApp.Database.Entity.BusinessLayer
{
    public class Totalizator
    {
        public Totalizator()
        {
            TotalizatorManagers = new HashSet<TotalizatorManager>();
            Confirmations = new HashSet<Confirmation>();
        }

        public int TotalizatorId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Organaizer")]
        public int OrganaizerId { get; set; }

        [ForeignKey("Stage")]
        public int StageId { get; set; }

        public Stage Stage { get; set; }

        public User Organaizer { get; set; }

        public DateTime Validity { get; set; }

        public  virtual PointsAnalysis PointsAnalysis { get; set; }

        public virtual ICollection<TotalizatorManager> TotalizatorManagers { get; set; }

        public virtual ICollection<Confirmation> Confirmations { get; set; }



    }
}