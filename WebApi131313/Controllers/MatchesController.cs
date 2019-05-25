using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        readonly VolleyballDbContext _context;

        public MatchesController(VolleyballDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Post([FromBody]Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Matches.Add(match);
                await _context.SaveChangesAsync();

                return Ok("Матч создан.");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
