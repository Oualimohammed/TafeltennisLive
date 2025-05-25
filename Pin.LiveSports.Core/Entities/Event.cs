using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public EventType EventType { get; set; }  
        public string Description { get; set; } = "Geen beschrijving beschikbaar."; 
        public int? PlayerId { get; set; }

        // Navigation properties 
        public Match Match { get; set; } = null!;
        public Player? Player { get; set; }
    }
}
