using Microsoft.AspNetCore.Mvc;
using newProject.Models;
using System.Diagnostics;

namespace newProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public HomeController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            var firstContent = _dataRepository.FindContent(2);

            if (firstContent == null)
            {
                return NotFound(); 
            }

            return View(firstContent);
        }
        [HttpPost]
        public IActionResult RateUp(long id)
        {
            _dataRepository.RateContentUP(id);

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public IActionResult RateDown(long id)
        {
            _dataRepository.RateContentDown(id);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Random()
        {
            var randomContent = _dataRepository.FindRandomContent();
            if (randomContent == null)
            {
                return NotFound();
            }
            return View(randomContent);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

