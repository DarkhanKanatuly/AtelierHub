using Microsoft.AspNetCore.Mvc;
using AtelierHub.Data;
using Microsoft.EntityFrameworkCore;
using AtelierHub.Models;

namespace AtelierHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersApiController : ControllerBase
    {
        private readonly AtelierHubContext _context;

        public MastersApiController(AtelierHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Master>>> GetMasters()
        {
            return await _context.Masters.ToListAsync();
        }
    }
}


/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AtelierHub.Models;
using AtelierHub.Data;
using System.Linq;

namespace AtelierHub.Controllers.Api
{
    [Route("api/masters")]
    [ApiController]
    [Authorize]
    public class MastersApiController : ControllerBase
    {
        private readonly AtelierHubContext _context;

        public MastersApiController(AtelierHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMasters()
        {
            var masters = _context.Masters.ToList();
            return Ok(masters);
        }

        [HttpGet("{id}")]
        public IActionResult GetMaster(int id)
        {
            var master = _context.Masters.Find(id);
            if (master == null)
            {
                return NotFound();
            }
            return Ok(master);
        }
    }
}*/