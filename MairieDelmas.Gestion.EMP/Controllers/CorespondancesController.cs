using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MairieDelmas.Gestion.EMP.Data;
using MairieDelmas.Gestion.EMP.Models.Corespondance;

namespace MairieDelmas.Gestion.EMP.Controllers
{
    public class CorespondancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CorespondancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Corespondances
        public async Task<IActionResult> Index()
        {
            return View(await _context.Corespondance.ToListAsync());
        }

        // GET: Corespondances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corespondance = await _context.Corespondance
                .FirstOrDefaultAsync(m => m.CorespondanceId == id);
            if (corespondance == null)
            {
                return NotFound();
            }

            return View(corespondance);
        }

        // GET: Corespondances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Corespondances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CorespondanceId,NomComplet,Institution,Objet,Telephone,Email,Daterecu,Destination,User,Suivi,Remarque")] Corespondance corespondance)
        {
            Random co = new Random();
            string code = string.Format("Coresp-{0}{1}{2}", co.Next(0, 9), co.Next(0, 99), co.Next(1, 999), DateTime.Now.Millisecond);
            if (ModelState.IsValid)
            {
                corespondance.CodeCorespondance = code;
                _context.Add(corespondance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
             
            }
            return View(corespondance);
           
        }

        // GET: Corespondances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corespondance = await _context.Corespondance.FindAsync(id);
            if (corespondance == null)
            {
                return NotFound();
            }
            return View(corespondance);
        }

        // POST: Corespondances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CorespondanceId,NomComplet,Institution,Objet,Telephone,Email,Daterecu,Destination,User,Suivi,Remarque,CodeCorespondance")] Corespondance corespondance)
        {
            if (id != corespondance.CorespondanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corespondance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorespondanceExists(corespondance.CorespondanceId))
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
            return View(corespondance);
        }

        // GET: Corespondances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corespondance = await _context.Corespondance
                .FirstOrDefaultAsync(m => m.CorespondanceId == id);
            if (corespondance == null)
            {
                return NotFound();
            }

            return View(corespondance);
        }

        // POST: Corespondances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corespondance = await _context.Corespondance.FindAsync(id);
            _context.Corespondance.Remove(corespondance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorespondanceExists(int id)
        {
            return _context.Corespondance.Any(e => e.CorespondanceId == id);
        }

        public async Task<IActionResult> RechercheCorespondanceSuiviNom(string recherche)
        {
            var Cores = from Core in _context.Corespondance
                     
                       //where Core.Suivi  == "Non"

                       select Core;
            if (!String.IsNullOrEmpty(recherche))
            {
                Cores = Cores.Where(e => e.NomComplet.Contains(recherche) || e.Institution.Contains(recherche) || e.CodeCorespondance.Contains(recherche));
            }


            return View(await Cores.ToListAsync());

        }
        public async Task<IActionResult> ListeCorespondanceNonSuivie()
        {
            var cor = from co in _context.Corespondance
                      where co.Suivi == "Non"
                      select co;
            return View (await cor.ToListAsync());
        }
        public async Task<IActionResult> SuivieCorespondance(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corespondance = await _context.Corespondance.FindAsync(id);
            if (corespondance == null)
            {
                return NotFound();
            }
            return View(corespondance);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuivieCorespondance(int id, [Bind("CorespondanceId,NomComplet,Institution,Objet,Telephone,Email,Daterecu,Destination,User,Suivi,Remarque,CodeCorespondance")] Corespondance corespondance)
        {
             
            if (id != corespondance.CorespondanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corespondance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorespondanceExists(corespondance.CorespondanceId))
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
            return View(corespondance);
        }


    }
}
