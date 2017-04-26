using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.MatchLayer;

namespace TotalizatorWebApp.Database.Models.MatchLayer
{
    public class StageView
    {
        public int StageId { get; set; }

        public string Name { get; set; }

        public string LeagueName { get; set; }

    }
}