using Microsoft.AspNetCore.Mvc;
using Stayzee.Domain.Entities;
using Stayzee.Infrastructure.Data;

namespace Stayzee.web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();
            return View(villas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create12(Villa villa)
        {
            _context.Villas.Add(villa);
            _context.SaveChanges();
            return RedirectToAction("Index","Villa");
        }
    }
}
