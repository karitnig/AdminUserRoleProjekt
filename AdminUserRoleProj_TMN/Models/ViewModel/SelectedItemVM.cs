using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminUserRoleProj_TMN.Models.ViewModel
{
    public class SelectedItemVM
    {
        [Key]
        public object ValueMember { get; set; }

        public object DisplayMember { get; set; }
    }
}