using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Models.MatchLayer;

namespace TotalizatorWebApp.Models.BusinessLayer
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