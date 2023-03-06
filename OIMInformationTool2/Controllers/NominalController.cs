using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.Excel;
using InformationToolOIM2.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OIMInformationTool2.Models;
using OIMInformationTool2.Utils;

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
            var oimContext = _context.Nominals.Include(n => n.Actividad).Include(n => n.CondicionEsp).Include(n => n.CriterioMovi).Include(n => n.Genero).Include(n => n.IdentSexual).Include(n => n.Nacionalidad).Include(n => n.Parentezco).Include(n => n.Periodo).Include(n => n.Sexo).Include(n => n.Usuario);
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
                .Include(n => n.Actividad)
                .Include(n => n.CondicionEsp)
                .Include(n => n.CriterioMovi)
                .Include(n => n.Genero)
                .Include(n => n.IdentSexual)
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
            ViewData["ActividadId"] = new SelectList(_context.Actividads, "IdActividad", "IdActividad");
            ViewData["CondicionEspId"] = new SelectList(_context.CondicionEsps, "IdCondicionEsp", "IdCondicionEsp");
            ViewData["CriterioMoviId"] = new SelectList(_context.CriterioMovis, "IdCriterioMovi", "IdCriterioMovi");
            ViewData["GeneroId"] = new SelectList(_context.Generos, "IdGenero", "IdGenero");
            ViewData["IdentSexualId"] = new SelectList(_context.IdentSexuals, "IdIdentSexual", "IdIdentSexual");
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
        public async Task<IActionResult> Create([Bind("IdNominal,FechaAsistencia,FechaCorte,Edad,Discapacidad,Monto,FechaRegistro,NacionalidadId,ActividadId,SexoId,CantonId,ProvinciaId,ParentezcoId,CriterioMoviId,PeriodoId,UsuarioId,CondicionEspId,IdentSexualId,GeneroId")] Nominal nominal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nominal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActividadId"] = new SelectList(_context.Actividads, "IdActividad", "IdActividad", nominal.ActividadId);
            ViewData["CondicionEspId"] = new SelectList(_context.CondicionEsps, "IdCondicionEsp", "IdCondicionEsp", nominal.CondicionEspId);
            ViewData["CriterioMoviId"] = new SelectList(_context.CriterioMovis, "IdCriterioMovi", "IdCriterioMovi", nominal.CriterioMoviId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", nominal.GeneroId);
            ViewData["IdentSexualId"] = new SelectList(_context.IdentSexuals, "IdIdentSexual", "IdIdentSexual", nominal.IdentSexualId);
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
            ViewData["ActividadId"] = new SelectList(_context.Actividads, "IdActividad", "IdActividad", nominal.ActividadId);
            ViewData["CondicionEspId"] = new SelectList(_context.CondicionEsps, "IdCondicionEsp", "IdCondicionEsp", nominal.CondicionEspId);
            ViewData["CriterioMoviId"] = new SelectList(_context.CriterioMovis, "IdCriterioMovi", "IdCriterioMovi", nominal.CriterioMoviId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", nominal.GeneroId);
            ViewData["IdentSexualId"] = new SelectList(_context.IdentSexuals, "IdIdentSexual", "IdIdentSexual", nominal.IdentSexualId);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdNominal,FechaAsistencia,FechaCorte,Edad,Discapacidad,Monto,FechaRegistro,NacionalidadId,ActividadId,SexoId,CantonId,ProvinciaId,ParentezcoId,CriterioMoviId,PeriodoId,UsuarioId,CondicionEspId,IdentSexualId,GeneroId")] Nominal nominal)
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
            ViewData["ActividadId"] = new SelectList(_context.Actividads, "IdActividad", "IdActividad", nominal.ActividadId);
            ViewData["CondicionEspId"] = new SelectList(_context.CondicionEsps, "IdCondicionEsp", "IdCondicionEsp", nominal.CondicionEspId);
            ViewData["CriterioMoviId"] = new SelectList(_context.CriterioMovis, "IdCriterioMovi", "IdCriterioMovi", nominal.CriterioMoviId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", nominal.GeneroId);
            ViewData["IdentSexualId"] = new SelectList(_context.IdentSexuals, "IdIdentSexual", "IdIdentSexual", nominal.IdentSexualId);
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
                .Include(n => n.Actividad)
                .Include(n => n.CondicionEsp)
                .Include(n => n.CriterioMovi)
                .Include(n => n.Genero)
                .Include(n => n.IdentSexual)
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

        // ************************************************************************************
        // ******************************CREATED FUNCTIONS************************************* 
        // ************************************************************************************

        public ActionResult InsertFromExcel()
        {
            string Path = this.HttpContext.Session.GetString("archivo");
            // Reading information from excel sheet
            ExcelManager reader = new ExcelManager();
            DataSet data = reader.readExcelSheet(Path);



            Boolean valido = true;

            // Inserting information into database

            int i = 0;
            String error = "";

            if (_context.Periodos.Where(r => r.Activo == true).ToList().Count() == 0)
            {

                TempData["alertMessage"] = "No existe un periodo activo";
            }
            else
            {
                List<Nominal> registros = new List<Nominal>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    Finders find = new Finders();
                    Nominal nominal = new Nominal();

                    if ((dr["ID_ACTIVIDAD"].ToString() == "") && (dr["FECHA_ASISTENCIA"].ToString() == "") && (dr["CORTE"].ToString() == "") && (dr["EDAD"].ToString() == "") && (dr["DISCAPACIDAD"].ToString() == "") && (dr["MONTO_ECONOMICO"].ToString() == "")
                    && (dr["ID_GENERO"].ToString() == "") && (dr["SEXO"].ToString() == "") && (dr["NACIONALIDAD"].ToString() == "") && (dr["ID_CANTON"].ToString() == "") && (dr["PARENTEZCO"].ToString() == "") && (dr["CRITERIO_MOVILIDAD"].ToString() == "")
                    && (dr["IDENTIDAD_SEXUAL"].ToString() == "") && (dr["CONDICION"].ToString() == ""))
                    {

                        break;
                    }

                    i = i + 1;

                    if ((dr["ID_ACTIVIDAD"].ToString() == ""))
                    {
                        error = error + "La columna INDICADOR está vacía en la fila " + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.ActividadId = dr["ID_ACTIVIDAD"].ToString();
                    }

                    if ((dr["FECHA_ASISTENCIA"].ToString() == ""))
                    {
                        error = error + "La columna FECHA_ASISTENCIA está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.FechaAsistencia = DateTime.Parse(dr["FECHA_ASISTENCIA"].ToString());
                    }

                    if ((dr["CORTE"].ToString() == ""))
                    {
                        error = error + "La columna CORTE está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.FechaCorte = DateTime.Parse(dr["CORTE"].ToString());
                    }

                    if ((dr["EDAD"].ToString() == ""))
                    {
                        error = error + "La columna EDAD está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.Edad = (int)Convert.ToInt64(dr["EDAD"].ToString());
                    }

                    if ((dr["DISCAPACIDAD"].ToString() == ""))
                    {
                        error = error + "La columna DISCAPACIDAD está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.Discapacidad = find.DiscapacidadTranformer(dr["DISCAPACIDAD"].ToString());
                    }

                    if ((dr["MONTO_ECONOMICO"].ToString() == ""))
                    {
                        error = error + "La columna MONTO está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.Monto = Convert.ToDecimal(dr["MONTO_ECONOMICO"].ToString());
                    }
                    
                    if ((dr["ID_GENERO"].ToString() == ""))
                    {
                        error = error + "La columna GENERO está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.GeneroId = find.IdFinderGenero(dr["ID_GENERO"].ToString(), _context.Generos.ToList());


                        if (nominal.GeneroId == 999999)
                        {
                            error = error + "No se ha encontrado el género de la fila " + i + " *** ";
                            valido = false;
                        }
                    }

                    if ((dr["SEXO"].ToString() == ""))
                    {
                        error = error + "La columna SEXO está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.SexoId = find.IdFinderSexo(dr["SEXO"].ToString(), _context.Sexos.ToList());
                        if (nominal.SexoId == 999999)
                        {
                            error = error + "No se ha encontrado el sexo de la fila " + i + " *** ";
                            valido = false;
                        }
                    }

                    if ((dr["NACIONALIDAD"].ToString() == ""))
                    {
                        error = error + "La columna NACIONALIDAD está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.NacionalidadId = find.IdFinderNacionalidad(dr["NACIONALIDAD"].ToString(), _context.Nacionalidads.ToList());
                        if(nominal.NacionalidadId == 999999)
                        {
                            error = error + "No se ha encontrado la nacionalidad de la fila " + i + " *** ";
                            valido = false;
                        }
                    }
                    
                    if ((dr["ID_CANTON"].ToString() == ""))
                    {
                        error = error + "La columna CANTON está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.CantonId = (int)Convert.ToInt64(dr["ID_CANTON"].ToString().Substring(0, 2));
                        nominal.ProvinciaId = (int)Convert.ToInt64(dr["ID_CANTON"].ToString().Substring(2, 2));
                    }

                    if ((dr["PARENTEZCO"].ToString() == ""))
                    {
                        error = error + "La columna PARENTEZCO está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.ParentezcoId = find.IdFinderParentezco(dr["PARENTEZCO"].ToString(), _context.Parentezcos.ToList());
                        if (nominal.ParentezcoId == 999999)
                        {
                            error = error + "No se ha encontrado el parentezco de la fila " + i + " *** ";
                            valido = false;
                        }

                    }
                    
                    if (dr["CRITERIO_MOVILIDAD"].ToString() == "")
                    {
                        error = error + "La columna CRITERIO_MOVILIDAD está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.CriterioMoviId = find.IdFinderCriterioMovilidad(dr["CRITERIO_MOVILIDAD"].ToString(), _context.CriterioMovis.ToList());
                        if (nominal.CriterioMoviId == 999999)
                        {
                            error = error + "No se ha encontrado el criterio movilidad de la fila " + i + " *** ";
                            valido = false;
                        }
                        
                    }

                    if (dr["CONDICION"].ToString() == "")
                    {
                        error = error + "La columna CONDICION está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.CondicionEspId = (int)Convert.ToInt64(dr["CONDICION"].ToString());
                    }

                    if (dr["IDENTIDAD_SEXUAL"].ToString() == "")
                    {
                        error = error + "La columna IDENTIDAD_SEXUAL está vacía en la fila" + i + " *** ";
                        valido = false;
                    }
                    else
                    {
                        nominal.IdentSexualId = (int)Convert.ToInt64(dr["IDENTIDAD_SEXUAL"].ToString());
                        
                    }

                    nominal.FechaRegistro = DateTime.Now;
                    nominal.UsuarioId = (int)Convert.ToInt64(HttpContext.Session.GetString("usuarioId")); ;
                    nominal.IdNominal = _context.Nominals.ToList().Count() + 1 + registros.Count();
                    nominal.PeriodoId = _context.Periodos.FromSql($"Select * from dbo.Periodo where Activo = 1").ToList()[0].IdPeriodo;
                    
                    registros.Add(nominal);
                }

                System.Diagnostics.Debug.WriteLine(error);

                if (valido == false)
                {
                    TempData["alertMessage"] = error;
                }
                else
                {
                    foreach (Nominal nom in registros)
                    {
                        _context.Add(nom);
                        _context.SaveChanges();
                    }
                    TempData["alertMessage"] = "Los datos se han ingresado correctamente";
                }
            }

            if (System.IO.File.Exists(Path))
            {
                try
                {
                    System.IO.File.Delete(Path);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return RedirectToAction("Index");
        }


        public IActionResult saveToExcel()
        {
            ExcelManager manager = new ExcelManager();

            var listado = _context.Nominals
                .Include(n => n.CriterioMovi)
                .Include(n => n.Genero)
                .Include(n => n.Actividad)
                .Include(n => n.Nacionalidad)
                .Include(n => n.Parentezco)
                .Include(n => n.Periodo)
                .Include(n => n.Sexo)
                .Include(n => n.Usuario).ToList();

            String fileName = "Files/nominal.xlsx";

            manager.saveExcelFile(listado, fileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var stream = new FileStream(path, FileMode.Open);

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);


        }
    }
}
