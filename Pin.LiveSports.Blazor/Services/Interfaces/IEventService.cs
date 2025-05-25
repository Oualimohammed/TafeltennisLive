using Pin.LiveSports.Core.DTOs;

namespace Pin.LiveSports.Blazor.Services.Interfaces
{
    public interface IEventService
    {

        /* Task<List<EventDTO>> GetEventsByMatchAsync(int playerId);
         Task<List<EventDTO>> GetAllEventsAsync();
         Task<EventDTO?> GetByIdEventAsync(int eventId);
         Task AddEventAsync(EventDTO eventDto);
         Task UpdateEventAsync(EventDTO eventDto);
         Task DeleteEventAsync(int eventId);*/


        Task<List<EventDTO>> GetAllEventsAsync();
        Task<EventDTO?> GetByIdEventAsync(int eventId);
        Task<List<EventDTO>> GetEventsByMatchAsync(int matchId);
        Task AddEventAsync(EventDTO eventDto);
        Task UpdateEventAsync(EventDTO eventDto);
        Task DeleteEventAsync(int eventId);
    }
}
