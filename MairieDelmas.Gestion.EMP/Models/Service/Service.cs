using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MairieDelmas.Gestion.EMP.Models.Service
{
    public class Service
    {
        public int ServiceId { get; set; }
        [Required]
        public string  NomService { get; set; }
        public string User  { get; set; }
    }
}
