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
            var firstContent = _dataRepository.FindContent(1);

            if (firstContent == null)
            {
                return NotFound(); 
            }

            return View(firstContent);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

