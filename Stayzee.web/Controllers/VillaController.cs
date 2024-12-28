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
        /// <summary>
        /// Villa List View
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();
            return View(villas);
        }
        /// <summary>
        /// Create Villa Form
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Create Villa Post Method
        /// </summary>
        /// <param name="villa"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Villa villa)
        {
            #region Validate
            if (string.IsNullOrWhiteSpace(villa.Name) || string.IsNullOrWhiteSpace(villa.Description))
            {
                ModelState.AddModelError("", "Name or Description should not be Empty");
            }
            if (ModelState.IsValid && villa.Name.Trim().Equals(villa?.Description.Trim(), StringComparison.InvariantCultureIgnoreCase))
            {
                ModelState.AddModelError("", "Name should be diffrent from discripiton");
            }
            #endregion

            if (ModelState.IsValid)
            {
                _context.Villas.Add(villa);
                _context.SaveChanges();
                return RedirectToAction("Index", "Villa");
            }
            return View(villa);
        }
    }
}
