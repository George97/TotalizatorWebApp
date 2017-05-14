﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
//using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalizatorWebApp.Database.Entity.BusinessLayer;
using TotalizatorWebApp.Database.Entity.MatchLayer;
using TotalizatorWebApp.Database.Entity.UserLayer;

namespace TotalizatorWebApp.Database.Context
{
    public class TotalizatorContext : DbContext
    {
        public TotalizatorContext() : base("TotalizatorDB")
        {
            System.Data.Entity.Database.SetInitializer<TotalizatorContext>(new DropCreateDatabaseIfModelChanges<TotalizatorContext>());
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Stage> Stages { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Totalizator> Totalizators { get; set; }

        public DbSet<TotalizatorManager> TotalizatorManagers { get; set; }

        public DbSet<Forecast> Forecasts { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<PointsAnalysis> PointsAnalysis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>()
                        .HasKey(r => r.MatchId);

            modelBuilder.Entity<Match>()
                        .HasOptional(m => m.Result)
                        .WithRequired(r => r.Match);

            modelBuilder.Entity<Match>()
                        .HasRequired<Team>(m => m.HomeTeam)
                        .WithMany(t => t.HomeMatches)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                        .HasRequired<Team>(m => m.GuestTeam)
                        .WithMany(t => t.GuestMatches);

            modelBuilder.Entity<Match>()
                        .HasRequired<Stage>(m => m.Stage)
                        .WithMany(s => s.Matches);

            modelBuilder.Entity<Stage>()
                        .HasRequired<League>(s => s.League)
                        .WithMany(l => l.Stages);

            modelBuilder.Entity<PointsAnalysis>()
                        .HasKey(pa => pa.TotalizatorId);

            modelBuilder.Entity<Totalizator>()
                        .HasRequired<PointsAnalysis>(t => t.PointsAnalysis)
                        .WithRequiredDependent(pa => pa.Totalizator);

            modelBuilder.Entity<Totalizator>()
                        .HasRequired<Stage>(t => t.Stage)
                        .WithMany(s => s.Totalizators);

            modelBuilder.Entity<Totalizator>()
                        .HasRequired<User>(t => t.Organaizer)
                        .WithMany(u => u.Totalizators)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<TotalizatorManager>()
                        .HasRequired<User>(tm => tm.User)
                        .WithMany(u => u.TotalizatorManagers);

            modelBuilder.Entity<TotalizatorManager>()
                        .HasRequired<Totalizator>(tm => tm.Totalizator)
                        .WithMany(t => t.TotalizatorManagers);

            modelBuilder.Entity<Forecast>()
                        .HasRequired<TotalizatorManager>(f => f.TotalizatorManager)
                        .WithMany(tm => tm.Forecasts);

            modelBuilder.Entity<Match>()
                        .HasMany<Forecast>(m => m.Forecasts)
                        .WithRequired(fr => fr.Match)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notification>()
                        .HasRequired<User>(n => n.User)
                        .WithMany(u => u.Requests);

            modelBuilder.Entity<User>()
                        .HasMany<Notification>(u => u.Notifications)
                        .WithRequired(n => n.Receiver)
                        .WillCascadeOnDelete(false);

        }
    }
}
