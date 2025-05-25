using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.DTOs;
using Pin.LiveSports.Blazor.Data;
using Pin.LiveSports.Blazor.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pin.LiveSports.Blazor.Services.Implementations
{
    public class TournamentService : ITournamentService
    {
        private readonly IDbContextFactory<SportDbContext> _dbContextFactory;

        public TournamentService(IDbContextFactory<SportDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public async Task AddTournamentAsync(TournamentDTO tournamentDto)
        {
            using var context = _dbContextFactory.CreateDbContext();

            if (tournamentDto == null)
                throw new ArgumentNullException(nameof(tournamentDto), "Tournament object is null.");

            var tournament = new Tournament
            {
                Name = tournamentDto.Name,
                Location = tournamentDto.Location,
                StartDate = tournamentDto.StartDate,
                Players = new List<Player>()
            };

            if (tournamentDto.Players != null && tournamentDto.Players.Any())
            {
                var playerIds = tournamentDto.Players.Select(p => p.Id).ToList();
                tournament.Players = await context.Players.Where(p => playerIds.Contains(p.Id)).ToListAsync();
            }

            context.Tournaments.Add(tournament);
            await context.SaveChangesAsync();
        }

        public async Task AddPlayerToTournamentAsync(int tournamentId, int playerId)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var tournament = await context.Tournaments.Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == tournamentId);
            if (tournament == null)
                throw new Exception($"Tournament with ID {tournamentId} not found.");

            var player = await context.Players.FindAsync(playerId);
            if (player == null)
                throw new Exception($"Player with ID {playerId} not found.");

            if (!tournament.Players.Contains(player))
            {
                tournament.Players.Add(player);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteTournamentAsync(int tournamentId)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var tournament = await context.Tournaments.FindAsync(tournamentId);
            if (tournament == null)
                throw new Exception($"Tournament with ID {tournamentId} not found.");

            context.Tournaments.Remove(tournament);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TournamentDTO>> GetAllTournamentAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();

            var tournaments = await context.Tournaments
                .AsNoTracking()
                .Include(t => t.Players)
                .ToListAsync();

            return tournaments.Select(t => new TournamentDTO
            {
                Id = t.Id,
                Name = t.Name,
                Location = t.Location,
                StartDate = t.StartDate,
                Players = t.Players?.Select(p => new PlayerDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Country = p.Country,
                    Ranking = p.Ranking,
                    BirthDate = p.BirthDate,
                    Gender = p.Gender
                }).ToList()
            }).ToList();
        }

        public async Task<TournamentDTO?> GetByIdTournamentAsync(int tournamentId)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var tournament = await context.Tournaments
                .AsNoTracking()
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == tournamentId);

            if (tournament == null) return null;

            return new TournamentDTO
            {
                Id = tournament.Id,
                Name = tournament.Name,
                Location = tournament.Location,
                StartDate = tournament.StartDate,
                Players = tournament.Players?.Select(p => new PlayerDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Country = p.Country,
                    Ranking = p.Ranking,
                    BirthDate = p.BirthDate,
                    Gender = p.Gender
                }).ToList()
            };
        }

        public async Task UpdateTournamentAsync(TournamentDTO tournamentDto)
        {
            using var context = _dbContextFactory.CreateDbContext();

            if (tournamentDto == null)
                throw new ArgumentNullException(nameof(tournamentDto), "Tournament object is null.");

            var existingTournament = await context.Tournaments
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == tournamentDto.Id);

            if (existingTournament == null)
                throw new Exception($"Tournament with ID {tournamentDto.Id} not found.");

            existingTournament.Name = tournamentDto.Name;
            existingTournament.Location = tournamentDto.Location;
            existingTournament.StartDate = tournamentDto.StartDate;

            if (tournamentDto.Players != null)
            {
                var newPlayerIds = tournamentDto.Players.Select(p => p.Id).ToList();
                var currentPlayerIds = existingTournament.Players.Select(p => p.Id).ToList();

                existingTournament.Players.RemoveAll(p => !newPlayerIds.Contains(p.Id));

                var playersToAdd = await context.Players.Where(p => newPlayerIds.Contains(p.Id) && !currentPlayerIds.Contains(p.Id)).ToListAsync();
                existingTournament.Players.AddRange(playersToAdd);
            }

            await context.SaveChangesAsync();
        }
    }
}
