using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OIMInformationTool2.Models;

namespace OIMInformationTool2.Controllers
{
    public class IdentSexualController : Controller
    {
        private readonly OimContext _context;

        public IdentSexualController(OimContext context)
        {
            _context = context;
        }

        // GET: IdentSexual
        public async Task<IActionResult> Index()
        {
              return View(await _context.IdentSexuals.ToListAsync());
        }

        // GET: IdentSexual/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IdentSexuals == null)
            {
                return NotFound();
            }

            var identSexual = await _context.IdentSexuals
                .FirstOrDefaultAsync(m => m.IdIdentSexual == id);
            if (identSexual == null)
            {
                return NotFound();
            }

            return View(identSexual);
        }

        // GET: IdentSexual/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IdentSexual/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIdentSexual,Descripcion")] IdentSexual identSexual)
        {
            if (ModelState.IsValid)
            {
                _context.Add(identSexual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(identSexual);
        }

        // GET: IdentSexual/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IdentSexuals == null)
            {
                return NotFound();
            }

            var identSexual = await _context.IdentSexuals.FindAsync(id);
            if (identSexual == null)
            {
                return NotFound();
            }
            return View(identSexual);
        }

        // POST: IdentSexual/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIdentSexual,Descripcion")] IdentSexual identSexual)
        {
            if (id != identSexual.IdIdentSexual)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(identSexual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentSexualExists(identSexual.IdIdentSexual))
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
            return View(identSexual);
        }

        // GET: IdentSexual/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IdentSexuals == null)
            {
                return NotFound();
            }

            var identSexual = await _context.IdentSexuals
                .FirstOrDefaultAsync(m => m.IdIdentSexual == id);
            if (identSexual == null)
            {
                return NotFound();
            }

            return View(identSexual);
        }

        // POST: IdentSexual/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IdentSexuals == null)
            {
                return Problem("Entity set 'OimContext.IdentSexuals'  is null.");
            }
            var identSexual = await _context.IdentSexuals.FindAsync(id);
            if (identSexual != null)
            {
                _context.IdentSexuals.Remove(identSexual);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentSexualExists(int id)
        {
          return _context.IdentSexuals.Any(e => e.IdIdentSexual == id);
        }
    }
}
