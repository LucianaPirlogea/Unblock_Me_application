using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Unblock_Me.Models;

namespace Unblock_Me.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Unblock_MeContext _dbContext;
        public HomeController(ILogger<HomeController> logger, Unblock_MeContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Search(string searchText) {
            var car = _dbContext.Car.FirstOrDefault(car => car.LicencePlate == searchText);
            if(car!=null)
                return View(car);
            else
            {
                return BadRequest();
            }
        }

        public IActionResult I_blocked()
        {
            return View();
        }

        public IActionResult I_unblocked()
        {
            return View();
        }

        public IActionResult Search_for_I_blocked(string searchText2, string searchText3)
        {
            var car = _dbContext.Car.FirstOrDefault(car => car.LicencePlate == searchText2);
            if (car != null)
            {
                car.BlockedByLicencePlate = searchText3;
                return View(car);
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Search_for_I_unblocked(string searchText2, string searchText3)
        {
            
            var car = _dbContext.Car.FirstOrDefault(car => car.LicencePlate == searchText2);
            var car2 = _dbContext.Car.FirstOrDefault(car => car.LicencePlate == searchText3);
            if (car != null && car.BlockedByLicencePlate==searchText3)
            {
                car.BlockedByLicencePlate = null;
                car2.BlockedLicencePlate = null;
                return View(car);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
