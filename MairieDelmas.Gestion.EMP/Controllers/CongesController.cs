using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MairieDelmas.Gestion.EMP.Data;
using MairieDelmas.Gestion.EMP.Models.Conge;

namespace MairieDelmas.Gestion.EMP.Controllers
{
    public class CongesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CongesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conges1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conge.ToListAsync());
        }

        // GET: Conges1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conge = await _context.Conge
                .FirstOrDefaultAsync(m => m.CongeId == id);
            if (conge == null)
            {
                return NotFound();
            }

            return View(conge);
        }

        // GET: Conges1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conges1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CongeId,EmployeId,TypeConge,DebutConge,FinConge,ReprendreService,Observation")] Conge conge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conge);
        }

        // GET: Conges1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conge = await _context.Conge.FindAsync(id);
            if (conge == null)
            {
                return NotFound();
            }
            return View(conge);
        }

        // POST: Conges1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CongeId,EmployeId,TypeConge,DebutConge,FinConge,ReprendreService,Observation")] Conge conge)
        {
            if (id != conge.CongeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongeExists(conge.CongeId))
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
            return View(conge);
        }

        // GET: Conges1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conge = await _context.Conge
                .FirstOrDefaultAsync(m => m.CongeId == id);
            if (conge == null)
            {
                return NotFound();
            }

            return View(conge);
        }

        // POST: Conges1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conge = await _context.Conge.FindAsync(id);
            _context.Conge.Remove(conge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongeExists(int id)
        {
            return _context.Conge.Any(e => e.CongeId == id);
        }

        public async Task<IActionResult> ListerEmpConge(string recherche)
        {
            var Conge1 = new Conge();

            var EmpConge = from Emp in _context.Employe
                           join Cong in _context.Conge on Emp.EmployeId equals Cong.EmployeId into Conge

                           where Emp.Nom.Contains(recherche) || Emp.Prenom.Contains(recherche)
                           select new { Conge1.TypeConge, Conge1.DebutConge, Conge1.FinConge, Conge1.NombresJour, Conge1.ReprendreService };
            
            return View(await EmpConge.ToListAsync());
 
        }
    }
}
