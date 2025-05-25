using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int Player1Id { get; set; }
        public Player Player1 { get; set; }
        public int Player2Id { get; set; }
        public Player Player2 { get; set; }
        public DateTime StartTime { get; set; }
        public string Status { get; set; } 

        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public int CurrentSet { get; set; } = 1;

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public string TafelTennisZaal { get; set; }

        public int Player1Sets { get; set; }
        public int Player2Sets { get; set; }

        // helper prop gebruiken voor scoreweergave
        public bool IsMatchPoint =>
            (Player1Score >= 10 || Player2Score >= 10)
            && Math.Abs(Player1Score - Player2Score) >= 2;
    }
}
