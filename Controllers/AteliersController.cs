using Microsoft.AspNetCore.Mvc;
using AtelierHub.Services;
using AtelierHub.Models;

namespace AtelierHub.Controllers
{
    public class AteliersController : Controller
    {
        private readonly IAtelierService _service;

        public AteliersController(IAtelierService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var ateliers = await _service.GetAllAsync();
            return View(ateliers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var atelier = await _service.GetByIdAsync(id);
            if (atelier == null) return NotFound();
            return View(atelier);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Atelier atelier)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(atelier);
                return RedirectToAction(nameof(Index));
            }
            return View(atelier);
        }
    }
}