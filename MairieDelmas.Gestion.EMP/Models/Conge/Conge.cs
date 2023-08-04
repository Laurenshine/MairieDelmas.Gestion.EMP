using MairieDelmas.Gestion.EMP.Models.Employe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MairieDelmas.Gestion.EMP.Models.Conge
{
    public   class Conge
    {
        public int CongeId { get; set; }
        [ForeignKey("EmployeId")]
        public int EmployeId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Emploi { get; set; }
        public string Service { get; set; }
        public string NifCin { get; set; }
        public string TypeConge { get; set; }
        [DataType(DataType.Date)]
        public DateTime DebutConge { get; set; }
        [DataType(DataType.Date)]
        public DateTime FinConge { get; set; }
       [NotMapped]
        public int NombresJour { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReprendreService { get; set; }
        [DataType(DataType.MultilineText)]
        public string Observation { get; set; }
        public string User { get; set; }

         



    }
}
