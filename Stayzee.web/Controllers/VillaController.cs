using Microsoft.AspNetCore.Mvc;
using Stayzee.Application.ServiceContract;
using Stayzee.Domain.Entities;
using Stayzee.Infrastructure.Data;

namespace Stayzee.web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;

        public VillaController(IVillaService villaService)
        {
            _villaService = villaService;
        }
        /// <summary>
        /// Villa List View
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var villas = await _villaService.GetAllAsync();
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
                _villaService.AddVillaAsync(villa);
                return RedirectToAction("Index", "Villa");
            }
            return View(villa);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int villaId)
        {
            Villa? villa = await _villaService.GetAsync(villaId);
            if (villa == null)
            {
                return NotFound();
            }
            return View(villa);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Villa villa)
        {
            if (ModelState.IsValid)
            {
                await _villaService.UpdateVillaAsync(villa);
                TempData["success"] = "Villa successfully updated";
                return RedirectToAction("Index", "Villa");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int villaId)
        {
            Villa? villa = await _villaService.GetAsync(villaId);
            if (villa == null)
            {
                return NotFound();
            }
            return View(villa);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Villa villa)
        {
            Villa? obj = await _villaService.GetAsync(villa.Id);
            if (obj != null)
            {
                await _villaService.DeleteVillaAsync(villa.Id);
                TempData["success"] = "Villa successfully deleted";
                return RedirectToAction("Index", "Villa");
            }
            return View();
        }
    }
}
