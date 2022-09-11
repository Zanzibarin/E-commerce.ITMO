using eTicketsNew.Data;
using eTicketsNew.Data.Services;
using eTicketsNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsNew.Controllers
{
    public class PlaysController : Controller
    {
        private readonly IPlaysService _service;

        public PlaysController(IPlaysService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allPlays = await _service.GetAllAsync(n => n.Stage);
            return View(allPlays);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allPlays = await _service.GetAllAsync(n => n.Stage);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filterResult = allPlays.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filterResult);
            }

            return View("Index", allPlays);
        }



        //GET:/Plays/Details
        public async Task<IActionResult> Details(int id)
        {
            var playDetail = await _service.GetPlayByIdAsync(id);
            return View(playDetail);
        }


        //GET:/Plays/Create
        public async Task <IActionResult> Create()
        {
            var playDropdownsData = await _service.GetNewPlayDropdownsValues();
            ViewBag.Stages = new SelectList(playDropdownsData.Stages, "Id", "Name");
            ViewBag.Directors = new SelectList(playDropdownsData.Directors, "Id", "FullName");
            ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewPlayVM play)
        {
            if (!ModelState.IsValid)
            {
                var playDropdownsData = await _service.GetNewPlayDropdownsValues();
                ViewBag.Stages = new SelectList(playDropdownsData.Stages, "Id", "Name");
                ViewBag.Directors = new SelectList(playDropdownsData.Directors, "Id", "FullName");
                ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");
                return View(play);
            }

            await _service.AddNewPlayAsync(play);
            return RedirectToAction(nameof(Index));
        }



        //GET:/Plays/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var playDetails = await _service.GetPlayByIdAsync(id);
            if (playDetails == null) return View("NotFound");

            var response = new NewPlayVM()
            {
                Id = playDetails.Id,
                Name = playDetails.Name,
                Description = playDetails.Description,
                Price = playDetails.Price,
                StartDate = playDetails.StartDate,
                EndDate = playDetails.EndDate,
                ImageURL = playDetails.ImageURL,
                PlayCategory = playDetails.PlayCategory,
                StageId = playDetails.StageId,
                DirectorId = playDetails.DirectorId,
                ActorIds = playDetails.Actors_Plays.Select(n => n.ActorId).ToList(),
            };

            var playDropdownsData = await _service.GetNewPlayDropdownsValues();
            ViewBag.Stages = new SelectList(playDropdownsData.Stages, "Id", "Name");
            ViewBag.Directors = new SelectList(playDropdownsData.Directors, "Id", "FullName");
            ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewPlayVM play)
        {
            if (id != play.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var playDropdownsData = await _service.GetNewPlayDropdownsValues();
                ViewBag.Stages = new SelectList(playDropdownsData.Stages, "Id", "Name");
                ViewBag.Directors = new SelectList(playDropdownsData.Directors, "Id", "FullName");
                ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");
                return View(play);
            }

            await _service.UpdatePlayAsync(play);
            return RedirectToAction(nameof(Index));
        }
    }
}
