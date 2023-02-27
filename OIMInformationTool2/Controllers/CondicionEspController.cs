using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OIMInformationTool2.Models;

namespace OIMInformationTool2.Controllers
{
    public class CondicionEspController : Controller
    {
        private readonly OimContext _context;

        public CondicionEspController(OimContext context)
        {
            _context = context;
        }

        // GET: CondicionEsp
        public async Task<IActionResult> Index()
        {
              return View(await _context.CondicionEsps.ToListAsync());
        }

        // GET: CondicionEsp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CondicionEsps == null)
            {
                return NotFound();
            }

            var condicionEsp = await _context.CondicionEsps
                .FirstOrDefaultAsync(m => m.IdCondicionEsp == id);
            if (condicionEsp == null)
            {
                return NotFound();
            }

            return View(condicionEsp);
        }

        // GET: CondicionEsp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CondicionEsp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCondicionEsp,Descripcion")] CondicionEsp condicionEsp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condicionEsp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condicionEsp);
        }

        // GET: CondicionEsp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CondicionEsps == null)
            {
                return NotFound();
            }

            var condicionEsp = await _context.CondicionEsps.FindAsync(id);
            if (condicionEsp == null)
            {
                return NotFound();
            }
            return View(condicionEsp);
        }

        // POST: CondicionEsp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCondicionEsp,Descripcion")] CondicionEsp condicionEsp)
        {
            if (id != condicionEsp.IdCondicionEsp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condicionEsp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondicionEspExists(condicionEsp.IdCondicionEsp))
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
            return View(condicionEsp);
        }

        // GET: CondicionEsp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CondicionEsps == null)
            {
                return NotFound();
            }

            var condicionEsp = await _context.CondicionEsps
                .FirstOrDefaultAsync(m => m.IdCondicionEsp == id);
            if (condicionEsp == null)
            {
                return NotFound();
            }

            return View(condicionEsp);
        }

        // POST: CondicionEsp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CondicionEsps == null)
            {
                return Problem("Entity set 'OimContext.CondicionEsps'  is null.");
            }
            var condicionEsp = await _context.CondicionEsps.FindAsync(id);
            if (condicionEsp != null)
            {
                _context.CondicionEsps.Remove(condicionEsp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondicionEspExists(int id)
        {
          return _context.CondicionEsps.Any(e => e.IdCondicionEsp == id);
        }
    }
}
