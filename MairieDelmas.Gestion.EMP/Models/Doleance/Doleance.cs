using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MairieDelmas.Gestion.EMP.Models.Doleance
{
    public class Doleance
    {
        public int DoleanceId { get; set; }
        public string  CodeDoleance { get; set; }
      
        [Display(Name = "Nom Complet ")]
        public string  NomComplet { get; set; }
        [Required]
        [Display(Name = "Doleance ")]
        public string  Demande { get; set; }
        public string  Telephone { get; set; }
        public string  Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDoloeance { get; set; }
        public string Service { get; set; }
        public string User { get; set; }
        public string  Suivi { get; set; }
        public string Remarque { get; set; }
    }
}
