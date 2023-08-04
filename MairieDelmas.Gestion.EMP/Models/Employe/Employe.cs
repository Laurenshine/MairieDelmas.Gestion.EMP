using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MairieDelmas.Gestion.EMP.Models.Conge;

namespace MairieDelmas.Gestion.EMP.Models.Employe
{
    public class Employe
    {
        public int EmployeId { get; set; }

        public string CodeEmp { get; set; }
        [Required]
        [Display(Name = "Type de Contrat")]
        public string TypeContrat { get; set; }
        [Required]
        public string Nom { get; set; }
        [Display(Name = "Prénom")]
        [Required]
        public string Prenom { get; set; }
        [Required]
        [Display(Name = "Date Naissance")]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        [Required]
        [Display(Name = "Lieu de Naiss")]
        public string LieudeNaissance { get; set; }
        [Required]
        [Display(Name = "Nationalité")]
        public string Nationalite { get; set; }
        [Required]
        [Display(Name = "Pays de Naissance")]
        public string PaysdeNaissance { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Adresse { get; set; }
        [Display(Name = "Statut")]
        public string SituationFamiliale { get; set; }
        [Display(Name = "Nbs Pers en Charge")]
        public int? NombrePersaCharge { get; set; }
        [Display(Name = "Nbs d'Enfants")]
        public int? NombreEnfants { get; set; }
        [Required]
        [Display(Name = "NIF/CIN")]
        public string NIFCIN { get; set; }
        [Display(Name = "Poste")]
        public string Emploi { get; set; }
        public string Service { get; set; }

        public string Cadre { get; set; }
        #region InformationComplementaires
        
         
        [Display(Name = "Téléphone")]
        
        public string Telephone { get; set; }
        public string Portable { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Cet Email n'est pas valid.")]
        public string Email { get; set; }
        [Display(Name = "Personne a Prevenir en cas d'accident")]
        public string PersonneAPrevenir { get; set; }
 
        [Display(Name = "Téléphone de la Personne")]
        
        public string PortablePersonneAPrevenir { get; set; }
      //  [Display(Name = "Liens avec cette personne")]
        public string Liens { get; set; }

        #endregion

        #region documentDemander
        
        public string CarteIdentification { get; set; }
        public string CV { get; set; }
        public string Photo { get; set; }
        public string PermisConduire { get; set; }
        #endregion

        #region AutreInformations

        public string Allergies { get; set; }
        [Display(Name = "Groupe Sanguin")]
        public string Gs { get; set; }
        public string Maladies { get; set; }
        public string Remarques { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date derniere Visite ")]
        public DateTime DatederniereVisite { get; set; }
       

        [Display(Name = "Date d'enbauche")]
        [DataType(DataType.Date)]
        public DateTime DateEntreaLaMairie { get; set; }

        [Display(Name = "No Compte")]
        public string CompteBancaireBNC { get; set; }
        [Display(Name = "Autre Formation")]
        public string AutreFormation { get; set; }

        public string EtudeEncour { get; set; }
        public string Etat { get; set; }
        #endregion
        public string  User { get; set; }

        [DataType(DataType.Date)]
        public string  DatechangementEtat { get; set; }
        public string  Remarque { get; set; }

    }
}
