using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OIMInformationTool2.Models;
using OIMInformationTool2.Utils;

namespace OIMInformationTool2.Controllers
{
    public class FondoController : Controller
    {
        private readonly OimContext _context;

        public FondoController(OimContext context)
        {
            _context = context;
        }

        // GET: Fondo
        public async Task<IActionResult> Index()
        {
            var oim2Context = _context.Fondos.Include(f => f.Donante);
            return View(await oim2Context.ToListAsync());
        }

        // GET: Fondo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Fondos == null)
            {
                return NotFound();
            }

            var fondo = await _context.Fondos
                .Include(f => f.Donante)
                .FirstOrDefaultAsync(m => m.IdFondo == id);
            if (fondo == null)
            {
                return NotFound();
            }

            return View(fondo);
        }

        // GET: Fondo/Create
        public IActionResult Create()
        {
            ViewData["DonanteId"] = new SelectList(_context.Donantes, "IdDonante", "IdDonante");
            return View();
        }

        // POST: Fondo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFondo,Descripcion,FechaInicio,DonanteId,FechaFin")] Fondo fondo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fondo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonanteId"] = new SelectList(_context.Donantes, "IdDonante", "IdDonante", fondo.DonanteId);
            return View(fondo);
        }

        // GET: Fondo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Fondos == null)
            {
                return NotFound();
            }

            var fondo = await _context.Fondos.FindAsync(id);
            if (fondo == null)
            {
                return NotFound();
            }
            ViewData["DonanteId"] = new SelectList(_context.Donantes, "IdDonante", "IdDonante", fondo.DonanteId);
            return View(fondo);
        }

        // POST: Fondo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdFondo,Descripcion,FechaInicio,DonanteId,FechaFin")] Fondo fondo)
        {
            if (id != fondo.IdFondo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fondo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FondoExists(fondo.IdFondo))
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
            ViewData["DonanteId"] = new SelectList(_context.Donantes, "IdDonante", "IdDonante", fondo.DonanteId);
            return View(fondo);
        }

        // GET: Fondo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Fondos == null)
            {
                return NotFound();
            }

            var fondo = await _context.Fondos
                .Include(f => f.Donante)
                .FirstOrDefaultAsync(m => m.IdFondo == id);
            if (fondo == null)
            {
                return NotFound();
            }

            return View(fondo);
        }

        // POST: Fondo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Fondos == null)
            {
                return Problem("Entity set 'Oim2Context.Fondos'  is null.");
            }
            var fondo = await _context.Fondos.FindAsync(id);
            if (fondo != null)
            {
                _context.Fondos.Remove(fondo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FondoExists(string id)
        {
            return _context.Fondos.Any(e => e.IdFondo == id);
        }

        // ************************************************************************************
        // ******************************CREATED FUNCTIONS************************************* 
        // ************************************************************************************ 

        public IActionResult saveToExcel()
        {
            ExcelManager manager = new ExcelManager();
            DownloadManager download = new DownloadManager();


            var listado = _context.Fondos.ToList();

            String fileName = "Files/Fondos.xlsx";

            manager.saveExcelFile(listado, fileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);


        }
    }
}
