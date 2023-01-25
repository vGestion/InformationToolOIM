using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InformationToolOIM2.Models;
using OIMInformationTool2.Models;
using OIMInformationTool2.Utils;
using ExcelDataReader.Log;
using Microsoft.AspNetCore.Routing.Constraints;

namespace OIMInformationTool2.Controllers
{
    public class AreaOimController : Controller
    {
        private readonly OimContext _context;

        public AreaOimController(OimContext context)
        {
            _context = context;
        }

        // GET: AreaOim
        public async Task<IActionResult> Index()
        {
              return View(await _context.AreaOims.ToListAsync());
        }

        // GET: AreaOim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AreaOims == null)
            {
                return NotFound();
            }

            var areaOim = await _context.AreaOims
                .FirstOrDefaultAsync(m => m.IdAreaOim == id);
            if (areaOim == null)
            {
                return NotFound();
            }

            return View(areaOim);
        }

        // GET: AreaOim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AreaOim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAreaOim,Descripcion")] AreaOim areaOim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaOim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(areaOim);
        }

        // GET: AreaOim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AreaOims == null)
            {
                return NotFound();
            }

            var areaOim = await _context.AreaOims.FindAsync(id);
            if (areaOim == null)
            {
                return NotFound();
            }
            return View(areaOim);
        }

        // POST: AreaOim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAreaOim,Descripcion")] AreaOim areaOim)
        {
            if (id != areaOim.IdAreaOim)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaOim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaOimExists(areaOim.IdAreaOim))
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
            return View(areaOim);
        }

        // GET: AreaOim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AreaOims == null)
            {
                return NotFound();
            }

            var areaOim = await _context.AreaOims
                .FirstOrDefaultAsync(m => m.IdAreaOim == id);
            if (areaOim == null)
            {
                return NotFound();
            }

            return View(areaOim);
        }

        // POST: AreaOim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AreaOims == null)
            {
                return Problem("Entity set 'OimContext.AreaOims'  is null.");
            }
            var areaOim = await _context.AreaOims.FindAsync(id);
            if (areaOim != null)
            {
                _context.AreaOims.Remove(areaOim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaOimExists(int id)
        {
          return _context.AreaOims.Any(e => e.IdAreaOim == id);
        }


        /////
        /// ********************* CREATED METHOD ***********************
        /// 

        public IActionResult saveToExcel()
        {
            ExcelManager manager = new ExcelManager();
            DownloadManager download = new DownloadManager();


            var listado = _context.AreaOims.ToList();

            String fileName = "Files/areasP.xlsx";

            manager.saveExcelFile(listado, fileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);


        }

    }
}
