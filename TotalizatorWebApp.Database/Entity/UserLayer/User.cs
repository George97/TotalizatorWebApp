using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.Abstract;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Models.UserLayer;

namespace TotalizatorWebApp.Database.Entity.UserLayer
{
    public class User: IEntity<UserView>
    {
        public User()
        {
            TotalizatorManagers = new HashSet<TotalizatorManager>();
            Confirmations = new HashSet<Confirmation>();
        }

        public int UserId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public double Points { get; set; }

        public virtual ICollection<TotalizatorManager> TotalizatorManagers { get; set; }

        public virtual ICollection<Confirmation> Confirmations { get; set; }

        public virtual ICollection<Totalizator> Totalizators { get; set; }

        public UserView Parse()
        {
            return new UserView()
            {
                UserId = this.UserId,
                Login = this.Login,
                Password = this.Password,
                FullName = this.FullName,
                Points = this.Points
            };
        }
    }
}