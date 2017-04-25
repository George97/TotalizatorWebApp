using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Models.BusinessLayer;

namespace TotalizatorWebApp.Models.UserLayer
{
    public class Organaizer
    {
        public Organaizer()
        {
            Totalizators = new HashSet<Totalizator>();
        }

        public int OrganaizerId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<Totalizator> Totalizators { get; set; }

    }
}