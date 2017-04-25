using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.MatchLayer;

namespace TotalizatorWebApp.Database.Entity.BusinessLayer
{
    public class Forecast
    {
        public int ForecastId { get; set; }

        [ForeignKey("Result")]
        public int ResultId { get; set; }

        [ForeignKey("TotalizatorManager")]
        public int TotalizatorManagerId { get; set; }

        public Result Result { get; set; }

        public TotalizatorManager TotalizatorManager { get; set; }
    }
}