namespace TotalizatorWebApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TotalizatorWebApp.Models;

    public partial class TotalizatorContext : DbContext
    {
        public TotalizatorContext()
            : base("name=TotalizatorContext")
        {
        }

        public virtual DbSet<MatchSchedule> MatchSchedules { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(e => e.HomeMatches)
                .WithRequired(e => e.HomeTeam)
                .HasForeignKey(e => e.HomeTeamID);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.GuestMatches)
                .WithRequired(e => e.GuestTeam)
                .HasForeignKey(e => e.GuestTeamID);
        }
    }
}
