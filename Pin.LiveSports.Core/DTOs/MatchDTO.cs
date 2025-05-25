using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.DTOs
{
    public class MatchDTO
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int Player1Id { get; set; }
        public string Player1Name { get; set; }
        public int Player2Id { get; set; }
        public string Player2Name { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public string TafelTennisZaal { get; set; }

        // Nieuw voor tafeltennis
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public int CurrentSet { get; set; } = 1;

        public int Player1Sets { get; set; }
        public int Player2Sets { get; set; }

        public string ScoreDisplay => $"{Player1Score}-{Player2Score} (Set {CurrentSet}) | Sets: {Player1Sets}-{Player2Sets}";

        public bool IsMatchPoint =>
           (Player1Score >= 10 || Player2Score >= 10)
           && Math.Abs(Player1Score - Player2Score) >= 2;
    }
}
