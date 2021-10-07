using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Models.DTOs.Response
{
    public class GetChampionship_TeamResponseDTO
    {
        public float Score  { get; set; }
        public string Championship { get; set; }
        public string Team { get; set; }
        public IEnumerable<ChampionshipInfoDTO> Championships { get; set; } = new HashSet<ChampionshipInfoDTO>();
    }
}
