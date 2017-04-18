using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Models
{
    public class Totalizator
    {
        public Totalizator()
        {
            Forecasts = new HashSet<Forecast>();
        }

        public int Id { get; set; }

        [ForeignKey("Match")]
        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        public virtual ICollection<Forecast> Forecasts { get; set; }
    }
}