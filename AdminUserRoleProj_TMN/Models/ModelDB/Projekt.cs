using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminUserRoleProj_TMN.Models.ModelDB
{
    public class Projekt
    {
        [Key]
        public int ProjektID { get; set; }

        [MaxLength(50), Required(ErrorMessage = "Bitte einen Projektnamen eingeben")]
        public string ProjektName { get; set; }

        [MaxLength(500), Required(ErrorMessage = "Bitte Beschreibung eingeben")]
        public string ProjektDescription { get; set; }

        //Neu 15.1.21
        //Liste von AspNetUser
        [Display(Name = "User Auswahl")]
        public int Id { get; set; }

        //public virtual ICollection<ApplicationUser> collectionAspNetUser { get; set; }

        public virtual ICollection<UserProjektNM> UserProjektNMs { get; set; }
    }
}