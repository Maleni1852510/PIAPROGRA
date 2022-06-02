using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PiaCanina2.Models.dbModels;

namespace PiaCanina2.Controllers
{
    [Authorize(Policy = "AdminRole")]
    public class PerrosController : Controller
    {
        private readonly CaninaContext _context;

        public PerrosController(CaninaContext context)
        {
            _context = context;
        }

        // GET: Perros
        public async Task<IActionResult> Index()
        {
            var caninaContext = _context.Perros.Include(p => p.IdUsuarioNavigation).Include(p => p.RazaNavigation).Include(p => p.TamañoNavigation);
            return View(await caninaContext.ToListAsync());
        }



        // GET: Perros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perro = await _context.Perros
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.RazaNavigation)
                .Include(p => p.TamañoNavigation)
                .FirstOrDefaultAsync(m => m.Idperro == id);
            if (perro == null)
            {
                return NotFound();
            }

            return View(perro);
        }


        // GET: Perros/Create
        public IActionResult Create()
        {
            ViewData["Idusuario"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["Raza"] = new SelectList(_context.Razas, "Idraza", "NombreRaza");
            ViewData["Tamaño"] = new SelectList(_context.Tamanos, "IdTamano", "Descripcion");

            return View();
        }

        // POST: Perros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idperro,Raza,Edad,Peso,Foto,Descripcion,Sexo,Tamaño,Idusuario")] Perro perro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idusuario"] = new SelectList(_context.Users, "Id", "Id", perro.Idusuario);
            ViewData["Raza"] = new SelectList(_context.Razas, "Idraza", "Idraza", perro.Raza);
            ViewData["Tamaño"] = new SelectList(_context.Tamanos, "IdTamano", "Descripcion", perro.Tamaño);
            return View(perro);
        }

        // GET: Perros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perro = await _context.Perros.FindAsync(id);
            if (perro == null)
            {
                return NotFound();
            }
            ViewData["Idusuario"] = new SelectList(_context.Users, "Id", "Id", perro.Idusuario);
            ViewData["Raza"] = new SelectList(_context.Razas, "Idraza", "NombreRaza", perro.Raza);
            ViewData["Tamaño"] = new SelectList(_context.Tamanos, "IdTamano", "Descripcion", perro.Tamaño);
            return View(perro);
        }

        // POST: Perros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idperro,Raza,Edad,Peso,Foto,Descripcion,Sexo,Tamaño,Idusuario")] Perro perro)
        {
            if (id != perro.Idperro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerroExists(perro.Idperro))
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
            ViewData["Idusuario"] = new SelectList(_context.Users, "Id", "Id", perro.Idusuario);
            ViewData["Raza"] = new SelectList(_context.Razas, "Idraza", "NombreRaza", perro.Raza);
            ViewData["Tamaño"] = new SelectList(_context.Tamanos, "IdTamano", "Descripcion", perro.Tamaño);
            return View(perro);
        }

        // GET: Perros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perro = await _context.Perros
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.RazaNavigation)
                .Include(p => p.TamañoNavigation)
                .FirstOrDefaultAsync(m => m.Idperro == id);
            if (perro == null)
            {
                return NotFound();
            }

            return View(perro);
        }

        // POST: Perros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perro = await _context.Perros.FindAsync(id);
            _context.Perros.Remove(perro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerroExists(int id)
        {
            return _context.Perros.Any(e => e.Idperro == id);
        }
    }
}
