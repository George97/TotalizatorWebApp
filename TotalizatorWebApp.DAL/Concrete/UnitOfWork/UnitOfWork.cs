using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.DAL.Abstraction.UnitOfWork;
using TotalizatorWebApp.DAL.Concrete.Repositories;
using TotalizatorWebApp.Database.Context;

namespace TotalizatorWebApp.DAL.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private TotalizatorContext context;
        private IMatchRepository _matchRepository;
        private ITotalizatorRepository _totalizatorRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(IMatchRepository matchRepository, ITotalizatorRepository totalizatorRepository, IUserRepository userRepository)
        {
            context = new TotalizatorContext();
            _matchRepository = matchRepository;
            _totalizatorRepository = totalizatorRepository;
            _userRepository = userRepository;
        }

        public IMatchRepository MatchRepository
        {
            get
            {
                return _matchRepository;
            }
        }

        public ITotalizatorRepository TotalizatorRepository
        {
            get
            {
                return _totalizatorRepository; 
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository; 
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
