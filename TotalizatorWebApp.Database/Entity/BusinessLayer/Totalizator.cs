using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.Abstract;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Database.Entity.UserLayer;
using TotalizatorWebApp.Database.Models.BusinessLayer;

namespace TotalizatorWebApp.Database.Entity.BusinessLayer
{
    public class Totalizator:IEntity<TotalizatorView>
    {
        public Totalizator()
        {
            TotalizatorManagers = new HashSet<TotalizatorManager>();
            Confirmations = new HashSet<Notification>();
        }

        public int TotalizatorId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Organaizer")]
        public int OrganaizerId { get; set; }

        [ForeignKey("Stage")]
        public int StageId { get; set; }

        public Stage Stage { get; set; }

        public User Organaizer { get; set; }

        public bool isPublic { get; set; }

        public DateTime Validity { get; set; }

        public  virtual PointsAnalysis PointsAnalysis { get; set; }

        public virtual ICollection<TotalizatorManager> TotalizatorManagers { get; set; }

        public virtual ICollection<Notification> Confirmations { get; set; }

        public TotalizatorView Parse()
        {
            return new TotalizatorView()
            {
                TotalizatorId = this.TotalizatorId,
                Name = this.Name,
                OrganaizerName = String.Empty,
                OrganaizerId = this.OrganaizerId,
                StageId = this.StageId,
                isPublic = this.isPublic,
                Validity = this.Validity
            };

        }
    }
}