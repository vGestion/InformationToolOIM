using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OIMInformationTool2.Models;

namespace OIMInformationTool2.Controllers
{
    public class PeriodoController : Controller
    {
        private readonly OimContext _context;

        public PeriodoController(OimContext context)
        {
            _context = context;
        }

        // GET: Periodo
        public async Task<IActionResult> Index()
        {
              return View(await _context.Periodos.ToListAsync());
        }

        // GET: Periodo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Periodos == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodos
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

        // GET: Periodo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Periodo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriodo,Descripcion,FechaInicio,FechaFin,Activo")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodo);
                TempData["alertMessage"] = "Creado con éxito";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periodo);
        }

        // GET: Periodo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Periodos == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodos.FindAsync(id);
            if (periodo == null)
            {
                return NotFound();
            }
            return View(periodo);
        }

        // POST: Periodo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriodo,Descripcion,FechaInicio,FechaFin,Activo")] Periodo periodo)
        {
            if (id != periodo.IdPeriodo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["alertMessage"] = "Editado con éxito";
                    _context.Update(periodo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodoExists(periodo.IdPeriodo))
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
            return View(periodo);
        }

        // GET: Periodo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Periodos == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodos
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

        // POST: Periodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Periodos == null)
            {
                return Problem("Entity set 'OimContext.Periodos'  is null.");
            }
            var periodo = await _context.Periodos.FindAsync(id);
            if (periodo != null)
            {
                _context.Periodos.Remove(periodo);
                TempData["alertMessage"] = "Eliminado con éxito";
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodoExists(int id)
        {
          return _context.Periodos.Any(e => e.IdPeriodo == id);
        }
    }
}
