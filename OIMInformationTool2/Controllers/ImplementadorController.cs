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
    public class ImplementadorController : Controller
    {
        private readonly OimContext _context;

        public ImplementadorController(OimContext context)
        {
            _context = context;
        }

        // GET: Implementador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Implementadors.ToListAsync());
        }

        // GET: Implementador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Implementadors == null)
            {
                return NotFound();
            }

            var implementador = await _context.Implementadors
                .FirstOrDefaultAsync(m => m.IdImplementador == id);
            if (implementador == null)
            {
                return NotFound();
            }

            return View(implementador);
        }

        // GET: Implementador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Implementador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdImplementador,Descripcion")] Implementador implementador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(implementador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(implementador);
        }

        // GET: Implementador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Implementadors == null)
            {
                return NotFound();
            }

            var implementador = await _context.Implementadors.FindAsync(id);
            if (implementador == null)
            {
                return NotFound();
            }
            return View(implementador);
        }

        // POST: Implementador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdImplementador,Descripcion")] Implementador implementador)
        {
            if (id != implementador.IdImplementador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(implementador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImplementadorExists(implementador.IdImplementador))
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
            return View(implementador);
        }

        // GET: Implementador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Implementadors == null)
            {
                return NotFound();
            }

            var implementador = await _context.Implementadors
                .FirstOrDefaultAsync(m => m.IdImplementador == id);
            if (implementador == null)
            {
                return NotFound();
            }

            return View(implementador);
        }

        // POST: Implementador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Implementadors == null)
            {
                return Problem("Entity set 'Oim2Context.Implementadors'  is null.");
            }
            var implementador = await _context.Implementadors.FindAsync(id);
            if (implementador != null)
            {
                _context.Implementadors.Remove(implementador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImplementadorExists(int id)
        {
            return _context.Implementadors.Any(e => e.IdImplementador == id);
        }
    }
}
