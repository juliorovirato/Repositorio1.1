using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaAC.Data;
using SistemaAC.Models;

namespace SistemaAC.Controllers
{
    public class TarifasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarifasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tarifas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tarifas.Include(t => t.Actividades);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tarifas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifas = await _context.Tarifas
                .Include(t => t.Actividades)
                .SingleOrDefaultAsync(m => m.TarifaID == id);
            if (tarifas == null)
            {
                return NotFound();
            }

            return View(tarifas);
        }

        // GET: Tarifas/Create
        public IActionResult Create()
        {
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID");
            return View();
        }

        // POST: Tarifas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarifaID,ActividadesID,ValorEst,ValorEmp,ValorFam,ValorGrad")] Tarifas tarifas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarifas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID", tarifas.ActividadesID);
            return View(tarifas);
        }

        // GET: Tarifas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifas = await _context.Tarifas.SingleOrDefaultAsync(m => m.TarifaID == id);
            if (tarifas == null)
            {
                return NotFound();
            }
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID", tarifas.ActividadesID);
            return View(tarifas);
        }

        // POST: Tarifas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TarifaID,ActividadesID,ValorEst,ValorEmp,ValorFam,ValorGrad")] Tarifas tarifas)
        {
            if (id != tarifas.TarifaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarifas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarifasExists(tarifas.TarifaID))
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
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID", tarifas.ActividadesID);
            return View(tarifas);
        }

        // GET: Tarifas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifas = await _context.Tarifas
                .Include(t => t.Actividades)
                .SingleOrDefaultAsync(m => m.TarifaID == id);
            if (tarifas == null)
            {
                return NotFound();
            }

            return View(tarifas);
        }

        // POST: Tarifas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarifas = await _context.Tarifas.SingleOrDefaultAsync(m => m.TarifaID == id);
            _context.Tarifas.Remove(tarifas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarifasExists(int id)
        {
            return _context.Tarifas.Any(e => e.TarifaID == id);
        }
    }
}
