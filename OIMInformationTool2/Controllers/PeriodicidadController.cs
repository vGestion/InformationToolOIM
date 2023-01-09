using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OIMInformationTool2.Models;

namespace OIMInformationTool2.Controllers
{
    public class PeriodicidadController : Controller
    {
        private readonly OimContext _context;

        public PeriodicidadController(OimContext context)
        {
            _context = context;
        }

        // GET: Periodicidad
        public async Task<IActionResult> Index()
        {
              return View(await _context.Periodicidads.ToListAsync());
        }

        // GET: Periodicidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Periodicidads == null)
            {
                return NotFound();
            }

            var periodicidad = await _context.Periodicidads
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (periodicidad == null)
            {
                return NotFound();
            }

            return View(periodicidad);
        }

        // GET: Periodicidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Periodicidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriodo,Descripcion")] Periodicidad periodicidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodicidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periodicidad);
        }

        // GET: Periodicidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Periodicidads == null)
            {
                return NotFound();
            }

            var periodicidad = await _context.Periodicidads.FindAsync(id);
            if (periodicidad == null)
            {
                return NotFound();
            }
            return View(periodicidad);
        }

        // POST: Periodicidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriodo,Descripcion")] Periodicidad periodicidad)
        {
            if (id != periodicidad.IdPeriodo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodicidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodicidadExists(periodicidad.IdPeriodo))
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
            return View(periodicidad);
        }

        // GET: Periodicidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Periodicidads == null)
            {
                return NotFound();
            }

            var periodicidad = await _context.Periodicidads
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (periodicidad == null)
            {
                return NotFound();
            }

            return View(periodicidad);
        }

        // POST: Periodicidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Periodicidads == null)
            {
                return Problem("Entity set 'OimContext.Periodicidads'  is null.");
            }
            var periodicidad = await _context.Periodicidads.FindAsync(id);
            if (periodicidad != null)
            {
                _context.Periodicidads.Remove(periodicidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodicidadExists(int id)
        {
          return _context.Periodicidads.Any(e => e.IdPeriodo == id);
        }
    }
}
