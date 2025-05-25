using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.DTOs
{
    public class TournamentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

      
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        public List<PlayerDTO>? Players { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string? Location { get; set; }
    }
}
