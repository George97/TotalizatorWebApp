using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Models.View;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.Abstract;

namespace TotalizatorWebApp.Helpers
{
    public static class EntityListParser<Entity, Model> where Entity : IEntity<Model>
    {
        public static List<Model> ListParser(List<Entity> list)
        {
            List<Model> res = new List<Model>();
            foreach (var entity in list)
            {
                res.Add(entity.Parse());
            }
            return res;
        }

        //public static List<TeamView> ListParser(List<Team> list)
        //{
        //    List<TeamView> res = new List<TeamView>();
        //    foreach (var entity in list)
        //    {
        //        res.Add(EntityParser.Parser(entity));
        //    }

        //    return res;
        //}

        //public static List<TotalizatorView> ListParser(List<Totalizator> list)
        //{
        //    List<TotalizatorView> res = new List<TotalizatorView>();
        //    foreach (var entity in list)
        //    {
        //        res.Add(EntityParser.Parser(entity));
        //    }

        //    return res;
        //}
    }
}