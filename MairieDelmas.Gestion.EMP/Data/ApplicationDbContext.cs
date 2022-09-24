using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MairieDelmas.Gestion.EMP.Models.Conge;
using MairieDelmas.Gestion.EMP.Models.Employe;

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
    }
}
