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
        public bool UserExist(string login, string pass)
        {
            var user = context.Users.SingleOrDefault(u => u.Login == login && u.Password == pass);
            if(user!=null)
            {
                return true;
            }
            return false;
        }

        public string GetUserRole(string login)
        {
            var user = context.Users.SingleOrDefault(u => u.Login == login);
            if (user != null)
            {
                return user.Roles;
            }
            return null;
        }

        public User GetByLogin(string login)
        {
            return context.Users.SingleOrDefault(u => u.Login == login);
        }

        public User Get(int id)
        {
            return context.Users.SingleOrDefault(u => u.UserId == id);
        }
    }
}
