using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalizatorWebApp.Database.Models.UserLayer
{
    public class UserView
    {
        public int UserId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public double Points { get; set; }

    }
}
