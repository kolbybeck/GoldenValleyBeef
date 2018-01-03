using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GVB.Models
{
    [Table("Dairy")]
    public class Dairy
    {

        [Key]
        [DisplayName("Dairy ID")]
        public int dairyID { get; set; }

        [Required(ErrorMessage = "Dairy name required")]
        [DisplayName("Dairy Name")]
        public String dName { get; set; }

        [Required(ErrorMessage = "Address required")]
        [DisplayName("Address")]
        public String dAddress { get; set; }

        [Required(ErrorMessage = "City required")]
        [DisplayName("City")]
        public String dCity { get; set; }


        [Required(ErrorMessage = "State required")]
        [DisplayName("State")]
        [ForeignKey("State")]
        public virtual int StateID { get; set; }
        public virtual State State { get; set; }


        [Required(ErrorMessage = "Zip required")]
        [DisplayName("Zip")]
        [DataType(DataType.PostalCode)]
        public string dZip { get; set; }

        [Required(ErrorMessage = "Phone number required")]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        public String dPhone { get; set; }

    }
}