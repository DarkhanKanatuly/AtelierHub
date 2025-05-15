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
            Console.WriteLine("Entering AteliersController.Index");
            var ateliers = await _service.GetAllAsync();
            return View("~/Views/Ateliers/Index.cshtml", ateliers);
        }

        public async Task<IActionResult> Details(int id)
        {
            Console.WriteLine($"Entering AteliersController.Details with id: {id}");
            var atelier = await _service.GetByIdAsync(id);
            if (atelier == null) return NotFound();
            return View(atelier);
        }

        public IActionResult Create()
        {
            Console.WriteLine("Entering AteliersController.Create GET");
            var viewPath = "~/Views/Ateliers/Create.cshtml";
            Console.WriteLine($"Attempting to render view: {viewPath}");
            return View(viewPath);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Atelier atelier)
        {
            Console.WriteLine($"Entering AteliersController.Create POST: Name={atelier.Name}, Address={atelier.Address}, Description={atelier.Description}, OwnerId={atelier.OwnerId}");
            if (ModelState.IsValid)
            {
                atelier.OwnerId = User.Identity.IsAuthenticated ? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "" : "";
                await _service.AddAsync(atelier);
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("ModelState invalid: " + string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
            return View("~/Views/Ateliers/Create.cshtml", atelier);
        }
    }
}