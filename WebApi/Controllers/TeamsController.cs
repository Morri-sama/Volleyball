using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class TeamsController : ControllerBase
    {
        readonly WebApiDbContext _context;

        public TeamsController(WebApiDbContext context)
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
