using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.Database.Context;
using TotalizatorWebApp.Database.Entity.BusinessLayer;

namespace TotalizatorWebApp.DAL.Concrete.Repositories
{
    class TotalizatorRepository : ITotalizatorRepository
    {
        private TotalizatorContext context;
        public TotalizatorRepository(TotalizatorContext ctx)
        {
            context = ctx;
        }

        public List<Totalizator> GetTotalizators()
        {
            return context.Totalizators.ToList<Totalizator>();
        }
    }
}
