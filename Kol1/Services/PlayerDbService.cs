using PlayerTeamAPI.Models;
using PlayerTeamAPI.Models.DTOs.Request;
using PlayerTeamAPI.Models.DTOs.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Services
{
    public interface IPlayerDbService 
    {
        public Task<IEnumerable<GetPlayerInfoDTO>> GetPlayers(MainDbContext context);
        public Task PostPlayer(MainDbContext context, CreatePlayerRequestDTO doctorInput);
        public Task PutPlayer(MainDbContext context, CreatePlayerRequestDTO doctorInput, string index);
        public Task DeletePlayer(MainDbContext context, string index);
    }

    public class PlayerDbService : IPlayerDbService
    {
        public async Task<IEnumerable<GetPlayerInfoDTO>> GetPlayers(MainDbContext context)
        {
            var players = await context.Player.Include(e => e.Player_Team).ThenInclude(e => e.IdTeamNavigation)
                                         .Select(e => new GetPlayerInfoDTO
                                         {
                                             FirstName = e.FirstName,
                                             LastName = e.LastName,
                                             DateOfBirth = e.DateOfBirth,
                                             Player = e.Player_Team.Select(x => new TeamInfoDTO
                                             {
                                                 TeamName = x.IdTeamNavigation.TeamName,
                                                 MaxAge = x.IdTeamNavigation.MaxAge
                                             })
                                         })
                                         .ToListAsync();
            return players;
        }

        public async Task PostPlayer(MainDbContext context, CreatePlayerRequestDTO playerInput)
        {
            var player = new Player
            {
                IdPlayer = context.Player.Max(e => e.IdPlayer) + 1,
                FirstName = playerInput.FirstName,
                LastName = playerInput.LastName,
                DateOfBirth = playerInput.DateOfBirth
            };
            context.Player.Add(player);
            await context.SaveChangesAsync();
        }

        public async Task PutPlayer(MainDbContext context, CreatePlayerRequestDTO playerInput, string index)
        {
            if (!await PlayerExists(int.Parse(index)))
            {
                throw new ArgumentException("Doctor with ID " + index + " doesnt exists");
            }
            var player = new Player
            {
                IdPlayer = int.Parse(index),
                FirstName = playerInput.FirstName,
                LastName = playerInput.LastName,
                DateOfBirth = playerInput.DateOfBirth
            };
            context.Player.Attach(player);
            context.Entry(player).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeletePlayer(MainDbContext context, string index)
        {
            if (!await PlayerExists(int.Parse(index)))
            {
                throw new ArgumentException("Doctor with ID " + index + " doesnt exists");
            }

            var player = new Player
            {
                IdPlayer = int.Parse(index)
            };
            var teams = await GetTeamWithIdPlayer(int.Parse(index));

            foreach (var p in teams)
            {
                var sth = await GetChampionship_TeamWithIdTeam(p.IdTeam);
                context.Player_Team.Remove(p);
               /* context.Player_Team.Remove(sth);*/
            }
            context.Player.Attach(player);
            context.Entry(player).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        private async Task<bool> PlayerExists(int idPlayer)
        {
            var context = new MainDbContext();
            var result = await context.Player
                .Where(t => t.IdPlayer == idPlayer)
                .ToListAsync();

            return result.Count > 0;
        }

        private async Task<IEnumerable<Player_Team>> GetTeamWithIdPlayer(int playerIndex)
        {
            var context = new MainDbContext();
            var team = await context.Player_Team
                                             .Where(e => e.IdPlayer == playerIndex)
                                             .ToListAsync();
            return team;
        }
        private async Task<Championship_Team> GetChampionship_TeamWithIdTeam(int teamIndex)
        {
            var context = new MainDbContext();
            var championship_team = await context.Championship_Team
                                             .Where(e => e.IdTeam == teamIndex)
                                             .FirstAsync();
            return championship_team;
        }
    }
}
