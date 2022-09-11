using eTicketsNew.Data;
using eTicketsNew.Data.Services;
using eTicketsNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsNew.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly IDirectorsService _service;

        public DirectorsController(IDirectorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allDirectors = await _service.GetAllAsync();
            return View(allDirectors);
        }

        //GET: Directors/details
        public async Task<IActionResult> Details(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            return View(directorDetails);
        }

        //GET: Directors/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Director director)
        {
            if (!ModelState.IsValid) return View(director);

            await _service.AddAsync(director);
            return RedirectToAction(nameof(Index));
        }


        //GET: Directors/edit
        public async Task<IActionResult> Edit(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            return View(directorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Director director)
        {
            if (!ModelState.IsValid) return View(director);

            if(id == director.Id)
            {
                await _service.UpdateAsync(id, director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }


        //GET: Directors/delete
        public async Task<IActionResult> Delete(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            return View(directorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
