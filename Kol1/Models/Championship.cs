using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Models
{
    public class Championship
    {
        public Championship()
        {
            Championship_Team = new HashSet<Championship_Team>();
        }
        public int IdChampionship { get; set; }
        public string OfficialName { get; set; }
        public int Year { get; set; }
        public ICollection<Championship_Team> Championship_Team { get; set; }
    }
}
