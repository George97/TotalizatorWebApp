using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalizatorWebApp.Models.DTO
{
    public class MatchScheduleDTO
    {
        public int ID { get; set; }
        public string HomeTeamName { get; set; }
        public string GuestTeamName { get; set; }
        public DateTime? MatchDate { get; set; }

    }
}