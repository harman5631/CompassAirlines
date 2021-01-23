using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompassAirlines.Data;
using CompassAirlines.Models;
using Microsoft.AspNetCore.Authorization;

namespace CompassAirlines.Controllers
{
    
    public class FlightsController : Controller
    {
        private readonly CAirContext _context;

        public FlightsController(CAirContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var cAirContext = _context.Flights.Include(f => f.Planes).Include(f => f.Staff);
            return View(await cAirContext.ToListAsync());
        }
        [Authorize]
        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flights = await _context.Flights
                .Include(f => f.Planes)
                .Include(f => f.Staff)
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flights == null)
            {
                return NotFound();
            }

            return View(flights);
        }
        [Authorize]
        // GET: Flights/Create
        public IActionResult Create()
        {
            ViewData["PlaneID"] = new SelectList(_context.Planes, "PlaneID", "PlaneNum");
            ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightID,StaffID,PlaneID,Passengers,Weight,DepartDate,DepartTime,ArrivalDate,ArrivalTime,FlightStatus")] Flights flights)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flights);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaneID"] = new SelectList(_context.Planes, "PlaneID", "PlaneNum", flights.PlaneID);
            ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName", flights.StaffID);
            return View(flights);
        }
        [Authorize]
        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flights = await _context.Flights.FindAsync(id);
            if (flights == null)
            {
                return NotFound();
            }
            ViewData["PlaneID"] = new SelectList(_context.Planes, "PlaneID", "PlaneNum", flights.PlaneID);
            ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName", flights.StaffID);
            return View(flights);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightID,StaffID,PlaneID,Passengers,Weight,DepartDate,DepartTime,ArrivalDate,ArrivalTime,FlightStatus")] Flights flights)
        {
            if (id != flights.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flights);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightsExists(flights.FlightID))
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
            ViewData["PlaneID"] = new SelectList(_context.Planes, "PlaneID", "PlaneNum", flights.PlaneID);
            ViewData["StaffID"] = new SelectList(_context.Staff, "StaffID", "FullName", flights.StaffID);
            return View(flights);
        }
        [Authorize]
        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flights = await _context.Flights
                .Include(f => f.Planes)
                .Include(f => f.Staff)
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flights == null)
            {
                return NotFound();
            }

            return View(flights);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flights = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(flights);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightsExists(int id)
        {
            return _context.Flights.Any(e => e.FlightID == id);
        }
    }
}
