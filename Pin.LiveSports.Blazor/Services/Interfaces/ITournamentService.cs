using Pin.LiveSports.Core.DTOs;
using Pin.LiveSports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Blazor.Services.Interfaces
{
    public interface ITournamentService
    {
        Task<IEnumerable<TournamentDTO>> GetAllTournamentAsync();
        Task<TournamentDTO> GetByIdTournamentAsync(int tournamentId);
        Task AddTournamentAsync(TournamentDTO tournament);
        Task UpdateTournamentAsync(TournamentDTO tournament);
        Task DeleteTournamentAsync(int tournamentId);
        Task AddPlayerToTournamentAsync(int tournamentId, int playerId);
    }
}
