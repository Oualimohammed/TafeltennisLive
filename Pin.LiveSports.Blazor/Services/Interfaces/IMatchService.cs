using Pin.LiveSports.Core.DTOs;

namespace Pin.LiveSports.Blazor.Services.Interfaces
{
    public interface IMatchService
    {
      //  Task<List<MatchDTO>> GetMatchesByTournamentAsync();
        Task<List<MatchDTO>> GetAllMatchesAsync();
        Task<MatchDTO?> GetByIdMatchAsync(int matchId);
        // Task AddMatchAsync(MatchDTO match);
        Task<MatchDTO> AddMatchAsync(MatchDTO matchDto);

        Task UpdateMatchAsync(MatchDTO match);
        Task DeleteMatchAsync(int matchId);
        Task<List<MatchDTO>> GetAvailableMatchesAsync();
        // UpdateMatchStatusAsync
        Task UpdateMatchStatusAsync(int matchId, string status);

    }
}
