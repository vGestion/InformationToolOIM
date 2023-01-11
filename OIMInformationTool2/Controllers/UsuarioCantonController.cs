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
    public class UsuarioCantonController : Controller
    {
        private readonly OimContext _context;

        public UsuarioCantonController(OimContext context)
        {
            _context = context;
        }

        // GET: UsuarioCanton
        public async Task<IActionResult> Index()
        {
            var oimContext = _context.UsuarioCantons.Include(u => u.Usuario);
            return View(await oimContext.ToListAsync());
        }

        // GET: UsuarioCanton/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UsuarioCantons == null)
            {
                return NotFound();
            }

            var usuarioCanton = await _context.UsuarioCantons
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.IdUsuarioCanto == id);
            if (usuarioCanton == null)
            {
                return NotFound();
            }

            return View(usuarioCanton);
        }

        // GET: UsuarioCanton/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombre");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "IdProvincia", "Descripcion");
            ViewData["CantonId"] = new SelectList(_context.Cantons, "IdCanton", "Descripcion");
            return View();
        }

        // POST: UsuarioCanton/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuarioCanto,UsuarioId,CantonId,ProvinciaId")] UsuarioCanton usuarioCanton)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioCanton);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombre", usuarioCanton.UsuarioId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "IdProvincia", "Descripcion");
            ViewData["CantonId"] = new SelectList(_context.Cantons, "IdCanton", "Descripcion");
            return View(usuarioCanton);
        }

        // GET: UsuarioCanton/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UsuarioCantons == null)
            {
                return NotFound();
            }

            var usuarioCanton = await _context.UsuarioCantons.FindAsync(id);
            if (usuarioCanton == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", usuarioCanton.UsuarioId);
            return View(usuarioCanton);
        }

        // POST: UsuarioCanton/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdUsuarioCanto,UsuarioId,CantonId,ProvinciaId")] UsuarioCanton usuarioCanton)
        {
            if (id != usuarioCanton.IdUsuarioCanto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioCanton);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioCantonExists(usuarioCanton.IdUsuarioCanto))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", usuarioCanton.UsuarioId);
            return View(usuarioCanton);
        }

        // GET: UsuarioCanton/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UsuarioCantons == null)
            {
                return NotFound();
            }

            var usuarioCanton = await _context.UsuarioCantons
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.IdUsuarioCanto == id);
            if (usuarioCanton == null)
            {
                return NotFound();
            }

            return View(usuarioCanton);
        }

        // POST: UsuarioCanton/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UsuarioCantons == null)
            {
                return Problem("Entity set 'OimContext.UsuarioCantons'  is null.");
            }
            var usuarioCanton = await _context.UsuarioCantons.FindAsync(id);
            if (usuarioCanton != null)
            {
                _context.UsuarioCantons.Remove(usuarioCanton);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioCantonExists(string id)
        {
          return _context.UsuarioCantons.Any(e => e.IdUsuarioCanto == id);
        }
    }
}
