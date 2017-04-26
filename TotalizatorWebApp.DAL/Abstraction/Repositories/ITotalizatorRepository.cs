using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.BusinessLayer;

namespace TotalizatorWebApp.DAL.Abstraction.Repositories
{
    public interface ITotalizatorRepository
    {
        List<Totalizator> GetTotalizators();

        int GetNextIndex();
    }
}
