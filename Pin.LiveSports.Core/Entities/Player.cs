using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
        public int? Ranking { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public List<Tournament>? Tournaments { get; set; } 
    }
}
