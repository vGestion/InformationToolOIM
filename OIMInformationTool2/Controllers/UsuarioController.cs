﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OIMInformationTool2.Models;

namespace OIMInformationTool2.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly OimContext _context;

        public UsuarioController(OimContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var oim2Context = _context.Usuarios.Include(u => u.Rol);
            return View(await oim2Context.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["RolId"] = new SelectList(_context.Rols, "IdRol", "Descripcion");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,Correo,RolId,Activo,Passwrd")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolId"] = new SelectList(_context.Rols, "IdRol", "Descripcion", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["RolId"] = new SelectList(_context.Rols, "IdRol", "Descripcion", usuario.RolId);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Nombre,Correo,RolId,Activo,Passwrd")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            ViewData["RolId"] = new SelectList(_context.Rols, "IdRol", "Descripcion", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'Oim2Context.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }

        //****************************CREATED FUNCTIONS*******************************//

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserLogin()
        {
            string correo = Request.Form["Nombre"]!;
            string password = Request.Form["Passwrd"]!;

            List<Usuario> users = await _context.Usuarios.Where(r => r.Correo == correo).Where(r => r.Passwrd == password).ToListAsync();

            if (users.Count != 0)
            {
                this.HttpContext.Session.SetString("usuario", users[0].Nombre);
                this.HttpContext.Session.SetString("usuarioId", users[0].IdUsuario.ToString());
                this.HttpContext.Session.SetString("tipoUsuario", users[0].RolId.ToString());
                return RedirectToAction("Index", "Home");
            }else{
                return RedirectToAction("Index", "Login");
            }



        }

        public async Task<ActionResult> UserLogout()
        {
            this.HttpContext.Session.SetString("usuario","");
            this.HttpContext.Session.SetString("usuarioId", "");
            this.HttpContext.Session.SetString("tipoUsuario", "");
            return RedirectToAction("Index", "Login");

        }
    }
}

    

