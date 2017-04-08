namespace TotalizatorWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatchSchedule")]
    public partial class MatchSchedule
    {
        public int ID { get; set; }

        public int? HomeTeamID { get; set; }

        public int? GuestTeamID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? MatchDate { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team GuestTeam { get; set; }
    }
}
