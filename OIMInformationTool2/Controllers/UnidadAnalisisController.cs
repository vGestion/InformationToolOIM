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
    public class UnidadAnalisisController : Controller
    {
        private readonly OimContext _context;

        public UnidadAnalisisController(OimContext context)
        {
            _context = context;
        }

        // GET: UnidadAnalisis
        public async Task<IActionResult> Index()
        {
            var oimContext = _context.UnidadAnalises.Include(u => u.TipoUa);
            return View(await oimContext.ToListAsync());
        }

        // GET: UnidadAnalisis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnidadAnalises == null)
            {
                return NotFound();
            }

            var unidadAnalisi = await _context.UnidadAnalises
                .Include(u => u.TipoUa)
                .FirstOrDefaultAsync(m => m.IdUa == id);
            if (unidadAnalisi == null)
            {
                return NotFound();
            }

            return View(unidadAnalisi);
        }

        // GET: UnidadAnalisis/Create
        public IActionResult Create()
        {
            ViewData["TipoUaId"] = new SelectList(_context.TipoUas, "IdTipoUa", "Descripcion");
            return View();
        }

        // POST: UnidadAnalisis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUa,Descripcion,TipoUaId")] UnidadAnalisi unidadAnalisi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadAnalisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoUaId"] = new SelectList(_context.TipoUas, "IdTipoUa", "Descripcion", unidadAnalisi.TipoUaId);
            return View(unidadAnalisi);
        }

        // GET: UnidadAnalisis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnidadAnalises == null)
            {
                return NotFound();
            }

            var unidadAnalisi = await _context.UnidadAnalises.FindAsync(id);
            if (unidadAnalisi == null)
            {
                return NotFound();
            }
            ViewData["TipoUaId"] = new SelectList(_context.TipoUas, "IdTipoUa", "Descripcion", unidadAnalisi.TipoUaId);
            return View(unidadAnalisi);
        }

        // POST: UnidadAnalisis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUa,Descripcion,TipoUaId")] UnidadAnalisi unidadAnalisi)
        {
            if (id != unidadAnalisi.IdUa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadAnalisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadAnalisiExists(unidadAnalisi.IdUa))
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
            ViewData["TipoUaId"] = new SelectList(_context.TipoUas, "IdTipoUa", "Descripcion", unidadAnalisi.TipoUaId);
            return View(unidadAnalisi);
        }

        // GET: UnidadAnalisis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnidadAnalises == null)
            {
                return NotFound();
            }

            var unidadAnalisi = await _context.UnidadAnalises
                .Include(u => u.TipoUa)
                .FirstOrDefaultAsync(m => m.IdUa == id);
            if (unidadAnalisi == null)
            {
                return NotFound();
            }

            return View(unidadAnalisi);
        }

        // POST: UnidadAnalisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnidadAnalises == null)
            {
                return Problem("Entity set 'OimContext.UnidadAnalises'  is null.");
            }
            var unidadAnalisi = await _context.UnidadAnalises.FindAsync(id);
            if (unidadAnalisi != null)
            {
                _context.UnidadAnalises.Remove(unidadAnalisi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadAnalisiExists(int id)
        {
          return _context.UnidadAnalises.Any(e => e.IdUa == id);
        }
    }
}
