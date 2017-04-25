using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.Database.Context;
using TotalizatorWebApp.Database.Entity.UserLayer;

namespace TotalizatorWebApp.DAL.Concrete.Repositories
{
    public class UserRepository : IUserRepository
    {
        private TotalizatorContext context;

        public UserRepository(TotalizatorContext ctx)
        {
            context = ctx;
        }
        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }
    }
}
