using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.BusinessLayer;

namespace TotalizatorWebApp.Database.Entity.UserLayer
{
    public class User
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

    }
}