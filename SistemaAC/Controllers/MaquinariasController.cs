using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaAC.Data;
using SistemaAC.Models;
using SistemaAC.ModelsClass;

namespace SistemaAC.Controllers
{
    public class MaquinariasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private MaquinariaModels maquinariaModels;

        public MaquinariasController(ApplicationDbContext context)
        {
            _context = context;
            maquinariaModels = new MaquinariaModels(context);
        }

        // GET: Maquinarias
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public List<Actividades> getActividades()
        {
            return maquinariaModels.getActividades();
        }
        public List<IdentityError> agregarMaquinaria(int id, string nombre, string cantidad, int actividad, string funcion)
        {
            return maquinariaModels.agregarMaquinaria(id, nombre, cantidad, actividad, funcion);
        }
        public List<object[]> filtrarMaquinaria(int numPagina, string valor, string order)
        {
            return maquinariaModels.filtrarMaquinaria(numPagina, valor, order);
        }
        public List<Maquinaria> getMaquinaria(int id)
        {
            return maquinariaModels.getMaquinaria(id);
        }
        public List<IdentityError> editarMaquinaria(int id, string nombre, string cantidad, int actividad, int funcion)
        {
            return maquinariaModels.editarMaquinaria(id, nombre, cantidad, actividad, funcion);
        }
        // GET: Maquinarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquinaria = await _context.Maquinaria
                .Include(m => m.Actividades)
                .SingleOrDefaultAsync(m => m.MaquinariaID == id);
            if (maquinaria == null)
            {
                return NotFound();
            }

            return View(maquinaria);
        }

        // GET: Maquinarias/Create
        public IActionResult Create()
        {
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID");
            return View();
        }

        // POST: Maquinarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaquinariaID,ActividadesID,Nombre,Cantidad")] Maquinaria maquinaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquinaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID", maquinaria.ActividadesID);
            return View(maquinaria);
        }

        // GET: Maquinarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquinaria = await _context.Maquinaria.SingleOrDefaultAsync(m => m.MaquinariaID == id);
            if (maquinaria == null)
            {
                return NotFound();
            }
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID", maquinaria.ActividadesID);
            return View(maquinaria);
        }

        // POST: Maquinarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaquinariaID,ActividadesID,Nombre,Cantidad")] Maquinaria maquinaria)
        {
            if (id != maquinaria.MaquinariaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquinaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinariaExists(maquinaria.MaquinariaID))
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
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID", maquinaria.ActividadesID);
            return View(maquinaria);
        }

        // GET: Maquinarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquinaria = await _context.Maquinaria
                .Include(m => m.Actividades)
                .SingleOrDefaultAsync(m => m.MaquinariaID == id);
            if (maquinaria == null)
            {
                return NotFound();
            }

            return View(maquinaria);
        }

        // POST: Maquinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maquinaria = await _context.Maquinaria.SingleOrDefaultAsync(m => m.MaquinariaID == id);
            _context.Maquinaria.Remove(maquinaria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinariaExists(int id)
        {
            return _context.Maquinaria.Any(e => e.MaquinariaID == id);
        }
    }
}
