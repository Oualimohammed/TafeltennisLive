using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Core.Entities;
using System;
using System.Collections.Generic;

namespace Pin.LiveSports.Blazor.Data
{
    public class SportDbContext : DbContext
    {
        public SportDbContext(DbContextOptions<SportDbContext> options) : base(options)
        {
        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        //   public DbSet<Event> Events { get; set; }  // Event toegevoegd

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relatie tussen Spelers en Toernooien
            // many to many
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Tournaments)
                .WithMany(t => t.Players)
                .UsingEntity(j => j.ToTable("PlayerTournament"));

            // Relaties voor Matches
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Tournament)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.TournamentId)
                .OnDelete(DeleteBehavior.Cascade); // restrict naar cascade 

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Player1)
                .WithMany()
                .HasForeignKey(m => m.Player1Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Player2)
                .WithMany()
                .HasForeignKey(m => m.Player2Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Seed Data
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Toernooien toevoegen
            var tournaments = new List<Tournament>
            {
                new() { Id = 1, Name = "World Championship", StartDate = new DateTime(2023, 5, 1), Location = "Amsterdam" },
                new() { Id = 2, Name = "European Championship", StartDate = new DateTime(2023, 6, 1), Location = "Rotterdam" },
                new() { Id = 3, Name = "Asian Championship", StartDate = new DateTime(2023, 7, 1), Location = "Tokyo" }
            };
            modelBuilder.Entity<Tournament>().HasData(tournaments);

            // Spelers toevoegen
            var players = new List<Player>
            {
                new() { Id = 1, Name = "Lin Shidong", Country = "China", Ranking = 1, Gender = "M", BirthDate = new DateTime(1998, 1, 1) },
                new() { Id = 2, Name = "Wang Chuqin", Country = "China", Ranking = 2, Gender = "M", BirthDate = new DateTime(1998, 1, 1) },
                new() { Id = 3, Name = "Hugo Calderano", Country = "Brazilië", Ranking = 3, Gender = "M", BirthDate = new DateTime(1998, 1, 1) },
                new() { Id = 4, Name = "Harimoto Tomokazu", Country = "Japan", Ranking = 4, Gender = "M", BirthDate = new DateTime(1998, 1, 1) },
                new() { Id = 5, Name = "Liang Jingkun", Country = "China", Ranking = 5, Gender = "M", BirthDate = new DateTime(1998, 1, 1) }
            };
            modelBuilder.Entity<Player>().HasData(players);

            // Wedstrijden toevoegen
            var matches = new List<Match>
            {
              new() {
            Id = 1,
            Player1Id = 1,
            Player2Id = 2,
            StartTime = new DateTime(2023, 5, 1, 10, 0, 0),
            Status = "Gepland",
            TournamentId = 1,
            TafelTennisZaal = "Amsterdam '78",
            Player1Score = 0,
            Player2Score = 0,
            CurrentSet = 1
            },
                new() {
                    Id = 2,
                    Player1Id = 3,
                    Player2Id = 4,
                    StartTime = new DateTime(2023, 5, 1, 12, 0, 0),
                    Status = "Gepland",
                    TournamentId = 1,
                    TafelTennisZaal = "Amsterdam '78",
                    Player1Score = 0,
                    Player2Score = 0,
                    CurrentSet = 1
                    },
            };
            modelBuilder.Entity<Match>().HasData(matches);
        }
    }
}
