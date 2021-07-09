using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Unblock_Me.Models;

namespace Unblock_Me.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly Unblock_MeContext _context;
        
        public CarsController(Unblock_MeContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var unblock_MeContext = _context.Car.Include(c => c.Owner);
            return View(await unblock_MeContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Owner)
                .FirstOrDefaultAsync(m => m.LicencePlate == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LicencePlate,Maker,Model,Colour,BlockedLicencePlate,BlockedByLicencePlate,OwnerId")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "Id", car.OwnerId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "Id", car.OwnerId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LicencePlate,Maker,Model,Colour,BlockedLicencePlate,BlockedByLicencePlate,OwnerId")] Car car)
        {
            if (id != car.LicencePlate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.LicencePlate))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "Id", car.OwnerId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Owner)
                .FirstOrDefaultAsync(m => m.LicencePlate == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(string id)
        {
            return _context.Car.Any(e => e.LicencePlate == id);
        }

        public IActionResult I_blocked()
        {
            return View();
        }

        public IActionResult I_unblocked()
        {
            return View();
        }

        public async Task<IActionResult> Search_for_I_blocked(string searchText2, string searchText3)
        {
            var car = _context.Car.FirstOrDefault(car => car.LicencePlate == searchText2);
            var car2 = _context.Car.FirstOrDefault(car => car.LicencePlate == searchText3);
            if (car != null)
            {
                car.BlockedByLicencePlate = searchText3;
                car2.BlockedLicencePlate = searchText2;
                await _context.SaveChangesAsync();
                return View(car);
            }
            else
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> Search_for_I_unblocked(string searchText2, string searchText3)
        {

            var car = _context.Car.FirstOrDefault(car => car.LicencePlate == searchText2);
            var car2 = _context.Car.FirstOrDefault(car => car.LicencePlate == searchText3);
            if (car != null && car.BlockedByLicencePlate == searchText3)
            {
                car.BlockedByLicencePlate = null;
                car2.BlockedLicencePlate = null;
                await _context.SaveChangesAsync();
                return View(car);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
