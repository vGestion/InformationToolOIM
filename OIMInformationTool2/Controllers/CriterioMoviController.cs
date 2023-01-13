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
    public class CriterioMoviController : Controller
    {
        private readonly OimContext _context;

        public CriterioMoviController(OimContext context)
        {
            _context = context;
        }

        // GET: CriterioMovi
        public async Task<IActionResult> Index()
        {
              return View(await _context.CriterioMovis.ToListAsync());
        }

        // GET: CriterioMovi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CriterioMovis == null)
            {
                return NotFound();
            }

            var criterioMovi = await _context.CriterioMovis
                .FirstOrDefaultAsync(m => m.IdCriterioMovi == id);
            if (criterioMovi == null)
            {
                return NotFound();
            }

            return View(criterioMovi);
        }

        // GET: CriterioMovi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CriterioMovi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCriterioMovi,Descripcion")] CriterioMovi criterioMovi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(criterioMovi);
                TempData["alertMessage"] = "Creado con éxito";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(criterioMovi);
        }

        // GET: CriterioMovi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CriterioMovis == null)
            {
                return NotFound();
            }

            var criterioMovi = await _context.CriterioMovis.FindAsync(id);
            if (criterioMovi == null)
            {
                return NotFound();
            }
            return View(criterioMovi);
        }

        // POST: CriterioMovi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCriterioMovi,Descripcion")] CriterioMovi criterioMovi)
        {
            if (id != criterioMovi.IdCriterioMovi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(criterioMovi);
                    TempData["alertMessage"] = "Editado con éxito";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CriterioMoviExists(criterioMovi.IdCriterioMovi))
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
            return View(criterioMovi);
        }

        // GET: CriterioMovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CriterioMovis == null)
            {
                return NotFound();
            }

            var criterioMovi = await _context.CriterioMovis
                .FirstOrDefaultAsync(m => m.IdCriterioMovi == id);
            if (criterioMovi == null)
            {
                return NotFound();
            }

            return View(criterioMovi);
        }

        // POST: CriterioMovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CriterioMovis == null)
            {
                return Problem("Entity set 'OimContext.CriterioMovis'  is null.");
            }
            var criterioMovi = await _context.CriterioMovis.FindAsync(id);
            if (criterioMovi != null)
            {
                _context.CriterioMovis.Remove(criterioMovi);
                TempData["alertMessage"] = "Eliminado con éxito";
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CriterioMoviExists(int id)
        {
          return _context.CriterioMovis.Any(e => e.IdCriterioMovi == id);
        }
    }
}
