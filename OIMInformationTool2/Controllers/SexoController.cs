using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OIMInformationTool2.Models;
using OIMInformationTool2.Utils;

namespace OIMInformationTool2.Controllers
{
    public class SexoController : Controller
    {
        private readonly OimContext _context;

        public SexoController(OimContext context)
        {
            _context = context;
        }

        // GET: Sexo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sexos.ToListAsync());
        }

        // GET: Sexo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sexos == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexos
                .FirstOrDefaultAsync(m => m.IdSexo == id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        // GET: Sexo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sexo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSexo,Descripcion")] Sexo sexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sexo);
        }

        // GET: Sexo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sexos == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexos.FindAsync(id);
            if (sexo == null)
            {
                return NotFound();
            }
            return View(sexo);
        }

        // POST: Sexo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSexo,Descripcion")] Sexo sexo)
        {
            if (id != sexo.IdSexo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SexoExists(sexo.IdSexo))
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
            return View(sexo);
        }

        // GET: Sexo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sexos == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexos
                .FirstOrDefaultAsync(m => m.IdSexo == id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        // POST: Sexo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sexos == null)
            {
                return Problem("Entity set 'OimContext.Sexos'  is null.");
            }
            var sexo = await _context.Sexos.FindAsync(id);
            if (sexo != null)
            {
                _context.Sexos.Remove(sexo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SexoExists(int id)
        {
            return _context.Sexos.Any(e => e.IdSexo == id);
        }

        // ************************************************************************************
        // ******************************CREATED FUNCTIONS************************************* 
        // ************************************************************************************ 

        public IActionResult saveToExcel()
        {
            ExcelManager manager = new ExcelManager();
            DownloadManager download = new DownloadManager();


            var listado = _context.AreaOims.ToList();

            String fileName = "Files/sexos.xlsx";

            manager.saveExcelFile(listado, fileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
