using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalizatorWebApp.Database.Models.BusinessLayer
{
    public class NotificationView
    {
        public int NotificationId { get; set; }

        public int TotalizatorId { get; set; }

        public string TotalizatorName { get; set; }

        public string UserLogin { get; set; }

        public int UserId { get; set; }

        public bool? Reject { get; set; }
    }
}
