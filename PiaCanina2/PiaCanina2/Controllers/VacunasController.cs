using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PiaCanina2.Models.dbModels;

// Registro de vacunas

namespace PiaCanina2.Controllers
{
    [Authorize(Policy = "AdminRole")]
    public class VacunasController : Controller
    {
        private readonly CaninaContext _context;

        public VacunasController(CaninaContext context)
        {
            _context = context;
        }

        // GET: Vacunas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vacunas.ToListAsync());
        }

        // GET: Vacunas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacuna = await _context.Vacunas
                .FirstOrDefaultAsync(m => m.Idvacuna == id);
            if (vacuna == null)
            {
                return NotFound();
            }

            return View(vacuna);
        }

        // GET: Vacunas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vacunas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idvacuna,NombreVacuna")] Vacuna vacuna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacuna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacuna);
        }

        // GET: Vacunas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacuna = await _context.Vacunas.FindAsync(id);
            if (vacuna == null)
            {
                return NotFound();
            }
            return View(vacuna);
        }

        // POST: Vacunas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idvacuna,NombreVacuna")] Vacuna vacuna)
        {
            if (id != vacuna.Idvacuna)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacuna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacunaExists(vacuna.Idvacuna))
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
            return View(vacuna);
        }

        // GET: Vacunas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacuna = await _context.Vacunas
                .FirstOrDefaultAsync(m => m.Idvacuna == id);
            if (vacuna == null)
            {
                return NotFound();
            }

            return View(vacuna);
        }

        // POST: Vacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacuna = await _context.Vacunas.FindAsync(id);
            _context.Vacunas.Remove(vacuna);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacunaExists(int id)
        {
            return _context.Vacunas.Any(e => e.Idvacuna == id);
        }
    }
}
