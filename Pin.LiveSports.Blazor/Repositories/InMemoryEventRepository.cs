using Pin.LiveSports.Core.Entities;

namespace Pin.LiveSports.Blazor.Repositories
{
    public class InMemoryEventRepository
    {
        private readonly List<Event> _events = new List<Event>();

        // Haal alle events op
        public List<Event> GetAll()
        {
            return _events;
        }

        // Haal events op op basis van matchId
        public List<Event> GetByMatchId(int matchId)
        {
            return _events.Where(e => e.MatchId == matchId).ToList();
        }

        // Haal event op basis van eventId
        public Event GetById(int eventId)
        {
            return _events.FirstOrDefault(e => e.Id == eventId);
        }

        // Voeg een event toe
        public void Add(Event eventEntity)
        {
            eventEntity.Id = _events.Count + 1; 
            _events.Add(eventEntity);
        }

        public void Update(Event eventEntity)
        {
            var existingEvent = _events.FirstOrDefault(e => e.Id == eventEntity.Id);
            if (existingEvent != null)
            {
                existingEvent.EventType = eventEntity.EventType;
                existingEvent.Description = eventEntity.Description;
                existingEvent.PlayerId = eventEntity.PlayerId;
            }
        }

        // een event verwijderen
        public void Delete(int eventId)
        {
            var eventEntity = _events.FirstOrDefault(e => e.Id == eventId);
            if (eventEntity != null)
            {
                _events.Remove(eventEntity);
            }


            var e = _events.FirstOrDefault(ev => ev.Id == eventId);
            if (e != null)
            {
                _events.Remove(e);
            }
        }
    }
}

