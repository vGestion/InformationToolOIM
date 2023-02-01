using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using OIMInformationTool2.Models;
using OIMInformationTool2.Utils;

namespace OIMInformationTool2.Controllers
{
    public class CantonController : Controller
    {
        private readonly OimContext _context;

        public CantonController(OimContext context)
        {
            _context = context;
        }

        // GET: Canton
        public async Task<IActionResult> Index()
        {
            var oimContext = _context.Cantons.Include(c => c.Provincia);
            return View(await oimContext.ToListAsync());
        }

        // GET: Canton/Details/5
        [Route("Canton/Details/{idP}/{idC}")]
        public async Task<IActionResult> Details(int? idP, int? idC)
        {
            if (idC == null || _context.Cantons == null)
            {
                return NotFound();
            }

            var canton = await _context.Cantons.FindAsync(idC, idP);
            if (canton == null)
            {
                return NotFound();
            }

            return View(canton);
        }

        // GET: Canton/Create
        public IActionResult Create()
        {
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "IdProvincia", "Descripcion");
            return View();
        }

        // POST: Canton/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCanton,Descripcion,ProvinciaId,Latitud,Longitud")] Canton canton)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canton);
                TempData["alertMessage"] = "Creado con éxito";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "IdProvincia", "IdProvincia", canton.ProvinciaId);
            return View(canton);
        }

        // GET: Canton/Edit/5

        [Route("Canton/Edit/{idP}/{idC}")]
        public async Task<IActionResult> Edit(int? idC, int? idP)
        {
            if (idC == null || _context.Cantons == null)
            {
                return NotFound();
            }

            var canton = await _context.Cantons.FindAsync(idC,idP);
            if (canton == null)
            {
                return NotFound();
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "IdProvincia", "IdProvincia", canton.ProvinciaId);
            return View(canton);
        }

        // POST: Canton/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCanton,Descripcion,ProvinciaId,Latitud,Longitud")] Canton canton)
        {
            if (id != canton.IdCanton)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canton);
                    TempData["alertMessage"] = "Editado con éxito";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CantonExists(canton.IdCanton))
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
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "IdProvincia", "IdProvincia", canton.ProvinciaId);
            return View(canton);
        }

        // GET: Canton/Delete/5
        [Route("Canton/Delete/{idP}/{idC}")]
        public async Task<IActionResult> Delete(int? idC, int? idP)
        {
            if (idC == null || _context.Cantons == null)
            {
                return NotFound();
            }

            var canton = await _context.Cantons.FindAsync(idC, idP);

            if (canton == null)
            {
                return NotFound();
            }

            return View(canton);
        }

        // POST: Canton/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int idC, int idP)
        {
            if (_context.Cantons == null)
            {
                return Problem("Entity set 'OimContext.Cantons'  is null.");
            }
            var canton = await _context.Cantons.FindAsync(idC, idP);
            if (canton != null)
            {
                _context.Cantons.Remove(canton);
                TempData["alertMessage"] = "Eliminado con éxito";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CantonExists(int id)
        {
            return _context.Cantons.Any(e => e.IdCanton == id);
        }

        // **************************************************************************************
        // ****************************** CREATED FUNCTIONS ************************************* 
        // **************************************************************************************



        public IActionResult saveToExcel()
        {
            ExcelManager manager = new ExcelManager();
            DownloadManager download = new DownloadManager();

            var listado = _context.Cantons.Include(c => c.Provincia).ToList();

            String fileName = "Files/Cantones.xlsx";

            manager.saveExcelFile(listado, fileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

        }

        [HttpGet]
        public JsonResult Search(string searchTerm)
        {
            var result = _context.Cantons.Where(x => x.Descripcion.Contains(searchTerm) || x.IdCanton.ToString().Contains(searchTerm)).ToList();
            return Json(result);
        }



    }
}
