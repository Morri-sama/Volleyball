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
    public class PositionsController : ControllerBase
    {
        VolleyballDbContext _context;

        public PositionsController(VolleyballDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Position>> Get()
        {
            return _context.Positions.ToList();
        }
    }
}
