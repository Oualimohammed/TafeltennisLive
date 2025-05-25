using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.LiveSports.Core.Entities
{
    public enum EventType
    {
        //TafelTennis
        PointScored,
        SetWon,
        MatchWon,
        SetStarted,
        MatchStarted,
        Timeout,
        Fault,
        Let,
        ServiceChange
    }
}
