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
    public class ProvinciaController : Controller
    {
        private readonly OimContext _context;

        public ProvinciaController(OimContext context)
        {
            _context = context;
        }

        // GET: Provincia
        public async Task<IActionResult> Index()
        {
              return View(await _context.Provincia.ToListAsync());
        }

        // GET: Provincia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Provincia == null)
            {
                return NotFound();
            }

            var provincium = await _context.Provincia
                .FirstOrDefaultAsync(m => m.IdProvincia == id);
            if (provincium == null)
            {
                return NotFound();
            }

            return View(provincium);
        }

        // GET: Provincia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provincia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProvincia,Descripcion")] Provincium provincium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provincium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provincium);
        }

        // GET: Provincia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Provincia == null)
            {
                return NotFound();
            }

            var provincium = await _context.Provincia.FindAsync(id);
            if (provincium == null)
            {
                return NotFound();
            }
            return View(provincium);
        }

        // POST: Provincia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProvincia,Descripcion")] Provincium provincium)
        {
            if (id != provincium.IdProvincia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provincium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinciumExists(provincium.IdProvincia))
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
            return View(provincium);
        }

        // GET: Provincia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Provincia == null)
            {
                return NotFound();
            }

            var provincium = await _context.Provincia
                .FirstOrDefaultAsync(m => m.IdProvincia == id);
            if (provincium == null)
            {
                return NotFound();
            }

            return View(provincium);
        }

        // POST: Provincia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Provincia == null)
            {
                return Problem("Entity set 'OimContext.Provincia'  is null.");
            }
            var provincium = await _context.Provincia.FindAsync(id);
            if (provincium != null)
            {
                _context.Provincia.Remove(provincium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinciumExists(int id)
        {
          return _context.Provincia.Any(e => e.IdProvincia == id);
        }
    }
}
