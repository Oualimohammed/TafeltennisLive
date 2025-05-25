using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Entities
{
    public class Tournament
    {
        public int Id { get; set; }

      //  [Required(ErrorMessage = "Toernooinaam is verplicht")]
        public string Name { get; set; }

      //  [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public List<Player>? Players { get; set; }
        public string? Location { get; set; }

        public List<Match>? Matches { get; set; } = new List<Match>();
    }
}
