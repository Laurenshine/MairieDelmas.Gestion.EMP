using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MairieDelmas.Gestion.EMP.Data;
using MairieDelmas.Gestion.EMP.Models.Doleance;

namespace MairieDelmas.Gestion.EMP.Controllers
{
    public class DoleancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoleancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Doleances
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doleance.ToListAsync());
        }

        // GET: Doleances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doleance = await _context.Doleance
                .FirstOrDefaultAsync(m => m.DoleanceId == id);
            if (doleance == null)
            {
                return NotFound();
            }

            return View(doleance);
        }

        // GET: Doleances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doleances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoleanceId,NomComplet,Demande,Telephone,Email,DateDoloeance,Service,User,Suivi,Remarque")] Doleance doleance)
        {
            Random co = new Random();
            string code = string.Format("Dol-{0}{1}{2}", co.Next(0, 9), co.Next(0, 99), co.Next(1, 999), DateTime.Now.Millisecond);
            if (ModelState.IsValid)
            {
                
                doleance.CodeDoleance = code;
                _context.Add(doleance);
                await _context.SaveChangesAsync();
                //TempData["Success"] = $"Le code du Dolenace"+code;
                return RedirectToAction(nameof(Index));
            }
            return View(doleance);
        }

        // GET: Doleances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doleance = await _context.Doleance.FindAsync(id);
            if (doleance == null)
            {
                return NotFound();
            }
            return View(doleance);
        }

        // POST: Doleances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoleanceId,NomComplet,Demande,Telephone,Email,DateDoloeance,Service,User,Suivi,Remarque")] Doleance doleance)
        {
            if (id != doleance.DoleanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doleance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoleanceExists(doleance.DoleanceId))
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
            return View(doleance);
        }

        // GET: Doleances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doleance = await _context.Doleance
                .FirstOrDefaultAsync(m => m.DoleanceId == id);
            if (doleance == null)
            {
                return NotFound();
            }

            return View(doleance);
        }

        // POST: Doleances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doleance = await _context.Doleance.FindAsync(id);
            _context.Doleance.Remove(doleance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoleanceExists(int id)
        {
            return _context.Doleance.Any(e => e.DoleanceId == id);
        }
        public async Task<IActionResult> RechercheDoloeance(string recherche)
        {
            var dol = from dole in _context.Doleance
                      select dole;


             if (!String.IsNullOrEmpty(recherche))
            {
                dol = dol.Where(e=>e.NomComplet.Contains(recherche) || e.Telephone.Contains(recherche) || e.Email.Contains(recherche)||e.CodeDoleance.Contains(recherche));
            }



            return View(await dol.ToListAsync());
        }
    }
}
