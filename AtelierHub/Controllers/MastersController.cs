using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AtelierHub.Models;
using AtelierHub.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace AtelierHub.Controllers
{
    public class MastersController : Controller
    {
        private readonly ILogger<MastersController> _logger;
        private readonly AtelierHubContext _context;

        public MastersController(ILogger<MastersController> logger, AtelierHubContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Fetching list of masters from database.");
            var masters = _context.Masters.ToList();
            return View(masters);
        }

        public IActionResult Details(int id)
        {
            _logger.LogInformation($"Fetching details for master with ID {id}.");
            var master = _context.Masters.Find(id);
            if (master == null)
            {
                _logger.LogWarning($"Master with ID {id} not found.");
                return NotFound();
            }
            return View(master);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var master = new Master
                {
                    Name = model.Name,
                    Specialty = model.Specialty,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    ContactEmail = model.ContactEmail
                };
                _context.Masters.Add(master);
                _context.SaveChanges();
                _logger.LogInformation($"Master {master.Name} created successfully.");
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Invalid data submitted for creating a master.");
            return View(model);
        }
    }
}