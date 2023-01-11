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
    public class NacionalidadController : Controller
    {
        private readonly OimContext _context;

        public NacionalidadController(OimContext context)
        {
            _context = context;
        }

        // GET: Nacionalidad
        public async Task<IActionResult> Index()
        {
              return View(await _context.Nacionalidads.ToListAsync());
        }

        // GET: Nacionalidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nacionalidads == null)
            {
                return NotFound();
            }

            var nacionalidad = await _context.Nacionalidads
                .FirstOrDefaultAsync(m => m.IdNacionalidad == id);
            if (nacionalidad == null)
            {
                return NotFound();
            }

            return View(nacionalidad);
        }

        // GET: Nacionalidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nacionalidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNacionalidad,Descripcion")] Nacionalidad nacionalidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nacionalidad);
                TempData["alertMessage"] = "Creado con éxito";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nacionalidad);
        }

        // GET: Nacionalidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nacionalidads == null)
            {
                return NotFound();
            }

            var nacionalidad = await _context.Nacionalidads.FindAsync(id);
            if (nacionalidad == null)
            {
                return NotFound();
            }
            return View(nacionalidad);
        }

        // POST: Nacionalidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNacionalidad,Descripcion")] Nacionalidad nacionalidad)
        {
            if (id != nacionalidad.IdNacionalidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["alertMessage"] = "Editado con éxito";
                    _context.Update(nacionalidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NacionalidadExists(nacionalidad.IdNacionalidad))
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
            return View(nacionalidad);
        }

        // GET: Nacionalidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nacionalidads == null)
            {
                return NotFound();
            }

            var nacionalidad = await _context.Nacionalidads
                .FirstOrDefaultAsync(m => m.IdNacionalidad == id);
            if (nacionalidad == null)
            {
                return NotFound();
            }

            return View(nacionalidad);
        }

        // POST: Nacionalidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nacionalidads == null)
            {
                return Problem("Entity set 'OimContext.Nacionalidads'  is null.");
            }
            var nacionalidad = await _context.Nacionalidads.FindAsync(id);
            if (nacionalidad != null)
            {
                TempData["alertMessage"] = "Eliminado con éxito";
                _context.Nacionalidads.Remove(nacionalidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NacionalidadExists(int id)
        {
          return _context.Nacionalidads.Any(e => e.IdNacionalidad == id);
        }
    }
}
