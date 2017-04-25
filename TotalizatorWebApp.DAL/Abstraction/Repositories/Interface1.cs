using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.UserLayer;

namespace TotalizatorWebApp.DAL.Abstraction.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}
