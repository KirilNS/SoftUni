using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public FootballBettingContext()
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(x => x.BetId);

                entity.HasOne(x => x.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(f => f.GameId);

                entity.HasOne(x => x.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(f => f.UserId);
            });
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(x => x.ColorId);

                entity.HasMany(x => x.PrimaryKitTeams)
                .WithOne(p => p.PrimaryKitColor)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(x => x.SecondaryKitTeams)
                .WithOne(s => s.SecondaryKitColor)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(x => x.CountryId);
                entity.HasMany(e => e.Towns)
                .WithOne(t => t.Country);

            });
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.HasOne(e => e.HomeTeam)
                .WithMany(h => h.HomeGames)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.AwayTeam)
                .WithMany(h => h.AwayGames)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Bets)
                .WithOne(b => b.Game);
            });
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(x => x.PlayerId);

                entity.HasOne(t => t.Team)
                .WithMany(p => p.Players);

                entity.HasOne(p => p.Position)
                .WithMany(p => p.Players);
            });
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(k => new { k.GameId, k.PlayerId });

                entity.HasOne(g => g.Game)
                .WithMany(p => p.PlayerStatistics);

                entity.HasOne(g => g.Player)
                .WithMany(p => p.PlayerStatistics);

            });
            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(x => x.PositionId);
            });
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(x => x.TeamId);

                entity.HasOne(t => t.Town)
                .WithMany(t => t.Teams);

                entity.HasOne(c => c.PrimaryKitColor)
                .WithMany(t => t.PrimaryKitTeams)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.SecondaryKitColor)
                .WithMany(t => t.SecondaryKitTeams)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
