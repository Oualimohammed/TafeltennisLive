using Pin.LiveSports.Core.DTOs;
using Pin.LiveSports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Blazor.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<PlayerDTO>> GetAvailablePlayersAsync();
        Task<List<PlayerDTO>> GetPlayersByTournamentAsync(int tournamentId);
        Task<List<PlayerDTO>> GetAllPlayersAsync();
        Task<PlayerDTO?> GetByIdPlayerAsync(int playerId);
        Task AddPlayerAsync(PlayerDTO player);
        Task UpdatePlayerAsync(PlayerDTO player);
        Task DeletePlayerAsync(int playerId);
    }
}
