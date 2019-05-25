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
    public class PositionsController : ControllerBase
    {
        readonly WebApiDbContext _context;

        public PositionsController(WebApiDbContext context)
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
