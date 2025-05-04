using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Stayzee.Domain.Entities;
using Stayzee.Infrastructure.Data;

namespace Stayzee.web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public RoomsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var rooms = _dbContext.Rooms.ToList();
            return View(rooms);
        }
        public async Task<IActionResult> CreateView()
        {
            var villaIds = await _GetAllVillasId();
            ViewBag.VillaIdList = villaIds;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Rooms rooms)
        {
            ModelState.Remove("Villa");
            if (ModelState.IsValid)
            {
                var room = await _dbContext.Rooms.AsNoTracking().FirstOrDefaultAsync(x => x.RoomId == rooms.RoomId);
                if (room != null)
                {
                    ModelState.AddModelError("RoomId", "Room Id is already exists");
                    var villaIds = await _GetAllVillasId();
                    ViewBag.VillaIdList = villaIds;
                    return View("CreateView", rooms);
                }
                _dbContext.Rooms.Add(rooms);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Room is created successfully";
                return RedirectToAction("Index", "Rooms");
            }
            TempData["error"] = "Something went wrong!";
            return RedirectToAction("CreateView", "Rooms");
        }
        [HttpGet]
        //[Route("{id}")]
        public string GetRoomsByVillaId(int villaId)
        {
            var roomName = _dbContext.Villas.FirstOrDefault(x => x.Id == villaId)?.Name;
            return roomName;
        }
        [HttpGet]
        public async Task<IActionResult> UpdateView(int roomId)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.RoomId == roomId);
            if (room == null)
            {
                TempData["error"] = "Data Not Found";
                return RedirectToAction("Index", "Rooms");
            }
            var villaIds = await _GetAllVillasId();
            ViewBag.VillaIdList = villaIds;
            return View(room);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Rooms room)
        {
            ModelState.Remove("Villa");
            if (ModelState.IsValid)
            {
                _dbContext.Rooms.Update(room);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Rooms");
            }
            else
            {
                TempData["error"] = "One or more validation fires";
                var villaIds = await _GetAllVillasId();
                ViewBag.VillaIdList = villaIds;
                return View("UpdateView", room);
            }
        }
        public async Task<IActionResult> Delete(int roomId)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.RoomId == roomId);
            if (room == null)
            {
                TempData["error"] = "Data Not Found";
                return RedirectToAction("Index", "Rooms");
            }
            _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();
            TempData["success"] = $"RoomId : {roomId} successfully deleted!";
            return RedirectToAction("Index", "Rooms");
        }
        #region Private methods
        private async Task<IEnumerable<int>> _GetAllVillasId()
        {
            var res = await _dbContext.Villas.AsNoTracking().ToListAsync();
            return res.Select(x => x.Id);
        }
        #endregion
    }
}
