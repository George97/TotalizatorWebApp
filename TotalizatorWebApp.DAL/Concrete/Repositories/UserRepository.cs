using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.Database.Context;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
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

        public void SenRequest(int userId, int totalId, int orgId)
        {
            var user = context.Users.SingleOrDefault(u => u.UserId == userId);
            var org = context.Users.SingleOrDefault(u => u.UserId == orgId);
            var total = context.Totalizators.SingleOrDefault(t => t.TotalizatorId == totalId);

            Notification notification = new Notification()
            {
                UserId = userId,
                User = user,
                Receiver = org,
                ReceiverId = orgId,
                TotalizatorId = totalId,
                Totalizator = total
            };

            context.Notifications.Add(notification);
        }

        public List<Notification> GetNotifications(int userId)
        {
            return context.Notifications.Where(n => n.ReceiverId == userId).ToList();
        }


    }
}
