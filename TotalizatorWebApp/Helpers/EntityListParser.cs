using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Models.View;
using TotalizatorWebApp.Database.Entity.BusinessLayer;

namespace TotalizatorWebApp.Helpers
{
    public static class EntityListParser
    {
        public static List<MatchView> ListParser(List<Match> list)
        {
            List<MatchView> res = new List<MatchView>();
            foreach (var entity in list)
            {
                res.Add(EntityParser.Parser(entity));
            }

            return res;
        }

        public static List<TeamView> ListParser(List<Team> list)
        {
            List<TeamView> res = new List<TeamView>();
            foreach (var entity in list)
            {
                res.Add(EntityParser.Parser(entity));
            }

            return res;
        }

        public static List<TotalizatorView> ListParser(List<Totalizator> list)
        {
            List<TotalizatorView> res = new List<TotalizatorView>();
            foreach (var entity in list)
            {
                res.Add(EntityParser.Parser(entity));
            }

            return res;
        }
    }
}