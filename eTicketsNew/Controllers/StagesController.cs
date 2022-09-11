using eTicketsNew.Data;
using eTicketsNew.Data.Services;
using eTicketsNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsNew.Controllers
{
    public class StagesController : Controller
    {
        private readonly IStagesService _service;

        public StagesController(IStagesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allStages = await _service.GetAllAsync();
            return View(allStages);
        }


        //GET:/Stages/Greate
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Stage stage)
        {
            if (!ModelState.IsValid) return View(stage);

            await _service.AddAsync(stage);
            return RedirectToAction(nameof(Index));
        }


        //GET:/Stages/Details
        public async Task<IActionResult> Details(int id)
        {
            var stageDetails = await _service.GetByIdAsync(id);
            if (stageDetails == null) return View("NotFound");
            return View(stageDetails);
        }


        //GET:/Stages/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var stageDetails = await _service.GetByIdAsync(id);
            if (stageDetails == null) return View("NotFound");
            return View(stageDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Stage stage)
        {
            if (!ModelState.IsValid) return View(stage);
            await _service.UpdateAsync(id, stage);
            return RedirectToAction(nameof(Index));
        }



        //GET:/Stages/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var stageDetails = await _service.GetByIdAsync(id);
            if (stageDetails == null) return View("NotFound");
            return View(stageDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stageDetails = await _service.GetByIdAsync(id);
            if (stageDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
