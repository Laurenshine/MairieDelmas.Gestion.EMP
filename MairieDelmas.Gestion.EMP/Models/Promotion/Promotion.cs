using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MairieDelmas.Gestion.EMP.Models.Promotion
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public string  Nom { get; set; }
        public string  Prenom { get; set; }
        public string  NifCIn { get; set; }
        public string  AncienPoste { get; set; }
        public string  AncienService { get; set; }
        [Required]
        public string NouveauPoste { get; set; }
        [Required]
        public string  NouveauService { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DatePromotion { get; set; }
        public string  RemarquePromotion { get; set; }
        public string User { get; set; }
        [ForeignKey("EmployeId")]
        public int EmployeId { get; set; }
    }
}
