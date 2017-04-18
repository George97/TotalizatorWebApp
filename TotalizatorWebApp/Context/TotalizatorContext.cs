using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TotalizatorWebApp.Models;

namespace TotalizatorWebApp.Context
{
    public class TotalizatorContext: DbContext
    {
        public TotalizatorContext():base("TotalizatorLocalDB")
        {
            Database.SetInitializer<TotalizatorContext>(new DropCreateDatabaseIfModelChanges<TotalizatorContext>());
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Totalizator> Totalizators { get; set; }

        public DbSet<Forecast> Forecasts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                        .HasRequired<Team>(m => m.HomeTeam)
                        .WithMany(t => t.HomeMatches)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                        .HasRequired<Team>(m => m.GuestTeam)
                        .WithMany(t => t.GuestMatches);

            modelBuilder.Entity<Totalizator>()
                        .HasRequired<Match>(t => t.Match)
                        .WithMany(m => m.Totalizators);

            //modelBuilder.Entity<Totalizator>()
            //            .HasMany<User>(t => t.Users)
            //            .WithMany(u => u.Totalizators)
            //            .Map(tu =>
            //                    {
            //                        tu.MapLeftKey("TotalizatorRefId");
            //                        tu.MapRightKey("UserRefId");
            //                        tu.ToTable("TotalizatorUser");
            //                    });

            modelBuilder.Entity<Forecast>()
                        .HasKey(f => new { f.UserId, f.TotalizatorId })
                        .HasRequired<User>(f => f.User)
                        .WithMany(u => u.Forecasts);

            modelBuilder.Entity<Forecast>()
                        .HasRequired<Totalizator>(F => F.Totalizator)
                        .WithMany(T => T.Forecasts);
                        

        }
    }
}