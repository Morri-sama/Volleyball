using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.DbContexts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        readonly WebApiDbContext _context;

        public PlayersController(WebApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var players = _context.Players.ToList();
            if (!players.Any())
            {
                return Ok(null);
            }
            return Ok(players);
        }

        [HttpGet]
        [Route("{teamId}")]
        public IActionResult Get(int teamId)
        {
            var players = _context.Players.Where(p => p.TeamId == teamId).ToList();
            if (!players.Any())
            {
                return Ok(null);
            }
            return Ok(players);
        }

        [HttpPost]
        public IActionResult Post(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return Ok();
        }
    }
}
