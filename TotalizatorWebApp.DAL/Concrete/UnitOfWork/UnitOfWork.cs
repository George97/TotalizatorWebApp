using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.DAL.Concrete.Repository;
using TotalizatorWebApp.Database.Context;

namespace TotalizatorWebApp.DAL.Concrete.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private TotalizatorContext context;
        private IMatchRepository matchRepository;
        private ITotalizatorRepository totalizatorRepository;

        public UnitOfWork()
        {
            context = new TotalizatorContext();
            
        }

        public IMatchRepository MatchRepository
        {
            get
            {
                return matchRepository ?? (matchRepository = new MatchRepository(context));
            }
        }

        public ITotalizatorRepository TotalizatorRepository
        {
            get
            {
                return totalizatorRepository ?? (totalizatorRepository = new TotalizatorRepository(context));
            }
        }

        public void Save()
        {
            context.SaveChanges();
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
