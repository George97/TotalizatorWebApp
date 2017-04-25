using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.UserLayer;

namespace TotalizatorWebApp.Database.Entity.BusinessLayer
{
    public class Confirmation
    {
        public int ConfirmationId { get; set; }

        [ForeignKey("Totalizator")]
        public int TotalizatorId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public bool? Status { get; set; }

        public virtual Totalizator Totalizator { get; set; }

        public virtual User User { get; set; }

    }
}