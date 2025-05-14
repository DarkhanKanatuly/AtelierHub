using Microsoft.AspNetCore.Mvc;
using AtelierHub.Services;
using AtelierHub.Models;

namespace AtelierHub.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AteliersController : ControllerBase
    {
        private readonly IAtelierService _service;

        public AteliersController(IAtelierService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ateliers = await _service.GetAllAsync();
            return Ok(ateliers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var atelier = await _service.GetByIdAsync(id);
            if (atelier == null) return NotFound();
            return Ok(atelier);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Atelier atelier)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.AddAsync(atelier);
            return CreatedAtAction(nameof(GetById), new { id = atelier.Id }, atelier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Atelier atelier)
        {
            if (id != atelier.Id) return BadRequest();
            await _service.UpdateAsync(atelier);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}