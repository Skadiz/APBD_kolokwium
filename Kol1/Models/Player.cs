using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Models
{
    public class Player
    {
        public Player()
        {
            Player_Team = new HashSet<Player_Team>();
        }
        public int IdPlayer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Player_Team> Player_Team { get; set; }
    }
}
