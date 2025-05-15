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
            return View("~/Views/Ateliers/Index.cshtml", ateliers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var atelier = await _service.GetByIdAsync(id);
            if (atelier == null) return NotFound();
            return View(atelier);
        }

        public IActionResult Create()
        {
            Console.WriteLine("Entering AteliersController.Create GET");
            return View("~/Views/Ateliers/Create.cshtml");
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
            return View("~/Views/Ateliers/Create.cshtml", atelier);
        }
    }
}