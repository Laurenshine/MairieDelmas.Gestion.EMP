using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MairieDelmas.Gestion.EMP.Models.Poste
{
    public class Poste
    {
        public int PosteId { get; set; }
        [Required]
        public string NomPoste { get; set; }
        public string User { get; set; }
    }
}
