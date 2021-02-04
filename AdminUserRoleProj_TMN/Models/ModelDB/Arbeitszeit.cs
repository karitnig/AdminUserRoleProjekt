using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminUserRoleProj_TMN.Models.ModelDB
{
    public class Arbeitszeit
    {
        [Key]
        public int ArbeitsZeitID { get; set; }

        [MaxLength(50)]
        public string Taetigkeit { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd:MM:yyyy HH:mm}")]
        [Display(Name = "Anfang-Reservierung")]
        public DateTime Anfang { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Ende-Reservierung")]
        public DateTime Ende { get; set; }

        [Display(Name = "Projektauswahl")]
        public int ProjektID { get; set; }
        public virtual ICollection<UserProjektNM> UserProjektNMs { get; set; }
    }
}