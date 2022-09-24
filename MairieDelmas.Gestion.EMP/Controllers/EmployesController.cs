using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MairieDelmas.Gestion.EMP.Data;
using MairieDelmas.Gestion.EMP.Models.Employe;
using Microsoft.AspNetCore.Authorization;
using MairieDelmas.Gestion.EMP.Models.Conge;

namespace MairieDelmas.Gestion.EMP.Controllers
{
    public class EmployesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employe.ToListAsync());
        }
        //Random co = new Random();
        //string code = string.Format("EMP-MD-{0}{1}{2}", co.Next(0, 9), co.Next(0, 9), co.Next(1, 999), DateTime.Now.Millisecond);

        // GET: Employes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe
                .FirstOrDefaultAsync(m => m.EmployeId == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // GET: Employes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeId,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour")] Employe employe)
        {
            Random co = new Random();
            string code = string.Format("EMP-MD-{0}{1}{2}", co.Next(0, 9), co.Next(0, 99), co.Next(1, 999), DateTime.Now.Millisecond);

            if (ModelState.IsValid)
            {
                
                employe .CodeEmp = code;
                employe.Etat = "Actif";
                _context.Add(employe);
                await _context.SaveChangesAsync();
                return View(employe);
            }
            return View(employe);
        }

        // GET: Employes/Edit/5
       // [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            return View(employe);
        }

        // POST: Employes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeId,CodeEmp,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat")] Employe employe)
        {
            if (id != employe.EmployeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(employe.EmployeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Recherche));
            }
            return View(employe);
        }
     //   [Authorize]
        // GET: Employes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe
                .FirstOrDefaultAsync(m => m.EmployeId == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employe = await _context.Employe.FindAsync(id);
            _context.Employe.Remove(employe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Recherche));
        }

        private bool EmployeExists(int id)
        {
            return _context.Employe.Any(e => e.EmployeId == id);
        }

       // [Authorize]
        [HttpGet]
        public async Task<IActionResult> Recherche(string recherche)
        {
            var Empl = from Emp in _context.Employe
                       select Emp;
            if (!String.IsNullOrEmpty(recherche))
            {
                Empl = Empl.Where(e => e.Nom!.Contains(recherche)||e.Prenom!.Contains(recherche) );
            }


            return View(await Empl.ToListAsync());

        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> RechercheInfoPersonel(string recherche)
        {
            var Empl = from Emp in _context.Employe
                      
                       select Emp;
            if (!String.IsNullOrEmpty(recherche))
            {
                Empl = Empl.Where(e => e.Nom!.Contains(recherche) || e.Prenom!.Contains(recherche));
            }


            return View(await Empl.ToListAsync());

        }
        //public async Task<IActionResult> RechercheConge(string recherche)
        //{
        //    var Empl = from Emp in _context.Employe from con in _context.Conge
        //               select con;
        //    if (!String.IsNullOrEmpty(recherche))
        //    {
        //        Empl = Empl.Where(e => e.EmployeId==e.EmployeId);
        //    }


        //    return View(await Empl.ToListAsync());

        //}


       
        public    IActionResult CongeEmp(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }
            // ViewBag.Emp = id;
            //var employe = await _context.Employe.FindAsync(id);
            ViewBag.EmployeId = id;

            return View();
        }
      
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CongeEmp1([Bind("CongeId,EmployeId,DebutConge,FinConge,ReprendreService,Observation")] Conge conge)
        //{
           
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(conge);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(CongeEmp1));
        //    }            
            
        //    return RedirectToAction(nameof(Recherche));
        //}

        public async Task<IActionResult> RechercheEmployeActif(string recherche)
        {
            var Empl = from Emp in _context.Employe
                       select Emp;
            if (!String.IsNullOrEmpty(recherche))
            {
                Empl = Empl.Where(e => e.Emploi!.Contains(recherche) ||e.Service.Contains(recherche) ||e.Nom.Contains(recherche) ||e.Prenom.Contains(recherche));
            }


            return View(await Empl.ToListAsync());

        }

        public async Task<IActionResult> AutreInformation (string recherche)
        {
            var Empl = from Emp in _context.Employe
                       select Emp ;
            if (!String.IsNullOrEmpty(recherche))
            {
                Empl = Empl.Where(e => e.Allergies.Contains(recherche) ||e.Nom.Contains(recherche)||e.Prenom.Contains(recherche)||e.CompteBancaireBNC.Contains (recherche ));
            }


            return View(await Empl.ToListAsync());

        }
        public async Task<IActionResult> ListerNom()
        {
            var Empl = from Emp in _context.Employe orderby Emp.Nom ascending
                       select Emp;

            return View(await Empl.ToListAsync());
        }


        public async Task<IActionResult> EnregistrerInfoComplementaire(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var employe = await _context.Employe.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            return View(employe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnregistrerInfoComplementaire(int id, [Bind("EmployeId,CodeEmp,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat")] Employe employe)
        {
            if (id != employe.EmployeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(employe.EmployeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(RechercheEmployeActif));
            }
            return View(employe);
        }
        public async Task<IActionResult> EnregistrerAutreInformation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var employe = await _context.Employe.FindAsync(id);
           
            if (employe == null)
            {
                return NotFound();
            }
            return View(employe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnregistrerAutreInformation(int id, [Bind("EmployeId,CodeEmp,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat")] Employe employe)
        {
            if (id != employe.EmployeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(employe.EmployeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AutreInformation));
            }
            return View(employe);
        }

        public async Task<IActionResult> ModifierInfoPersonnelle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            return View(employe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifierInfoPersonnelle(int id, [Bind("EmployeId,CodeEmp,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat")] Employe employe)
        {
            if (id != employe.EmployeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(employe.EmployeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Recherche));
            }
            return View(employe);
        }

        public async Task<IActionResult> ListerEmpConge()
        {
            var Conge1 = new Conge();

            var EmpConge = from Emp in _context.Employe
                           join Cong in _context.Conge on Emp.EmployeId equals Cong.EmployeId into Conge
                           select new { Emp.Nom, Emp.Prenom, Conge1.TypeConge , Conge1.DebutConge, Conge1.FinConge, Conge1.NombresJour, Conge1.ReprendreService};

            return View(await EmpConge.ToListAsync());

           
        }
    }

}
