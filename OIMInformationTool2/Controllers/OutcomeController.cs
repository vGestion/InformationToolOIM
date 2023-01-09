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
              return View(await _context.Outcomes.ToListAsync());
        }

        // GET: Outcome/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Outcomes == null)
            {
                return NotFound();
            }

            var outcome = await _context.Outcomes
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
            return View();
        }

        // POST: Outcome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOutcome,Descripcion")] Outcome outcome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outcome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(outcome);
        }

        // POST: Outcome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdOutcome,Descripcion")] Outcome outcome)
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
                return Problem("Entity set 'OimContext.Outcomes'  is null.");
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
