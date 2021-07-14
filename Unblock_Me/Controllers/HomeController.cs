using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Unblock_Me.Models;
using Microsoft.AspNetCore.Http;

namespace Unblock_Me.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Models.Unblock_MeContext _dbContext;
        public HomeController(ILogger<HomeController> logger, Models.Unblock_MeContext dbContext)
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
        /*
        [Produces("application/json")]
        [HttpGet("Search2")]
        public async Task<IActionResult> Search2()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var postTitle = _dbContext.Car.Where(p => p.LicencePlate.Contains(term)).Select(p => p.LicencePlate).ToList();
                return Ok(postTitle);
            }
            catch
            {
                return BadRequest();
            }
        }
        */
        public IActionResult DontExist()
        {
            return View();
        }

        public IActionResult Search(string searchText) {
            var car = _dbContext.Car.FirstOrDefault(car => car.LicencePlate == searchText);
            if(car!=null)
                return View(car);
            else
            {
                return DontExist();
            }
        }


        public async Task<IActionResult> User(string Id)
        {
            var user = await _dbContext.Users.FindAsync(Id);
            return View(user);
        }
       
    }
}
