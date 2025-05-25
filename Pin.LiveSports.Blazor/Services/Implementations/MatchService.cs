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
    public class MatchService : IMatchService
    {
        private readonly IDbContextFactory<SportDbContext> _dbContextFactory;

        public MatchService(IDbContextFactory<SportDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public async Task<List<MatchDTO>> GetAllMatchesAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.Matches
                .Include(m => m.Player1)
                .Include(m => m.Player2)
                .Include(m => m.Tournament)
                .Select(m => new MatchDTO
                {
                    Id = m.Id,
                    TournamentId = m.TournamentId,
                    TournamentName = m.Tournament.Name,
                    Player1Id = m.Player1Id,
                    Player1Name = m.Player1.Name,
                    Player2Id = m.Player2Id,
                    Player2Name = m.Player2.Name,
                    Status = m.Status,
                    StartTime = m.StartTime,
                    TafelTennisZaal = m.TafelTennisZaal,
                    Player1Score = m.Player1Score,
                    Player2Score = m.Player2Score
                })
                .ToListAsync();
        }

        public async Task UpdateMatchStatusAsync(int matchId, string newStatus)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var match = await context.Matches.FindAsync(matchId);
            if (match != null)
            {
                match.Status = newStatus;
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<MatchDTO>> GetAvailableMatchesAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();

            var matches = await context.Matches
                .Include(m => m.Player1)
                .Include(m => m.Player2)
                .Include(m => m.Tournament)
                .Where(m => m.Status == "Gepland")  
                .AsNoTracking()
                .ToListAsync();

            return matches.Select(m => new MatchDTO
            {
                Id = m.Id,
                TournamentId = m.TournamentId,
                TournamentName = m.Tournament?.Name,
                Player1Id = m.Player1Id,
                Player1Name = m.Player1?.Name,
                Player2Id = m.Player2Id,
                Player2Name = m.Player2?.Name,
                StartTime = m.StartTime,
                Status = m.Status,
                TafelTennisZaal = m.TafelTennisZaal
            }).ToList();
        }



       

        public async Task DeleteMatchAsync(int matchId)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var match = await context.Matches.FindAsync(matchId);
            if (match != null)
            {
                context.Matches.Remove(match);
                await context.SaveChangesAsync();
            }
        }

        public async Task<MatchDTO?> GetByIdMatchAsync(int matchId)
        {

            using var context = _dbContextFactory.CreateDbContext();

            var match = await context.Matches
                .Include(m => m.Player1)
                .Include(m => m.Player2)
                .Include(m => m.Tournament)
                .FirstOrDefaultAsync(m => m.Id == matchId); 

            if (match == null) return null;

            return new MatchDTO
            {
                Id = match.Id,
                TournamentId = match.TournamentId,
                TournamentName = match.Tournament?.Name,
                Player1Id = match.Player1Id,
                Player1Name = match.Player1?.Name,
                Player2Id = match.Player2Id,
                Player2Name = match.Player2?.Name,
                StartTime = match.StartTime,
                Status = match.Status,
                TafelTennisZaal = match.TafelTennisZaal,
                Player1Score = match.Player1Score,
                Player2Score = match.Player2Score,
                CurrentSet = match.CurrentSet
            };
        }

        public async Task UpdateMatchAsync(MatchDTO matchDto)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var existingMatch = await context.Matches.FindAsync(matchDto.Id);
            if (existingMatch == null) throw new InvalidOperationException("Match not found.");

            // Update alle relevante velden
            existingMatch.Player1Id = matchDto.Player1Id;
            existingMatch.Player2Id = matchDto.Player2Id;
            existingMatch.StartTime = matchDto.StartTime;
            existingMatch.Status = matchDto.Status;
            existingMatch.TafelTennisZaal = matchDto.TafelTennisZaal;

            // Nieuwe velden voor tafeltennis
            existingMatch.Player1Score = matchDto.Player1Score;
            existingMatch.Player2Score = matchDto.Player2Score;
            existingMatch.Player1Sets = matchDto.Player1Sets;
            existingMatch.Player2Sets = matchDto.Player2Sets;
            existingMatch.CurrentSet = matchDto.CurrentSet;

            await context.SaveChangesAsync();
        }

        public async Task<MatchDTO> AddMatchAsync(MatchDTO matchDto)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var match = new Match
            {
                TournamentId = matchDto.TournamentId,
                Player1Id = matchDto.Player1Id,
                Player2Id = matchDto.Player2Id,
                StartTime = matchDto.StartTime,
                TafelTennisZaal = matchDto.TafelTennisZaal,
                Status = "Gepland"
            };

            context.Matches.Add(match);
            await context.SaveChangesAsync();


            return new MatchDTO
            {
                Id = match.Id, 
                TournamentId = match.TournamentId,
                Player1Id = match.Player1Id,
                Player2Id = match.Player2Id,
                StartTime = match.StartTime,
                TafelTennisZaal = match.TafelTennisZaal,
                Status = match.Status
            };
        }

    }
}


