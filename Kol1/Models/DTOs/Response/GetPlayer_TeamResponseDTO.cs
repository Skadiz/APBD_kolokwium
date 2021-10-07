using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Models.DTOs.Response
{
    public class GetPlayer_TeamResponseDTO
    {
        public int NumOnShirt { get; set; }
        public string Comment { get; set; }
        public string Player { get; set; }
        public string Team { get; set; }
        public IEnumerable<GetPlayerInfoDTO> Players { get; set; } = new HashSet<GetPlayerInfoDTO>();
    }
}
