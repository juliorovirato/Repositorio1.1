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
    public class HorariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private HorarioModels horarioModels;

        public HorariosController(ApplicationDbContext context)
        {
            _context = context;
            horarioModels = new HorarioModels(context);
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public List<Actividades> getActividades()
        {
            return horarioModels.getActividades();
        }
        public List<IdentityError> agregarHorario(int id, string dia, string hora, int actividad, string funcion)
        {
            return horarioModels.agregarHorario(id, dia, hora, actividad, funcion);
        }
        public List<object[]> filtrarHorario(int numPagina, string valor, string order)
        {
            return horarioModels.filtrarHorario(numPagina, valor, order);
        }
        public List<Horario> getHorario(int id)
        {
            return horarioModels.getHorario(id);
        }
        public List<IdentityError> editarHorario(int id, string dia, string hora, int actividad, int funcion)
        {
            return horarioModels.editarHorario(id, dia, hora, actividad, funcion);
        }
        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Actividades)
                .SingleOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HorarioID,ActividadesID,Dia,Hora")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID", horario.ActividadesID);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario.SingleOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID", horario.ActividadesID);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HorarioID,ActividadesID,Dia,Hora")] Horario horario)
        {
            if (id != horario.HorarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.HorarioID))
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
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "ActividadesID", "ActividadesID", horario.ActividadesID);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Actividades)
                .SingleOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.Horario.SingleOrDefaultAsync(m => m.HorarioID == id);
            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.HorarioID == id);
        }
    }
}
