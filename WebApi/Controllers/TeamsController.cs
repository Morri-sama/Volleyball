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
        VolleyballDbContext _context;

        public TeamsController(VolleyballDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("Teams")]
        public ActionResult<List<Team>> Get()
        {
            return _context.Teams.ToList();
        }

        public IActionResult Post([FromBody] Team team)
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
