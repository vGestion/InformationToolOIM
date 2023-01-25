using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OIMInformationTool2.Models;
using OIMInformationTool2.Utils;

namespace OIMInformationTool2.Controllers
{
    public class ObjetivoController : Controller
    {
        private readonly OimContext _context;

        public ObjetivoController(OimContext context)
        {
            _context = context;
        }

        // GET: Objetivo
        public async Task<IActionResult> Index()
        {
              return View(await _context.Objetivos.ToListAsync());
        }

        // GET: Objetivo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Objetivos == null)
            {
                return NotFound();
            }

            var objetivo = await _context.Objetivos
                .FirstOrDefaultAsync(m => m.IdObjetivo == id);
            if (objetivo == null)
            {
                return NotFound();
            }

            return View(objetivo);
        }

        // GET: Objetivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Objetivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObjetivo,Descripcion")] Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objetivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objetivo);
        }

        // GET: Objetivo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Objetivos == null)
            {
                return NotFound();
            }

            var objetivo = await _context.Objetivos.FindAsync(id);
            if (objetivo == null)
            {
                return NotFound();
            }
            return View(objetivo);
        }

        // POST: Objetivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdObjetivo,Descripcion")] Objetivo objetivo)
        {
            if (id != objetivo.IdObjetivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objetivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetivoExists(objetivo.IdObjetivo))
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
            return View(objetivo);
        }

        // GET: Objetivo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Objetivos == null)
            {
                return NotFound();
            }

            var objetivo = await _context.Objetivos
                .FirstOrDefaultAsync(m => m.IdObjetivo == id);
            if (objetivo == null)
            {
                return NotFound();
            }

            return View(objetivo);
        }

        // POST: Objetivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Objetivos == null)
            {
                return Problem("Entity set 'OimContext.Objetivos'  is null.");
            }
            var objetivo = await _context.Objetivos.FindAsync(id);
            if (objetivo != null)
            {
                _context.Objetivos.Remove(objetivo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjetivoExists(string id)
        {
          return _context.Objetivos.Any(e => e.IdObjetivo == id);
        }



        // ************************************************************************************
        // ******************************CREATED FUNCTIONS************************************* 
        // ************************************************************************************ 


        public IActionResult saveToExcel()
        {
            ExcelManager manager = new ExcelManager();
            DownloadManager download = new DownloadManager();


            var listado = _context.Objetivos.ToList();

            String fileName = "Files/Objetivos.xlsx";

            manager.saveExcelFile(listado, fileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);


        }
    }
}
