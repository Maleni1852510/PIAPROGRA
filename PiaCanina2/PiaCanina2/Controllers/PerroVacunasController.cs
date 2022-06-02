using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PiaCanina2.Models.dbModels;

//Historial Medico

namespace PiaCanina2.Controllers
{
    [Authorize(Policy = "AdminRole")]
    public class PerroVacunasController : Controller
    {
        private readonly CaninaContext _context;

        public PerroVacunasController(CaninaContext context)
        {
            _context = context;
        }

        // GET: PerroVacunas
        public async Task<IActionResult> Index()
        {
            var caninaContext = _context.PerroVacunas.Include(p => p.IdperroNavigation).Include(p => p.IdvacunaNavigation);
            return View(await caninaContext.ToListAsync());
        }

        // GET: PerroVacunas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perroVacuna = await _context.PerroVacunas
                .Include(p => p.IdperroNavigation)
                .Include(p => p.IdvacunaNavigation)
                .FirstOrDefaultAsync(m => m.Idperro == id);
            if (perroVacuna == null)
            {
                return NotFound();
            }

            return View(perroVacuna);
        }

        // GET: PerroVacunas/Create
        public IActionResult Create()
        {
            ViewData["Idperro"] = new SelectList(_context.Perros, "Idperro", "Idperro");
            ViewData["Idvacuna"] = new SelectList(_context.Vacunas, "Idvacuna", "NombreVacuna");
            return View();
        }

        // POST: PerroVacunas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idperro,Idvacuna")] PerroVacuna perroVacuna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perroVacuna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idperro"] = new SelectList(_context.Perros, "Idperro", "Idperro", perroVacuna.Idperro);
            ViewData["Idvacuna"] = new SelectList(_context.Vacunas, "Idvacuna", "NombreVacuna", perroVacuna.Idvacuna);
            return View(perroVacuna);
        }

        // GET: PerroVacunas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perroVacuna = await _context.PerroVacunas.FindAsync(id);
            if (perroVacuna == null)
            {
                return NotFound();
            }
            ViewData["Idperro"] = new SelectList(_context.Perros, "Idperro", "Idperro", perroVacuna.Idperro);
            ViewData["Idvacuna"] = new SelectList(_context.Vacunas, "Idvacuna", "NombreVacuna", perroVacuna.Idvacuna);
            return View(perroVacuna);
        }

        // POST: PerroVacunas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idperro,Idvacuna")] PerroVacuna perroVacuna)
        {
            if (id != perroVacuna.Idperro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perroVacuna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerroVacunaExists(perroVacuna.Idperro))
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
            ViewData["Idperro"] = new SelectList(_context.Perros, "Idperro", "Idperro", perroVacuna.Idperro);
            ViewData["Idvacuna"] = new SelectList(_context.Vacunas, "Idvacuna", "NombreVacuna", perroVacuna.Idvacuna);
            return View(perroVacuna);
        }

        // GET: PerroVacunas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perroVacuna = await _context.PerroVacunas
                .Include(p => p.IdperroNavigation)
                .Include(p => p.IdvacunaNavigation)
                .FirstOrDefaultAsync(m => m.Idperro == id);
            if (perroVacuna == null)
            {
                return NotFound();
            }

            return View(perroVacuna);
        }

        // POST: PerroVacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perroVacuna = await _context.PerroVacunas.FindAsync(id);
            _context.PerroVacunas.Remove(perroVacuna);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerroVacunaExists(int id)
        {
            return _context.PerroVacunas.Any(e => e.Idperro == id);
        }
    }
}
