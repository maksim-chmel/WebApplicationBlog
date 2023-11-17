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

            var smallerID = _dataRepository.FindSmallestID();
            var firstContent = _dataRepository.FindContent(smallerID);

            if (firstContent == null)
            {
                return NotFound(); 
            }

            return View(firstContent);
        }
        public IActionResult TopContent()
        {
            var topContent = _dataRepository.Top();
            return View("TopContent", topContent);
        }

        [HttpPost]
        public IActionResult RateUp(long id)
        {
            _dataRepository.RateContentUP(id);
            var content = _dataRepository.FindContent(id);
            return View("Index", content);
        }

        [HttpPost]
        public IActionResult RateDown(long id)
        {
            _dataRepository.RateContentDown(id);
            var content = _dataRepository.FindContent(id);
            return View("Index", content);
        }

        [HttpGet]
        public IActionResult Next(long id)
        {
            var nextContent = _dataRepository.NextContent(id);
            if (nextContent != null) 
            {
                
                return View("Index", nextContent);
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult BacK(long id)
        {
            var previousContent = _dataRepository.PreviousContent(id);

            if (previousContent != null)
            {
                return View("Index", previousContent);
            }
            else
            {
                
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AboutUs()
        {
            return View();
        }
       

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

