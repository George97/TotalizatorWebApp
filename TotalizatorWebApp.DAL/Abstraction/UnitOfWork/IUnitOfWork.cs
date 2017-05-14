using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;

namespace TotalizatorWebApp.DAL.Abstraction.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IMatchRepository MatchRepository { get; }

        ITotalizatorRepository TotalizatorRepository { get; }

        IUserRepository UserRepository { get; }
    }
}
