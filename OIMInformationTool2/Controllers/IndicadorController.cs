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
    public class IndicadorController : Controller
    {
        private readonly OimContext _context;

        public IndicadorController(OimContext context)
        {
            _context = context;
        }

        // GET: Indicador
        public async Task<IActionResult> Index()
        {
            var oim2Context = _context.Indicadors.Include(i => i.Fondo).Include(i => i.Implementador).Include(i => i.Output).Include(i => i.Periodicidad);
            return View(await oim2Context.ToListAsync());
        }

        // GET: Indicador/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Indicadors == null)
            {
                return NotFound();
            }

            var indicador = await _context.Indicadors
                .Include(i => i.Fondo)
                .Include(i => i.Implementador)
                .Include(i => i.Output)
                .Include(i => i.Periodicidad)
                .FirstOrDefaultAsync(m => m.IdIndicador == id);
            if (indicador == null)
            {
                return NotFound();
            }

            return View(indicador);
        }

        // GET: Indicador/Create
        public IActionResult Create()
        {
            ViewData["FondoId"] = new SelectList(_context.Fondos, "IdFondo", "Descripcion");
            ViewData["ImplementadorId"] = new SelectList(_context.Implementadors, "IdImplementador", "Descripcion");
            ViewData["OutputId"] = new SelectList(_context.Outputs, "IdOutput", "Descripcion");
            ViewData["PeriodicidadId"] = new SelectList(_context.Periodicidads, "IdPeriodo", "Descripcion");
            return View();
        }

        // POST: Indicador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIndicador,Descripcion,FondoId,Meta,OutputId,NumeroTotal,CampoReferencia,FormulaCalculo,ImplementadorId,PeriodicidadId")] Indicador indicador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indicador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FondoId"] = new SelectList(_context.Fondos, "IdFondo", "Descripcion", indicador.FondoId);
            ViewData["ImplementadorId"] = new SelectList(_context.Implementadors, "IdImplementador", "Descripcion", indicador.ImplementadorId);
            ViewData["OutputId"] = new SelectList(_context.Outputs, "IdOutput", "descripcion", indicador.OutputId);
            ViewData["PeriodicidadId"] = new SelectList(_context.Periodicidads, "IdPeriodo", "Descripcion", indicador.PeriodicidadId);
            return View(indicador);
        }

        // GET: Indicador/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Indicadors == null)
            {
                return NotFound();
            }

            var indicador = await _context.Indicadors.FindAsync(id);
            if (indicador == null)
            {
                return NotFound();
            }
            ViewData["FondoId"] = new SelectList(_context.Fondos, "IdFondo", "Descripcion", indicador.FondoId);
            ViewData["ImplementadorId"] = new SelectList(_context.Implementadors, "IdImplementador", "Descripcion", indicador.ImplementadorId);
            ViewData["OutputId"] = new SelectList(_context.Outputs, "IdOutput", "descripcion", indicador.OutputId);
            ViewData["PeriodicidadId"] = new SelectList(_context.Periodicidads, "IdPeriodo", "Descripcion", indicador.PeriodicidadId);
            return View(indicador);
        }

        // POST: Indicador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdIndicador,Descripcion,FondoId,Meta,OutputId,NumeroTotal,CampoReferencia,FormulaCalculo,ImplementadorId,PeriodicidadId")] Indicador indicador)
        {
            if (id != indicador.IdIndicador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indicador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndicadorExists(indicador.IdIndicador))
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
            ViewData["FondoId"] = new SelectList(_context.Fondos, "IdFondo", "IdFondo", indicador.FondoId);
            ViewData["ImplementadorId"] = new SelectList(_context.Implementadors, "IdImplementador", "IdImplementador", indicador.ImplementadorId);
            ViewData["OutputId"] = new SelectList(_context.Outputs, "IdOutput", "IdOutput", indicador.OutputId);
            ViewData["PeriodicidadId"] = new SelectList(_context.Periodicidads, "IdPeriodo", "IdPeriodo", indicador.PeriodicidadId);
            return View(indicador);
        }

        // GET: Indicador/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Indicadors == null)
            {
                return NotFound();
            }

            var indicador = await _context.Indicadors
                .Include(i => i.Fondo)
                .Include(i => i.Implementador)
                .Include(i => i.Output)
                .Include(i => i.Periodicidad)
                .FirstOrDefaultAsync(m => m.IdIndicador == id);
            if (indicador == null)
            {
                return NotFound();
            }

            return View(indicador);
        }

        // POST: Indicador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Indicadors == null)
            {
                return Problem("Entity set 'Oim2Context.Indicadors'  is null.");
            }
            var indicador = await _context.Indicadors.FindAsync(id);
            if (indicador != null)
            {
                _context.Indicadors.Remove(indicador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndicadorExists(string id)
        {
            return _context.Indicadors.Any(e => e.IdIndicador == id);
        }
    }
}
