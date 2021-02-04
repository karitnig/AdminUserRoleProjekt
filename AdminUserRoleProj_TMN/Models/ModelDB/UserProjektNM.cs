using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminUserRoleProj_TMN.Models.ModelDB
{
    public class UserProjektNM
    {
        [Key, ForeignKey("Projekt"), Column(Order = 0)]
        public int ProjektID { get; set; }
        public virtual Projekt Projekt { get; set; }

        [Key, ForeignKey("ApplicationUser"), Column(Order = 1)]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}