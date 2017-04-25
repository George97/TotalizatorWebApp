using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.UserLayer;

namespace TotalizatorWebApp.Database.Entity.BusinessLayer
{
    public class TotalizatorManager
    {
        public TotalizatorManager()
        {
            Forecasts = new HashSet<Forecast>();
        }

        public int TotalizatorManagerId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Totalizator")]
        public int TotalizatorId { get; set; }

        public bool? UserAccess { get; set; }

        public virtual User User { get; set; }

        public virtual Totalizator Totalizator { get; set; }

        public virtual ICollection<Forecast> Forecasts { get; set; }
    }
}