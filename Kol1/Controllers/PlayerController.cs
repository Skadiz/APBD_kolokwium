using PlayerTeamAPI.Models;
using PlayerTeamAPI.Models.DTOs.Request;
using PlayerTeamAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private MainDbContext _context;

        public DoctorController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await new PlayerDbService().GetPlayers(_context);
            return Ok(players);
        }

        [HttpPost]
        public async Task<IActionResult> PostPlayer(CreatePlayerRequestDTO playerInput)
        {
            await new PlayerDbService().PostPlayer(_context , playerInput);
            return StatusCode(201);
        }

        [HttpPut("{index}")]
        public async Task<IActionResult> PutPlayer(CreatePlayerRequestDTO playerInput, string index)
        {
            await new PlayerDbService().PutPlayer(_context, playerInput, index);
            return NoContent();
        }

        [HttpDelete("{index}")]
        public async Task<IActionResult> DeletePLayer(string index)
        {
            await new PlayerDbService().DeletePlayer(_context, index);
            return NoContent();
        }
    }
}
