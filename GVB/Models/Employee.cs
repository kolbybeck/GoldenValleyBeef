using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GVB.Models
{
    [Table("Employee")]
    public class Employee
    {

        [Key]
        [DisplayName("Employee ID")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "First name required")]
        [DisplayName("Employee First Name")]
        public String EmpFname { get; set; }

        [Required(ErrorMessage = "Last name required")]
        [DisplayName("Employee Last Name")]
        public String EmpLname { get; set; }

        [Required(ErrorMessage = "Phone number required")]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-###-####}")]
        public String EmpPhone { get; set; }

        [Required(ErrorMessage = "Please assign role")]
        [DisplayName("Role")]
        [ForeignKey("Roles")]
        public virtual int RoleID { get; set; }
        public virtual Roles Roles { get; set; }
    }
}