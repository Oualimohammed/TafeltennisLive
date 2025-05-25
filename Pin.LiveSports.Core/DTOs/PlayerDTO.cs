using Pin.LiveSports.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.DTOs
{
    public class PlayerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country can't be longer than 50 characters.")]
        public string Country { get; set; }

        [Range(1, 1000, ErrorMessage = "Ranking must be between 1 and 1000.")]
        public int? Ranking { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime? BirthDate { get; set; }


        [Required(ErrorMessage = "Gender is required.")]
        public string? Gender { get; set; }
        public List<TournamentDTO>? Tournaments { get; set; }
    }
}
