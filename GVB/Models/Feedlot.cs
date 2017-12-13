using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GVB.Models
{
    [Table("Feedlot")]
    public class Feedlot
    {
        [Key]
        public int feedlotID { get; set; }

        [Required(ErrorMessage = "Please enter a feedlot name")]
        [DisplayName("Feedlot Name")]
        public String fName { get; set; }
    }
}