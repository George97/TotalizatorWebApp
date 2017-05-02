using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.UserLayer;

namespace TotalizatorWebApp.DAL.Abstraction.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        bool UserExist(string login, string pass);
        string GetUserRole(string login);
        User GetByLogin(string login);
        User Get(int id);
        void SenRequest(int userId, int totalId, int orgId);
        List<Notification> GetNotifications(int userId);
    }
}
