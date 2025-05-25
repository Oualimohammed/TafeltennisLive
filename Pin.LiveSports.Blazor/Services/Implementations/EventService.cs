using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Blazor.Data;
using Pin.LiveSports.Blazor.Repositories;
using Pin.LiveSports.Blazor.Services.Interfaces;
using Pin.LiveSports.Core.DTOs;
using Pin.LiveSports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pin.LiveSports.Blazor.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly InMemoryEventRepository _eventRepository;

        public EventService(InMemoryEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        // events halen op basis van matchId
        public Task<List<EventDTO>> GetEventsByMatchAsync(int matchId)
        {
            var events = _eventRepository.GetByMatchId(matchId)
                                         .Select(e => new EventDTO
                                         {
                                             Id = e.Id,
                                             MatchId = e.MatchId,
                                             Timestamp = e.Timestamp,
                                             EventType = e.EventType,
                                             Description = e.Description,
                                             PlayerId = e.PlayerId
                                         })
                                         .ToList();
            return Task.FromResult(events);
        }

        // Haal alle events op
        public Task<List<EventDTO>> GetAllEventsAsync()
        {
            var events = _eventRepository.GetAll()
                                         .Select(e => new EventDTO
                                         {
                                             Id = e.Id,
                                             MatchId = e.MatchId,
                                             Timestamp = e.Timestamp,
                                             EventType = e.EventType,
                                             Description = e.Description,
                                             PlayerId = e.PlayerId
                                         })
                                         .ToList();
            return Task.FromResult(events);
        }

        // Haal event op basis van eventId
        public Task<EventDTO?> GetByIdEventAsync(int eventId)
        {
            var eventEntity = _eventRepository.GetById(eventId);
            if (eventEntity == null) return Task.FromResult<EventDTO?>(null);

            var eventDto = new EventDTO
            {
                Id = eventEntity.Id,
                MatchId = eventEntity.MatchId,
                Timestamp = eventEntity.Timestamp,
                EventType = eventEntity.EventType,
                Description = eventEntity.Description,
                PlayerId = eventEntity.PlayerId
            };
            return Task.FromResult<EventDTO?>(eventDto);
        }

        // Voeg een event toe
        public Task AddEventAsync(EventDTO eventDto)
        {
            var eventEntity = new Event
            {
                Id = eventDto.Id,
                MatchId = eventDto.MatchId,
                Timestamp = eventDto.Timestamp,
                EventType = eventDto.EventType,
                Description = eventDto.Description,
                PlayerId = eventDto.PlayerId
            };

            _eventRepository.Add(eventEntity);
            return Task.CompletedTask;
        }

        // Update een event
        public Task UpdateEventAsync(EventDTO eventDto)
        {
            var eventEntity = new Event
            {
                Id = eventDto.Id,
                MatchId = eventDto.MatchId,
                Timestamp = eventDto.Timestamp,
                EventType = eventDto.EventType,
                Description = eventDto.Description,
                PlayerId = eventDto.PlayerId
            };

            _eventRepository.Update(eventEntity);
            return Task.CompletedTask;
        }

        // Verwijder een event
        public Task DeleteEventAsync(int eventId)
        {
            _eventRepository.Delete(eventId);
            return Task.CompletedTask;
        }
    }
}
