using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GVB.Models
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Please enter a role description")]
        [DisplayName("Role Description")]
        public String RoleDescr { get; set; }

    }
}