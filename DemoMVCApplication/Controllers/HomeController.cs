using DemoMVCApplication.Models;
using DemoMVCApplication.Models.Contracts;
using DemoMVCApplication.Models.Dto;
using DemoMVCApplication.Models.Entity;
using DemoMVCApplication.Models.Wrapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDemoDataService _demoDataService;

        public HomeController(ILogger<HomeController> logger, IDemoDataService demoDataService)
        {
            _logger = logger;
            _demoDataService = demoDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Table()
        {
            try
            {
                var users = await _demoDataService.FetchAll();
                return View(users);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(nameof(HomeController)))
                {
                    _logger.LogError(ex, "An error occurred while fetching users in the Table action.");
                }

                return View("Error");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
