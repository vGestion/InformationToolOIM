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
    public class OutcomeController : Controller
    {
        private readonly OimContext _context;

        public OutcomeController(OimContext context)
        {
            _context = context;
        }

        // GET: Outcome
        public async Task<IActionResult> Index()
        {
            var oim2Context = _context.Outcomes.Include(o => o.AreaOim).Include(o => o.Objetivo).Include(o => o.Sector);
            return View(await oim2Context.ToListAsync());
        }

        // GET: Outcome/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Outcomes == null)
            {
                return NotFound();
            }

            var outcome = await _context.Outcomes
                .Include(o => o.AreaOim)
                .Include(o => o.Objetivo)
                .Include(o => o.Sector)
                .FirstOrDefaultAsync(m => m.IdOutcome == id);
            if (outcome == null)
            {
                return NotFound();
            }

            return View(outcome);
        }

        // GET: Outcome/Create
        public IActionResult Create()
        {
            ViewData["AreaOimId"] = new SelectList(_context.AreaOims, "IdAreaOim", "Descripcion");
            ViewData["ObjetivoId"] = new SelectList(_context.Objetivos, "IdObjetivo", "Descripcion");
            ViewData["SectorId"] = new SelectList(_context.Sectors, "IdSector", "Descripcion");
            return View();
        }

        // POST: Outcome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOutcome,AreaOimId,SectorId,ObjetivoId,Descripcion")] Outcome outcome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outcome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaOimId"] = new SelectList(_context.AreaOims, "IdAreaOim", "Descripcion", outcome.AreaOimId);
            ViewData["ObjetivoId"] = new SelectList(_context.Objetivos, "IdObjetivo", "Descripcion", outcome.ObjetivoId);
            ViewData["SectorId"] = new SelectList(_context.Sectors, "IdSector", "Descripcion", outcome.SectorId);
            return View(outcome);
        }

        // GET: Outcome/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Outcomes == null)
            {
                return NotFound();
            }

            var outcome = await _context.Outcomes.FindAsync(id);
            if (outcome == null)
            {
                return NotFound();
            }
            ViewData["AreaOimId"] = new SelectList(_context.AreaOims, "IdAreaOim", "Descripcion", outcome.AreaOimId);
            ViewData["ObjetivoId"] = new SelectList(_context.Objetivos, "IdObjetivo", "Descripcion", outcome.ObjetivoId);
            ViewData["SectorId"] = new SelectList(_context.Sectors, "IdSector", "Descripcion", outcome.SectorId);
            return View(outcome);
        }

        // POST: Outcome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdOutcome,AreaOimId,SectorId,ObjetivoId,Descripcion")] Outcome outcome)
        {
            if (id != outcome.IdOutcome)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(outcome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutcomeExists(outcome.IdOutcome))
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
            ViewData["AreaOimId"] = new SelectList(_context.AreaOims, "IdAreaOim", "Descripcion", outcome.AreaOimId);
            ViewData["ObjetivoId"] = new SelectList(_context.Objetivos, "IdObjetivo", "Descripcion", outcome.ObjetivoId);
            ViewData["SectorId"] = new SelectList(_context.Sectors, "IdSector", "Descripcion", outcome.SectorId);
            return View(outcome);
        }

        // GET: Outcome/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Outcomes == null)
            {
                return NotFound();
            }

            var outcome = await _context.Outcomes
                .Include(o => o.AreaOim)
                .Include(o => o.Objetivo)
                .Include(o => o.Sector)
                .FirstOrDefaultAsync(m => m.IdOutcome == id);
            if (outcome == null)
            {
                return NotFound();
            }

            return View(outcome);
        }

        // POST: Outcome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Outcomes == null)
            {
                return Problem("Entity set 'Oim2Context.Outcomes'  is null.");
            }
            var outcome = await _context.Outcomes.FindAsync(id);
            if (outcome != null)
            {
                _context.Outcomes.Remove(outcome);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OutcomeExists(string id)
        {
            return _context.Outcomes.Any(e => e.IdOutcome == id);
        }
    }
}
