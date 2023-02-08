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
    public class TipoUaController : Controller
    {
        private readonly OimContext _context;

        public TipoUaController(OimContext context)
        {
            _context = context;
        }

        // GET: TipoUa
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoUas.ToListAsync());
        }

        // GET: TipoUa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoUas == null)
            {
                return NotFound();
            }

            var tipoUa = await _context.TipoUas
                .FirstOrDefaultAsync(m => m.IdTipoUa == id);
            if (tipoUa == null)
            {
                return NotFound();
            }

            return View(tipoUa);
        }

        // GET: TipoUa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoUa,Descripcion")] TipoUa tipoUa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoUa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUa);
        }

        // GET: TipoUa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoUas == null)
            {
                return NotFound();
            }

            var tipoUa = await _context.TipoUas.FindAsync(id);
            if (tipoUa == null)
            {
                return NotFound();
            }
            return View(tipoUa);
        }

        // POST: TipoUa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoUa,Descripcion")] TipoUa tipoUa)
        {
            if (id != tipoUa.IdTipoUa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoUa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoUaExists(tipoUa.IdTipoUa))
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
            return View(tipoUa);
        }

        // GET: TipoUa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoUas == null)
            {
                return NotFound();
            }

            var tipoUa = await _context.TipoUas
                .FirstOrDefaultAsync(m => m.IdTipoUa == id);
            if (tipoUa == null)
            {
                return NotFound();
            }

            return View(tipoUa);
        }

        // POST: TipoUa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoUas == null)
            {
                return Problem("Entity set 'OimContext.TipoUas'  is null.");
            }
            var tipoUa = await _context.TipoUas.FindAsync(id);
            if (tipoUa != null)
            {
                _context.TipoUas.Remove(tipoUa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoUaExists(int id)
        {
          return _context.TipoUas.Any(e => e.IdTipoUa == id);
        }
    }
}
