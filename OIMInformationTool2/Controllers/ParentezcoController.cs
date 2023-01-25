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
    public class ParentezcoController : Controller
    {
        private readonly OimContext _context;

        public ParentezcoController(OimContext context)
        {
            _context = context;
        }

        // GET: Parentezco
        public async Task<IActionResult> Index()
        {
              return View(await _context.Parentezcos.ToListAsync());
        }

        // GET: Parentezco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parentezcos == null)
            {
                return NotFound();
            }

            var parentezco = await _context.Parentezcos
                .FirstOrDefaultAsync(m => m.IdParentezco == id);
            if (parentezco == null)
            {
                return NotFound();
            }

            return View(parentezco);
        }

        // GET: Parentezco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parentezco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParentezco,Descripcion")] Parentezco parentezco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parentezco);
                TempData["alertMessage"] = "Creado con éxito";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parentezco);
        }

        // GET: Parentezco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parentezcos == null)
            {
                return NotFound();
            }

            var parentezco = await _context.Parentezcos.FindAsync(id);
            if (parentezco == null)
            {
                return NotFound();
            }
            return View(parentezco);
        }

        // POST: Parentezco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParentezco,Descripcion")] Parentezco parentezco)
        {
            if (id != parentezco.IdParentezco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parentezco);
                    TempData["alertMessage"] = "Editado con éxito";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentezcoExists(parentezco.IdParentezco))
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
            return View(parentezco);
        }

        // GET: Parentezco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parentezcos == null)
            {
                return NotFound();
            }

            var parentezco = await _context.Parentezcos
                .FirstOrDefaultAsync(m => m.IdParentezco == id);
            if (parentezco == null)
            {
                return NotFound();
            }

            return View(parentezco);
        }

        // POST: Parentezco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parentezcos == null)
            {
                return Problem("Entity set 'OimContext.Parentezcos'  is null.");
            }
            var parentezco = await _context.Parentezcos.FindAsync(id);
            if (parentezco != null)
            {
                _context.Parentezcos.Remove(parentezco);
                TempData["alertMessage"] = "Eliminado con éxito";
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentezcoExists(int id)
        {
          return _context.Parentezcos.Any(e => e.IdParentezco == id);
        }


        // ************************************************************************************
        // ******************************CREATED FUNCTIONS************************************* 
        // ************************************************************************************ 


        public IActionResult saveToExcel()
        {
            ExcelManager manager = new ExcelManager();
            DownloadManager download = new DownloadManager();


            var listado = _context.Parentezcos.ToList();

            String fileName = "Files/Parentescos.xlsx";

            manager.saveExcelFile(listado, fileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);


        }
    }
}
