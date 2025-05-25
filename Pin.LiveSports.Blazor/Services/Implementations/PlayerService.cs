using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Blazor.Data;
using Pin.LiveSports.Blazor.Services.Interfaces;
using Pin.LiveSports.Core.DTOs;
using Pin.LiveSports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pin.LiveSports.Blazor.Services.Implementations
{
    public class PlayerService : IPlayerService
    {
        private readonly IDbContextFactory<SportDbContext> _dbContextFactory;

        public PlayerService(IDbContextFactory<SportDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public async Task<List<PlayerDTO>> GetAvailablePlayersAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();

            return await context.Players
                .AsNoTracking()
                .Select(p => new PlayerDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Country = p.Country
                })
                .ToListAsync();
        }

        public async Task<List<PlayerDTO>> GetPlayersByTournamentAsync(int tournamentId)
        {
            using var context = _dbContextFactory.CreateDbContext();

            try
            {
                var tournament = await context.Tournaments
                    .Include(t => t.Players)
                    .FirstOrDefaultAsync(t => t.Id == tournamentId);

                if (tournament?.Players == null)
                {
                    Console.WriteLine("Geen spelers gevonden voor dit toernooi");
                    return new List<PlayerDTO>();
                }

                Console.WriteLine($"Gevonden spelers voor toernooi {tournamentId}:");
                foreach (var player in tournament.Players)
                {
                    Console.WriteLine($"- {player.Id}: {player.Name}");
                }

                return tournament.Players.Select(p => new PlayerDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Country = p.Country,
                    Ranking = p.Ranking,
                    BirthDate = p.BirthDate,
                    Gender = p.Gender
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij ophalen spelers: {ex.Message}");
                return new List<PlayerDTO>();
            }
        }

        public async Task AddPlayerAsync(PlayerDTO playerDto)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var player = new Player
            {
                Name = playerDto.Name,
                Country = playerDto.Country,
                Ranking = playerDto.Ranking,
                BirthDate = playerDto.BirthDate,
                Gender = playerDto.Gender
            };

            context.Players.Add(player);
            await context.SaveChangesAsync();
        }

        public async Task DeletePlayerAsync(int playerId)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var player = await context.Players.FindAsync(playerId);
            if (player != null)
            {
                context.Players.Remove(player);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<PlayerDTO>> GetAllPlayersAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();

            var players = await context.Players
                .AsNoTracking()
                .Include(p => p.Tournaments)
                .ToListAsync();

            return players.Select(p => new PlayerDTO
            {
                Id = p.Id,
                Name = p.Name,
                Country = p.Country,
                Ranking = p.Ranking,
                BirthDate = p.BirthDate,
                Gender = p.Gender
            }).ToList();
        }

        public async Task<PlayerDTO?> GetByIdPlayerAsync(int playerId)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var player = await context.Players
                .AsNoTracking()
                .Include(p => p.Tournaments)
                .FirstOrDefaultAsync(p => p.Id == playerId);

            if (player == null)
                return null;

            return new PlayerDTO
            {
                Id = player.Id,
                Name = player.Name,
                Country = player.Country,
                Ranking = player.Ranking,
                BirthDate = player.BirthDate,
                Gender = player.Gender
            };
        }

        public async Task UpdatePlayerAsync(PlayerDTO playerDto)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var existingPlayer = await context.Players
                .Include(p => p.Tournaments)
                .FirstOrDefaultAsync(p => p.Id == playerDto.Id);

            if (existingPlayer == null)
                throw new InvalidOperationException("Player not found.");

            existingPlayer.Name = playerDto.Name;
            existingPlayer.BirthDate = playerDto.BirthDate;
            existingPlayer.Ranking = playerDto.Ranking;
            existingPlayer.Country = playerDto.Country;
            existingPlayer.Gender = playerDto.Gender;

            if (playerDto.Tournaments != null)
            {
                existingPlayer.Tournaments.Clear();
                foreach (var tournamentDto in playerDto.Tournaments)
                {
                    var tournament = await context.Tournaments.FindAsync(tournamentDto.Id);
                    if (tournament != null)
                    {
                        existingPlayer.Tournaments.Add(tournament);
                    }
                }
            }

            await context.SaveChangesAsync();
        }
    }
}