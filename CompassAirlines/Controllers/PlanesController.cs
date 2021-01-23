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
    public class PlanesController : Controller
    {
        private readonly CAirContext _context;

        public PlanesController(CAirContext context)
        {
            _context = context;
        }

        // GET: Planes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planes.ToListAsync());
        }
        [Authorize]
        // GET: Planes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planes = await _context.Planes
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (planes == null)
            {
                return NotFound();
            }

            return View(planes);
        }
        [Authorize]
        // GET: Planes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaneID,Model,PlaneNum,Fit4Flight,MaxPassengers,MaxWeight")] Planes planes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planes);
        }
        [Authorize]
        // GET: Planes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planes = await _context.Planes.FindAsync(id);
            if (planes == null)
            {
                return NotFound();
            }
            return View(planes);
        }

        // POST: Planes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaneID,Model,PlaneNum,Fit4Flight,MaxPassengers,MaxWeight")] Planes planes)
        {
            if (id != planes.PlaneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanesExists(planes.PlaneID))
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
            return View(planes);
        }
        [Authorize]
        // GET: Planes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planes = await _context.Planes
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (planes == null)
            {
                return NotFound();
            }

            return View(planes);
        }

        // POST: Planes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planes = await _context.Planes.FindAsync(id);
            _context.Planes.Remove(planes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanesExists(int id)
        {
            return _context.Planes.Any(e => e.PlaneID == id);
        }
    }
}
