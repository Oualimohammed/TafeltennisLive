using Pin.LiveSports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public EventType EventType { get; set; }  // Enum gebruiken !
        public string Description { get; set; } = "Geen beschrijving beschikbaar."; 
        public int? PlayerId { get; set; }

        // wedstrijd en spelergegevens direct opslaan
        public MatchDTO? Match { get; set; }
        public PlayerDTO? Player { get; set; }
    }
}
