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
        public async Task<IActionResult> Create([Bind("CongeId,EmployeId,TypeConge,DebutConge,FinConge,ReprendreService,Observation,User,Nom,Prenom,Emploi,Service,NifCin")] Conge conge)
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
        public async Task<IActionResult> Edit(int id, [Bind("CongeId,TypeConge,DebutConge,FinConge,ReprendreService,Observation,EmployeId,User,Nom,Prenom,Emploi,Service,NifCin")] Conge conge)
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



       
        public async Task<IActionResult> ListeDesEmployesEnConge()
        {

            
            var Cong = from con in _context.Conge
                       where  con.FinConge.Date<=DateTime.Today.Date orderby con.DebutConge descending
                       select con;
            //if (!String.IsNullOrEmpty(recherche))
            //{
            //    Empl = Empl.Where(e => e.Emploi.Contains(recherche) || e.Service.Contains(recherche) || e.Nom.Contains(recherche) || e.Prenom.Contains(recherche));
            //}


            //ViewBag.MaxStorage = Convert.ToInt32((from s in db.storage
            //                                      where s.ID == id
            //                                      select s.AdditionalStorageMax).FirstOrDefault());

            return View(await Cong.ToListAsync());
        }

        public async Task<IActionResult> FueilleDeConge(int? id)
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





















        //public async Task<IActionResult> CongePourAnneEnCour(string recherche, DateTime date)
        //{

        //    var Cong = from con in _context.Conge
        //               where con.FinConge.Date <= DateTime.Today.Date
        //               select con;
        //    if (!String.IsNullOrEmpty(recherche))
        //    {
        //        Cong = Cong.Where((e => e.Nom.Contains(recherche) || e.Prenom.Contains(recherche) && e.DebutCongeContains(recherche) || e.Prenom.Contains(recherche));
        //    }
        //    return View(await Cong.ToListAsync());

        //}
    }
}

//public IEnumerable<object> Paging(int page)
//{
//    int t = (page - 1) * 10;
//    DB db = new DB();

//    //var q = db.Books.Skip(t).Take(10).ToList();

//    var q = (from i in db.Books
//             select new
//             {
//                 i.id,
//                 i.BookName,
//                 i.Writer,
//                 i.BookcategFK.BookCategori,
//                 i.inventory,
//                 i.BannerImage,

//             }
//             ).Skip(t).Take(10).ToList();

//    return q;
//}