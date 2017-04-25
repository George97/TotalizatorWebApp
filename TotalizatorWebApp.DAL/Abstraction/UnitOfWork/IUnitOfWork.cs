using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;

namespace TotalizatorWebApp.DAL.Abstraction.UnitOfWork
{
    interface IUnitOfWork
    {
        IMatchRepository MatchRepository { get; }
    }
}
