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
      //  [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employe.ToListAsync());
        }
        //Random co = new Random();
        //string code = string.Format("EMP-MD-{0}{1}{2}", co.Next(0, 9), co.Next(0, 9), co.Next(1, 999), DateTime.Now.Millisecond);

        // GET: Employes/Details/5
       // [Authorize]
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
     //   [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeId,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat,User,DatechangementEtat,Remarque")] Employe employe)
        {
            Random co = new Random();
            string code = string.Format("EMP-MD-{0}{1}{2}", co.Next(0, 9), co.Next(0, 99), co.Next(1, 999), DateTime.Now.Millisecond);

            if (ModelState.IsValid)
            {
                
                employe .CodeEmp = code;
                employe.Etat = "Actif";
                _context.Add(employe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Recherche));
            }
            return View(employe);
        }
     //   [Authorize]
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
     //   [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeId,CodeEmp,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat,User,DatechangementEtat,Remarque")] Employe employe)
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
      //  [Authorize]
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
       // [Authorize]
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
                       where Emp.Etat == "Actif"
                       select Emp;
            ViewBag.MaxStorage = Convert.ToInt32((from comp in _context.Employe
                                                  where comp.Etat == "Actif"
                                                  select comp).Count());
            if (!String.IsNullOrEmpty(recherche))
            {
                Empl = Empl.Where(e => e.Nom!.Contains(recherche)||e.Prenom!.Contains(recherche) );
            }


            return View(await Empl.ToListAsync());

        }
       // [Authorize]
        [HttpGet]
        public async Task<IActionResult> RechercheDocument(string recherche)
        {
            var Empl = from Emp in _context.Employe
                       where Emp.Etat == "Actif"

                       select Emp;
            if (!String.IsNullOrEmpty(recherche))
            {
                Empl = Empl.Where(e => e.Nom.Contains(recherche) || e.Prenom.Contains(recherche)||e.NIFCIN.Contains(recherche));
            }
         

            return View(await Empl.ToListAsync());

        }



      //  [Authorize]
        public  async   Task<IActionResult> CongeEmp(int? id )
        {
           
            if (id == null)
            {
                return NotFound();
            }
            Employe employe = await _context.Employe
                  .FirstOrDefaultAsync(m => m.EmployeId == id);
            ViewBag.EmployeId = id;
            ViewData["Employe"] = employe;



            return View();
        }

       // [Authorize]
        public async Task<IActionResult> RechercheEmployeActif(string recherche)
        {
            var Empl = from Emp in _context.Employe
                       where Emp.Etat == "Actif"
                       select Emp;
            
            if (!String.IsNullOrEmpty(recherche))
            {
                Empl = Empl.Where(e => e.Emploi.Contains(recherche) ||e.Service.Contains(recherche) ||e.Nom.Contains(recherche) ||e.Prenom.Contains(recherche));
            }


            return View(await Empl.ToListAsync());

        }
       // [Authorize]
        public async Task<IActionResult> AutreInformation (string recherche)
        {
            var Empl = from Emp in _context.Employe
                   where    Emp.Etat == "Actif"
                       select Emp ;
            if (!String.IsNullOrEmpty(recherche))
            {
                Empl = Empl.Where(e => e.Allergies.Contains(recherche) ||e.Nom.Contains(recherche)||e.Prenom.Contains(recherche)||e.CompteBancaireBNC.Contains (recherche ));
            }


            return View(await Empl.ToListAsync());

        }
      //  [Authorize]
        public async Task<IActionResult> ListerNom()
        {
            var Empl = from Emp in _context.Employe
                       where Emp.Etat == "Actif"
                       orderby Emp.Nom ascending

                       select Emp;

            return View(await Empl.ToListAsync());
        }

      //  [Authorize]
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
            
            ViewBag.Poste = from po in _context.Poste

                            select po;
            ViewBag.Service = from se in _context.Service

                              select se;

            return View(employe);
        }
    //    [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnregistrerInfoComplementaire(int id, [Bind("EmployeId,CodeEmp,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat,User,DatechangementEtat,Remarque")] Employe employe)
        {
            if (id != employe.EmployeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employe.Etat = "Actif";
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
       // [Authorize]
        public async Task<IActionResult> EnregistrerAutreInformation(int id, [Bind("EmployeId,CodeEmp,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat,User,DatechangementEtat,Remarque")] Employe employe)
        {
            if (id != employe.EmployeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employe.Etat = "Actif";
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
      //  [Authorize]
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
        public async Task<IActionResult> ModifierInfoPersonnelle(int id, [Bind("EmployeId,CodeEmp,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat,User,DatechangementEtat,Remarque")] Employe employe)
        {
            if (id != employe.EmployeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employe.Etat = "Actif";
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
        public async Task<IActionResult> ListerEmpConge()
        {
            var Conge1 = new Conge();

            var EmpConge = from Emp in _context.Employe
                           join Cong in _context.Conge on Emp.EmployeId equals Cong.EmployeId into Conge
                           select new { Emp.Nom, Emp.Prenom, Conge1.TypeConge , Conge1.DebutConge, Conge1.FinConge, Conge1.NombresJour, Conge1.ReprendreService};
            
            return View(await EmpConge.ToListAsync());

           
        }
       // [Authorize]
        public async Task<IActionResult> ListeEmployeEligibleConge( string recherche)
        {
            var ListeEmpEligible = from Emp in _context.Employe
                                   where Emp.Etat=="Actif" 
                                  select Emp ;

            if (!String.IsNullOrEmpty(recherche))
            {
                ListeEmpEligible = ListeEmpEligible.Where(e => e.Nom.Contains(recherche) || e.Prenom.Contains(recherche) || e.Service.Contains(recherche) || e.Emploi.Contains(recherche)||e.NIFCIN.Contains(recherche));
            }

            return View(await ListeEmpEligible.ToListAsync());
        }
        //pas encore implementer
       // [Authorize]
        public IActionResult NombreEmploye()
        {
          
            var ListeEmpEligible = (from Emp in _context.Employe

                                    select Emp).Count();
            return View(ListeEmpEligible);
        }
      //  [Authorize]
        public async Task<IActionResult> EmployeConge(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe
                .FirstOrDefaultAsync(m => m.EmployeId == id);

            Conge  cong = await _context.Conge.FirstOrDefaultAsync(m => m.EmployeId == id);
            ViewData["Conge"] = cong;
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        public async Task<IActionResult> ChangementEtat(int? id)
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
        public async Task<IActionResult> ChangementEtat(int id, [Bind("EmployeId,CodeEmp,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat,User,DatechangementEtat,Remarque")] Employe employe)
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


        public async Task<IActionResult> ListeEmployeInActif(string recherche)
        {
            var ListeEmpEligible = from Emp in _context.Employe
                                   where Emp.Etat == "Revoque" ||Emp.Etat=="Demissionner"||Emp.Etat=="Abandon" || Emp.Etat== "En Disponibilite" || Emp.Etat == "Decede"

                                   select Emp;

            ViewBag.EmplInactif = Convert.ToInt32((from comp in _context.Employe
                                                     where comp.Etat == "Revoque" || comp.Etat == "Demissionner" || comp.Etat == "Abandon" || comp .Etat == "En Disponibilite" || comp.Etat == "Decede"
                                                   select comp).Count());


            if (!String.IsNullOrEmpty(recherche))
            {
                ListeEmpEligible = ListeEmpEligible.Where(e => e.Nom.Contains(recherche) || e.Prenom.Contains(recherche) || e.Service.Contains(recherche) || e.Emploi.Contains(recherche) || e.NIFCIN.Contains(recherche) ||e.Etat.Contains(recherche));
            }

            return View(await ListeEmpEligible.ToListAsync());
        }

        public async Task<IActionResult> EnregistrerDocumentsEmp(int? id)
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
        //   [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnregistrerDocumentsEmp(int id, [Bind("EmployeId,CodeEmp,TypeContrat,Nom,Prenom,DateNaissance,LieudeNaissance,Nationalite,PaysdeNaissance,Adresse,SituationFamiliale,NombrePersaCharge,NombreEnfants,NIFCIN,Emploi,Service,Cadre,Telephone,Portable,Email,PersonneAPrevenir,PortablePersonneAPrevenir,Liens,CarteIdentification,CV,Photo,PermisConduire,Allergies,Gs,Maladies,Remarques,DatederniereVisite,DateEntreaLaMairie,CompteBancaireBNC,AutreFormation,EtudeEncour,Etat,User,DatechangementEtat,Remarque")] Employe employe)
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

        public async Task<IActionResult> PromotionEmploye(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Employe employe = await _context.Employe
                  .FirstOrDefaultAsync(m => m.EmployeId == id);
            ViewBag.EmployeId = id;
            ViewData["Promotion"] = employe;
            ViewBag.Poste = from po in _context.Poste

                            select po;
            ViewBag.Service = from se in _context.Service

                              select se;


            return View();
        }


        public async Task<IActionResult> CertificatDeTravail(int? id)
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



        public async Task<IActionResult> RechercheToutEmploye( string recherche)
        {
            var ListeEmpEligible = from Emp in _context.Employe
                                  
                                   select Emp;

            ViewBag.EmplInactif = Convert.ToInt32((from comp in _context.Employe
                                                   
                                                   select comp).Count());


            if (!String.IsNullOrEmpty(recherche))
            {
                ListeEmpEligible = ListeEmpEligible.Where(e => e.Nom.Contains(recherche) || e.Prenom.Contains(recherche) || e.NIFCIN.Contains(recherche) || e.Etat.Contains(recherche));
            }

            return View(await ListeEmpEligible.ToListAsync());
        }



        //public async Task<IActionResult> CertificatEmploye()
        //{

        //    return View();
        //}
    }

}
