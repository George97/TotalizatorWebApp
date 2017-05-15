using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.DAL.Abstraction.Repositories;
using TotalizatorWebApp.Database.Context;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.UserLayer;
using TotalizatorWebApp.Database.Models.API;

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
            return context.Users.Where(u => u.Roles != "Admin").ToList();
        }
        public bool UserExist(string login, string pass,out string msg)
        {
            var user = context.Users.SingleOrDefault(u => u.Login == login && u.Password == pass);
            if(user!=null)
            {
                if (user.isBanned == 0)
                {
                    msg = "success";
                    return true;
                }
                msg = "Sorry, but you were banned";
                return false;
            }
            msg = "The user name or password provided is incorrect.";
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

        public void SetRequest(int userId, int totalId, int orgId)
        {
            if(context.Notifications.SingleOrDefault(n => n.UserId == userId && n.TotalizatorId == totalId) == null)
            {
                int index = context.Notifications.ToList().Count;
                var user = context.Users.SingleOrDefault(u => u.UserId == userId);
                var org = context.Users.SingleOrDefault(u => u.UserId == orgId);
                var total = context.Totalizators.SingleOrDefault(t => t.TotalizatorId == totalId);
                Notification notification = new Notification()
                {
                    NotificationId= index+1,
                    UserId = userId,
                    User = user,
                    ReceiverId = orgId,
                    Receiver = org,
                    TotalizatorId = totalId,
                    Totalizator = total
                };
                context.Notifications.Add(notification);
                context.SaveChanges();
                //int index = context.Notifications.ToList().Count;
                //context.Notifications.ToList().Last().NotificationId = index;
            }
        }

        public List<Notification> GetNotifications(int userId)
        {
            return context.Notifications.Where(n => n.ReceiverId == userId).ToList();
        }

        public void AcceptUser(int userId,int totalId)
        {
            setUserAcces(userId, totalId, true);
            context.SaveChanges();
        }

        public void RejectUser(int userId, int totalId)
        {
            setUserAcces(userId, totalId, false);
            context.SaveChanges();
        }

        private void setUserAcces(int userId, int totalId,bool Access)
        {
            var total = context.Totalizators.SingleOrDefault(t => t.TotalizatorId == totalId);
            var user = context.Users.SingleOrDefault(u => u.UserId == userId);
            var tmanager = context.TotalizatorManagers.SingleOrDefault(tM => tM.TotalizatorId == totalId && tM.UserId == userId);
            if(tmanager != null)
            {
                context.TotalizatorManagers.Single(tm => tm.TotalizatorManagerId == tmanager.TotalizatorManagerId).UserAccess = Access;
                //foreach (var t in tmanagers)
                //{
                //    context.TotalizatorManagers.Remove(t);
                //}
            }
            //TotalizatorManager tm = new TotalizatorManager()
            //{
            //    TotalizatorId = totalId,
            //    Totalizator = total,
            //    UserId = userId,
            //    User = user,
            //    UserAccess = Access
            //};
            //context.TotalizatorManagers.Add(tm);
        }

        public void RemoveNotification(int id)
        {
            var notification =context.Notifications.SingleOrDefault(n => n.NotificationId == id);
            context.Notifications.Remove(notification);
            context.SaveChanges();
        }

        public void BanUser(int userId)
        {
            var user = context.Users.SingleOrDefault(u => u.UserId == userId).isBanned = 1;
            context.SaveChanges();
        }

        //public void setPoints(int stageId, IEnumerable<FixtureView> results)
        //{
        //    var total = context.Totalizators.Where(t => t.StageId == stageId).ToList();
        //    foreach (var t in total)
        //    {
        //        var tManagers = context.TotalizatorManagers.Where(tm => tm.TotalizatorId == t.TotalizatorId).ToList();
        //        foreach (var manager in tManagers)
        //        {
        //            var user = manager.User;
        //            var pointsRules = manager.Totalizator.PointsAnalysis;
        //            var forecasts = context.Forecasts.Where(f => f.TotalizatorManagerId == manager.TotalizatorManagerId).ToList();
        //            foreach (var forecast in forecasts)
        //            {
        //                var fResults = context.ForecastResults.Where(fR => fR.ForecastResultId == forecast.ForecastResultId).ToList();
        //                double sum = 0;
        //                int count = 0;
        //                foreach (var res in fResults)
        //                {
        //                    if(res.GuestTeamGoals ==)
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
