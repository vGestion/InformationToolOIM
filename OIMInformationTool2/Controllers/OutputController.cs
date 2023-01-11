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
    public class OutputController : Controller
    {
        private readonly OimContext _context;

        public OutputController(OimContext context)
        {
            _context = context;
        }

        // GET: Output
        public async Task<IActionResult> Index()
        {
            var oimContext = _context.Outputs.Include(o => o.Outcome);
            return View(await oimContext.ToListAsync());
        }

        // GET: Output/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Outputs == null)
            {
                return NotFound();
            }

            var output = await _context.Outputs
                .Include(o => o.Outcome)
                .FirstOrDefaultAsync(m => m.IdOutput == id);
            if (output == null)
            {
                return NotFound();
            }

            return View(output);
        }

        // GET: Output/Create
        public IActionResult Create()
        {
            ViewData["OutcomeId"] = new SelectList(_context.Outcomes, "IdOutcome", "IdOutcome");
            return View();
        }

        // POST: Output/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOutput,Descripcion,OutcomeId")] Output output)
        {
            if (ModelState.IsValid)
            {
                _context.Add(output);
                TempData["alertMessage"] = "Creado con éxito";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OutcomeId"] = new SelectList(_context.Outcomes, "IdOutcome", "IdOutcome", output.OutcomeId);
            return View(output);
        }

        // GET: Output/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Outputs == null)
            {
                return NotFound();
            }

            var output = await _context.Outputs.FindAsync(id);
            if (output == null)
            {
                return NotFound();
            }
            ViewData["OutcomeId"] = new SelectList(_context.Outcomes, "IdOutcome", "IdOutcome", output.OutcomeId);
            return View(output);
        }

        // POST: Output/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdOutput,Descripcion,OutcomeId")] Output output)
        {
            if (id != output.IdOutput)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(output);
                    TempData["alertMessage"] = "Editado con éxito";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutputExists(output.IdOutput))
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
            ViewData["OutcomeId"] = new SelectList(_context.Outcomes, "IdOutcome", "IdOutcome", output.OutcomeId);
            return View(output);
        }

        // GET: Output/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Outputs == null)
            {
                return NotFound();
            }

            var output = await _context.Outputs
                .Include(o => o.Outcome)
                .FirstOrDefaultAsync(m => m.IdOutput == id);
            if (output == null)
            {
                return NotFound();
            }

            return View(output);
        }

        // POST: Output/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Outputs == null)
            {
                return Problem("Entity set 'OimContext.Outputs'  is null.");
            }
            var output = await _context.Outputs.FindAsync(id);
            if (output != null)
            {
                _context.Outputs.Remove(output);
                TempData["alertMessage"] = "Eliminado con éxito";
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OutputExists(string id)
        {
          return _context.Outputs.Any(e => e.IdOutput == id);
        }
    }
}
