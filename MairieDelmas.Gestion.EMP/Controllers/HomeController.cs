using MairieDelmas.Gestion.EMP.Data;
using MairieDelmas.Gestion.EMP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MairieDelmas.Gestion.EMP.Models.Employe;

namespace MairieDelmas.Gestion.EMP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Authorize]
        public async Task<IActionResult> Index( string recherche)
        {
           
            
                var Empl = from Emp in _context.Employe where Emp.Etat=="Actif" 
                           orderby Emp.Nom ascending
                           select Emp ;

     
            ViewBag.MaxStorage = Convert.ToInt32((from comp in _context.Employe
                                                  where comp.Etat == "Actif"
                                                  select comp).Count());

            return View(await Empl.ToListAsync());
            
            //return View(await _context.Employe.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
