using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MairieDelmas.Gestion.EMP.Models.Corespondance
{
    public class Corespondance
    {
        public int CorespondanceId { get; set; }
        public string CodeCorespondance { get; set; }
        [Display(Name = "Nom Complet ")]
        public string NomComplet { get; set; }
        public string  Institution { get; set; }
        [Required]
        public string  Objet { get; set; }
        public string  Telephone { get; set; }
        public string  Email { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Recu ")]
        public DateTime  Daterecu { get; set; }
        public string  Destination { get; set; }
         
        public string User { get; set; }
        public string  Suivi { get; set; }
        public string  Remarque { get; set; }
    }
}
