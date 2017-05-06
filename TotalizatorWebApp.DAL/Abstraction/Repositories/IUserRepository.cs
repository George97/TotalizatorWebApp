using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.UserLayer;
using TotalizatorWebApp.Database.Models.API;

namespace TotalizatorWebApp.DAL.Abstraction.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        bool UserExist(string login, string pass, out string msg);
        string GetUserRole(string login);
        User GetByLogin(string login);
        User Get(int id);
        void SetRequest(int userId, int totalId, int orgId);
        List<Notification> GetNotifications(int userId);
        void AcceptUser(int userId,int totalId);
        void RejectUser(int userId, int totalId);
        void RemoveNotification(int id);
        void BanUser(int userId);
        
    }
}
