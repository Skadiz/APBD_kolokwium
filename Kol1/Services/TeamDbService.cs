using PlayerTeamAPI.Models;
using PlayerTeamAPI.Models.DTOs.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Services
{

    public interface ITeamDbService
    {
        public Task<GetPlayer_TeamResponseDTO> GetPrescription(MainDbContext context, string index);
    }

    public class TeamDbService : ITeamDbService
    {
        public async Task<GetPlayer_TeamResponseDTO> GetPrescription(MainDbContext context, string index)
        {
            int IdPT = int.Parse(index);
            var pt = await context.Player_Team
                                            .Where(e => e.IdPlayerTeam == int.Parse(index))
                                            .Include(e => e.IdPlayerNavigation)
                                            .Include(e => e.IdTeamNavigation)
                                            .Select(e => new GetPlayer_TeamResponseDTO
                                            {
                                                NumOnShirt = e.NumOnShirt,
                                                Comment = e.Comment,
                                                Player = e.IdPlayerNavigation.FirstName + " " + e.IdPlayerNavigation.LastName,
                                                Team = e.IdTeamNavigation.TeamName + " " + e.IdTeamNavigation.MaxAge,
                                                                                         })
                                            .FirstOrDefaultAsync();
            return pt;
        }
    }
}
