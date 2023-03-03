using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OIMInformationTool2;
using OIMInformationTool2.Models;

namespace OIMInformationTool2.Controllers
{
    public class ActividadController : Controller
    {
        private readonly OimContext _context;

        public ActividadController(OimContext context)
        {
            _context = context;
        }

        // GET: Actividad
        public async Task<IActionResult> Index()
        {
            var oimContext = _context.Actividads.Include(a => a.AreaOim).Include(a => a.Fondo).Include(a => a.Implementador).Include(a => a.Indicador).Include(a => a.Periodicidad).Include(a => a.Sector).Include(a => a.Ua);
            return View(await oimContext.ToListAsync());
        }

        // GET: Actividad/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Actividads == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividads
                .Include(a => a.AreaOim)
                .Include(a => a.Fondo)
                .Include(a => a.Implementador)
                .Include(a => a.Indicador)
                .Include(a => a.Periodicidad)
                .Include(a => a.Sector)
                .Include(a => a.Ua)
                .FirstOrDefaultAsync(m => m.IdActividad == id);
            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }

        // GET: Actividad/Create
        public IActionResult Create()
        {
            ViewData["AreaOimId"] = new SelectList(_context.AreaOims, "IdAreaOim", "IdAreaOim");
            ViewData["FondoId"] = new SelectList(_context.Fondos, "IdFondo", "IdFondo");
            ViewData["ImplementadorId"] = new SelectList(_context.Implementadors, "IdImplementador", "IdImplementador");
            ViewData["IndicadorId"] = new SelectList(_context.Indicadors, "IdIndicador", "IdIndicador");
            ViewData["PeriodicidadId"] = new SelectList(_context.Periodicidads, "IdPeriodo", "IdPeriodo");
            ViewData["SectorId"] = new SelectList(_context.Sectors, "IdSector", "IdSector");
            ViewData["UaId"] = new SelectList(_context.UnidadAnalises, "IdUa", "IdUa");
            return View();
        }

        // POST: Actividad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdActividad,Descripcion,FondoId,Meta,IndicadorId,NumeroTotal,CampoReferencia,FormulaCalculo,ImplementadorId,UaId,SectorId,AreaOimId,PeriodicidadId")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaOimId"] = new SelectList(_context.AreaOims, "IdAreaOim", "IdAreaOim", actividad.AreaOimId);
            ViewData["FondoId"] = new SelectList(_context.Fondos, "IdFondo", "IdFondo", actividad.FondoId);
            ViewData["ImplementadorId"] = new SelectList(_context.Implementadors, "IdImplementador", "IdImplementador", actividad.ImplementadorId);
            ViewData["IndicadorId"] = new SelectList(_context.Indicadors, "IdIndicador", "IdIndicador", actividad.IndicadorId);
            ViewData["PeriodicidadId"] = new SelectList(_context.Periodicidads, "IdPeriodo", "IdPeriodo", actividad.PeriodicidadId);
            ViewData["SectorId"] = new SelectList(_context.Sectors, "IdSector", "IdSector", actividad.SectorId);
            ViewData["UaId"] = new SelectList(_context.UnidadAnalises, "IdUa", "IdUa", actividad.UaId);
            return View(actividad);
        }

        // GET: Actividad/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Actividads == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividads.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }
            ViewData["AreaOimId"] = new SelectList(_context.AreaOims, "IdAreaOim", "IdAreaOim", actividad.AreaOimId);
            ViewData["FondoId"] = new SelectList(_context.Fondos, "IdFondo", "IdFondo", actividad.FondoId);
            ViewData["ImplementadorId"] = new SelectList(_context.Implementadors, "IdImplementador", "IdImplementador", actividad.ImplementadorId);
            ViewData["IndicadorId"] = new SelectList(_context.Indicadors, "IdIndicador", "IdIndicador", actividad.IndicadorId);
            ViewData["PeriodicidadId"] = new SelectList(_context.Periodicidads, "IdPeriodo", "IdPeriodo", actividad.PeriodicidadId);
            ViewData["SectorId"] = new SelectList(_context.Sectors, "IdSector", "IdSector", actividad.SectorId);
            ViewData["UaId"] = new SelectList(_context.UnidadAnalises, "IdUa", "IdUa", actividad.UaId);
            return View(actividad);
        }

        // POST: Actividad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdActividad,Descripcion,FondoId,Meta,IndicadorId,NumeroTotal,CampoReferencia,FormulaCalculo,ImplementadorId,UaId,SectorId,AreaOimId,PeriodicidadId")] Actividad actividad)
        {
            if (id != actividad.IdActividad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadExists(actividad.IdActividad))
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
            ViewData["AreaOimId"] = new SelectList(_context.AreaOims, "IdAreaOim", "IdAreaOim", actividad.AreaOimId);
            ViewData["FondoId"] = new SelectList(_context.Fondos, "IdFondo", "IdFondo", actividad.FondoId);
            ViewData["ImplementadorId"] = new SelectList(_context.Implementadors, "IdImplementador", "IdImplementador", actividad.ImplementadorId);
            ViewData["IndicadorId"] = new SelectList(_context.Indicadors, "IdIndicador", "IdIndicador", actividad.IndicadorId);
            ViewData["PeriodicidadId"] = new SelectList(_context.Periodicidads, "IdPeriodo", "IdPeriodo", actividad.PeriodicidadId);
            ViewData["SectorId"] = new SelectList(_context.Sectors, "IdSector", "IdSector", actividad.SectorId);
            ViewData["UaId"] = new SelectList(_context.UnidadAnalises, "IdUa", "IdUa", actividad.UaId);
            return View(actividad);
        }

        // GET: Actividad/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Actividads == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividads
                .Include(a => a.AreaOim)
                .Include(a => a.Fondo)
                .Include(a => a.Implementador)
                .Include(a => a.Indicador)
                .Include(a => a.Periodicidad)
                .Include(a => a.Sector)
                .Include(a => a.Ua)
                .FirstOrDefaultAsync(m => m.IdActividad == id);
            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }

        // POST: Actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Actividads == null)
            {
                return Problem("Entity set 'OimContext.Actividads'  is null.");
            }
            var actividad = await _context.Actividads.FindAsync(id);
            if (actividad != null)
            {
                _context.Actividads.Remove(actividad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadExists(string id)
        {
          return _context.Actividads.Any(e => e.IdActividad == id);
        }
    }
}
