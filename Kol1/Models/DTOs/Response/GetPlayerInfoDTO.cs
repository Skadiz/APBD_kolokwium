using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Models.DTOs.Response
{
    public class GetPlayerInfoDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<TeamInfoDTO> Player { get; set; } = new List<TeamInfoDTO>();
    }
}
