using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Models.View;
using TotalizatorWebApp.Database.Entity.BusinessLayer;

namespace TotalizatorWebApp.Helpers
{
    public static class EntityParser
    {
        public static MatchView Parser( Match entity)
        {
            return new MatchView();
        }

        public static TeamView Parser(Team entity)
        {
            return new TeamView();
        }

        public static TotalizatorView Parser(Totalizator entity)
        {
            return new TotalizatorView();
        }
    }
}