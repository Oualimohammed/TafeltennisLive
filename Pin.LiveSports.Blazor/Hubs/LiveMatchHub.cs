using Microsoft.AspNetCore.SignalR;
using Pin.LiveSports.Core.DTOs;

namespace Pin.LiveSports.Blazor.Hubs
{
    public class LiveMatchHub : Hub
    {
        public async Task JoinMatchGroup(int matchId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Match-{matchId}");
        }

        public async Task NotifyMatchUpdate(MatchDTO match)
        {
            await Clients.Group($"Match-{match.Id}").SendAsync("ReceiveMatchUpdate", match);
        }

        public async Task NotifyNewEvent(EventDTO eventDto)
        {
            await Clients.Group($"Match-{eventDto.MatchId}").SendAsync("ReceiveNewEvent", eventDto);
        }
    }
}