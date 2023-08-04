using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MairieDelmas.Gestion.EMP.Models.Conge;
using MairieDelmas.Gestion.EMP.Models.Employe;
using MairieDelmas.Gestion.EMP.Models.Corespondance;
using MairieDelmas.Gestion.EMP.Models.Doleance;
using MairieDelmas.Gestion.EMP.Models.Promotion;
using MairieDelmas.Gestion.EMP.Models.Service;
using MairieDelmas.Gestion.EMP.Models.Poste;
 
 
namespace MairieDelmas.Gestion.EMP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MairieDelmas.Gestion.EMP.Models.Conge.Conge> Conge { get; set; }
        public DbSet<MairieDelmas.Gestion.EMP.Models.Employe.Employe> Employe { get; set; }
        public DbSet<MairieDelmas.Gestion.EMP.Models.Corespondance.Corespondance> Corespondance { get; set; }
        public DbSet<MairieDelmas.Gestion.EMP.Models.Doleance.Doleance> Doleance { get; set; }
        public DbSet<MairieDelmas.Gestion.EMP.Models.Promotion.Promotion> Promotion { get; set; }
        public DbSet<MairieDelmas.Gestion.EMP.Models.Service.Service> Service { get; set; }
        public DbSet<MairieDelmas.Gestion.EMP.Models.Poste.Poste> Poste { get; set; }
         
      
        
    }
}
