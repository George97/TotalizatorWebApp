using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Database.Entity.Abstract;
using TotalizatorWebApp.Database.Entity.UserLayer;
using TotalizatorWebApp.Database.Models.BusinessLayer;

namespace TotalizatorWebApp.Database.Entity.BusinessLayer
{
    public class Notification: IEntity<NotificationView>
    {
        public int NotificationId { get; set; }

        [ForeignKey("Totalizator")]
        public int TotalizatorId { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public bool? Reject { get; set; }

        public virtual User User { get; set; }

        public virtual Totalizator Totalizator { get; set; }

        public virtual User Receiver { get; set; }

        public NotificationView Parse()
        {
            return new NotificationView()
            {
                TotalizatorName = this.Totalizator.Name,
                UserLogin = this.User.Login,
                Reject = this.Reject
            };

        }
    }
}