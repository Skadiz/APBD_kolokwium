using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Models
{
    public class Championship_Team
    {
        public int IdChampionshipTeam { get; set; }
        public int IdChampionship { get; set; }
        public int IdTeam { get; set; }
        public float Score { get; set; }
        public Team IdTeamNavigation { get; set; }
        public Championship IdChampionshipNavigation { get; set; }
    }
}
