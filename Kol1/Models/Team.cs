using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Models
{
    public class Team
    {
        public Team()
        {
            Player_Team = new HashSet<Player_Team>();
            Championship_Team = new HashSet<Championship_Team>();
        }

        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }

        public ICollection<Player_Team> Player_Team { get; set; }
        public ICollection<Championship_Team> Championship_Team { get; set; }

    }
}
