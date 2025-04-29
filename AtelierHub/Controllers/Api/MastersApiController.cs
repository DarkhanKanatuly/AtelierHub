using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtelierHub.Data;
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