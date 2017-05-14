using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.Abstract;
using TotalizatorWebApp.Database.Entity.BusinessLayer;

namespace TotalizatorWebApp.DAL.Services
{
    public class EntityHelper
    {
        public static List<Model> ListParser<Entity, Model>(List<Entity> list) where Entity : IEntity<Model>
        {
            List<Model> res = new List<Model>();
            foreach (var entity in list)
            {
                res.Add(entity.Parse());
            }
            return res;
        }

        public static bool isValidRules(PointsAnalysis rules)
        {
            return rules.Full >= 0 && rules.GoalDif >= 0 && rules.JustWinner >= 0;
        }
    }
}
