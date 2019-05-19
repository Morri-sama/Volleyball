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
    public class TeamsController : ControllerBase
    {
        readonly VolleyballDbContext _context;

        public TeamsController(VolleyballDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var teams = _context.Teams.ToList();
            if (!teams.Any())
            {
                return NotFound();
            }
            return Ok(teams);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();

                return Ok("Команда добавлена.");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
