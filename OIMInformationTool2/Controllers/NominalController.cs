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
    public class NominalController : Controller
    {
        private readonly OimContext _context;

        public NominalController(OimContext context)
        {
            _context = context;
        }

        // GET: Nominal
        public async Task<IActionResult> Index()
        {
            var oimContext = _context.Nominals.Include(n => n.CondicionEsp).Include(n => n.CriterioMovi).Include(n => n.Genero).Include(n => n.IdentSexual).Include(n => n.Indicador).Include(n => n.Nacionalidad).Include(n => n.Parentezco).Include(n => n.Periodo).Include(n => n.Sexo).Include(n => n.Usuario);
            return View(await oimContext.ToListAsync());
        }

        // GET: Nominal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nominals == null)
            {
                return NotFound();
            }

            var nominal = await _context.Nominals
                .Include(n => n.CondicionEsp)
                .Include(n => n.CriterioMovi)
                .Include(n => n.Genero)
                .Include(n => n.IdentSexual)
                .Include(n => n.Indicador)
                .Include(n => n.Nacionalidad)
                .Include(n => n.Parentezco)
                .Include(n => n.Periodo)
                .Include(n => n.Sexo)
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(m => m.IdNominal == id);
            if (nominal == null)
            {
                return NotFound();
            }

            return View(nominal);
        }

        // GET: Nominal/Create
        public IActionResult Create()
        {
            ViewData["CondicionEspId"] = new SelectList(_context.CondicionEsps, "IdCondicionEsp", "IdCondicionEsp");
            ViewData["CriterioMoviId"] = new SelectList(_context.CriterioMovis, "IdCriterioMovi", "IdCriterioMovi");
            ViewData["GeneroId"] = new SelectList(_context.Generos, "IdGenero", "IdGenero");
            ViewData["IdentSexualId"] = new SelectList(_context.IdentSexuals, "IdIdentSexual", "IdIdentSexual");
            ViewData["IndicadorId"] = new SelectList(_context.Actividads, "IdActividad", "IdActividad");
            ViewData["NacionalidadId"] = new SelectList(_context.Nacionalidads, "IdNacionalidad", "IdNacionalidad");
            ViewData["ParentezcoId"] = new SelectList(_context.Parentezcos, "IdParentezco", "IdParentezco");
            ViewData["PeriodoId"] = new SelectList(_context.Periodos, "IdPeriodo", "IdPeriodo");
            ViewData["SexoId"] = new SelectList(_context.Sexos, "IdSexo", "IdSexo");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Nominal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNominal,FechaAsistencia,FechaCorte,Edad,Discapacidad,Monto,FechaRegistro,IndicadorId,SexoId,NacionalidadId,CantonId,ProvinciaId,ParentezcoId,CriterioMoviId,PeriodoId,UsuarioId,CondicionEspId,IdentSexualId,GeneroId")] Nominal nominal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nominal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondicionEspId"] = new SelectList(_context.CondicionEsps, "IdCondicionEsp", "IdCondicionEsp", nominal.CondicionEspId);
            ViewData["CriterioMoviId"] = new SelectList(_context.CriterioMovis, "IdCriterioMovi", "IdCriterioMovi", nominal.CriterioMoviId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", nominal.GeneroId);
            ViewData["IdentSexualId"] = new SelectList(_context.IdentSexuals, "IdIdentSexual", "IdIdentSexual", nominal.IdentSexualId);
            ViewData["IndicadorId"] = new SelectList(_context.Actividads, "IdActividad", "IdActividad", nominal.IndicadorId);
            ViewData["NacionalidadId"] = new SelectList(_context.Nacionalidads, "IdNacionalidad", "IdNacionalidad", nominal.NacionalidadId);
            ViewData["ParentezcoId"] = new SelectList(_context.Parentezcos, "IdParentezco", "IdParentezco", nominal.ParentezcoId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodos, "IdPeriodo", "IdPeriodo", nominal.PeriodoId);
            ViewData["SexoId"] = new SelectList(_context.Sexos, "IdSexo", "IdSexo", nominal.SexoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", nominal.UsuarioId);
            return View(nominal);
        }

        // GET: Nominal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nominals == null)
            {
                return NotFound();
            }

            var nominal = await _context.Nominals.FindAsync(id);
            if (nominal == null)
            {
                return NotFound();
            }
            ViewData["CondicionEspId"] = new SelectList(_context.CondicionEsps, "IdCondicionEsp", "IdCondicionEsp", nominal.CondicionEspId);
            ViewData["CriterioMoviId"] = new SelectList(_context.CriterioMovis, "IdCriterioMovi", "IdCriterioMovi", nominal.CriterioMoviId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", nominal.GeneroId);
            ViewData["IdentSexualId"] = new SelectList(_context.IdentSexuals, "IdIdentSexual", "IdIdentSexual", nominal.IdentSexualId);
            ViewData["IndicadorId"] = new SelectList(_context.Actividads, "IdActividad", "IdActividad", nominal.IndicadorId);
            ViewData["NacionalidadId"] = new SelectList(_context.Nacionalidads, "IdNacionalidad", "IdNacionalidad", nominal.NacionalidadId);
            ViewData["ParentezcoId"] = new SelectList(_context.Parentezcos, "IdParentezco", "IdParentezco", nominal.ParentezcoId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodos, "IdPeriodo", "IdPeriodo", nominal.PeriodoId);
            ViewData["SexoId"] = new SelectList(_context.Sexos, "IdSexo", "IdSexo", nominal.SexoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", nominal.UsuarioId);
            return View(nominal);
        }

        // POST: Nominal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNominal,FechaAsistencia,FechaCorte,Edad,Discapacidad,Monto,FechaRegistro,IndicadorId,SexoId,NacionalidadId,CantonId,ProvinciaId,ParentezcoId,CriterioMoviId,PeriodoId,UsuarioId,CondicionEspId,IdentSexualId,GeneroId")] Nominal nominal)
        {
            if (id != nominal.IdNominal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nominal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NominalExists(nominal.IdNominal))
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
            ViewData["CondicionEspId"] = new SelectList(_context.CondicionEsps, "IdCondicionEsp", "IdCondicionEsp", nominal.CondicionEspId);
            ViewData["CriterioMoviId"] = new SelectList(_context.CriterioMovis, "IdCriterioMovi", "IdCriterioMovi", nominal.CriterioMoviId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", nominal.GeneroId);
            ViewData["IdentSexualId"] = new SelectList(_context.IdentSexuals, "IdIdentSexual", "IdIdentSexual", nominal.IdentSexualId);
            ViewData["IndicadorId"] = new SelectList(_context.Actividads, "IdActividad", "IdActividad", nominal.IndicadorId);
            ViewData["NacionalidadId"] = new SelectList(_context.Nacionalidads, "IdNacionalidad", "IdNacionalidad", nominal.NacionalidadId);
            ViewData["ParentezcoId"] = new SelectList(_context.Parentezcos, "IdParentezco", "IdParentezco", nominal.ParentezcoId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodos, "IdPeriodo", "IdPeriodo", nominal.PeriodoId);
            ViewData["SexoId"] = new SelectList(_context.Sexos, "IdSexo", "IdSexo", nominal.SexoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", nominal.UsuarioId);
            return View(nominal);
        }

        // GET: Nominal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nominals == null)
            {
                return NotFound();
            }

            var nominal = await _context.Nominals
                .Include(n => n.CondicionEsp)
                .Include(n => n.CriterioMovi)
                .Include(n => n.Genero)
                .Include(n => n.IdentSexual)
                .Include(n => n.Indicador)
                .Include(n => n.Nacionalidad)
                .Include(n => n.Parentezco)
                .Include(n => n.Periodo)
                .Include(n => n.Sexo)
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(m => m.IdNominal == id);
            if (nominal == null)
            {
                return NotFound();
            }

            return View(nominal);
        }

        // POST: Nominal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nominals == null)
            {
                return Problem("Entity set 'OimContext.Nominals'  is null.");
            }
            var nominal = await _context.Nominals.FindAsync(id);
            if (nominal != null)
            {
                _context.Nominals.Remove(nominal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NominalExists(int id)
        {
          return _context.Nominals.Any(e => e.IdNominal == id);
        }
    }
}
