using Microsoft.AspNetCore.Mvc;
using Models.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : ControllerBase
    {
        readonly VolleyballDbContext _context;

        public SetsController(VolleyballDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("{matchId}")]
        public IActionResult Get(int matchId)
        {
            var teams = _context.Sets.Where(d => d.MatchId == matchId);
            return Ok(teams);
        }
    }
}
