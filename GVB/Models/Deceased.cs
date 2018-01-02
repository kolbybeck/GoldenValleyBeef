using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GVB.Models
{
    [Table("Deceased")]
    public class Deceased
    {

        [Key]
        public int CattleID { get; set; }

        [Required(ErrorMessage = "Cattle number required")]
        [DisplayName("Cattle Number")]
        [RegularExpression(@"^\d{1,5}$", ErrorMessage = "Please Enter in a Valid Cattle Number")]
        public String CattleNumber { get; set; }

        private DateTime _createdOn = DateTime.Now;

        [Display(Name = "Deceased Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DeceasedDate
        {
            get
            {
                return (_createdOn == DateTime.Now) ? DateTime.Now : _createdOn;
            }
            set { _createdOn = value; }
        }


        [ForeignKey("Dairy")]
        public virtual int ? DairyID { get; set; }
        public virtual Dairy Dairy { get; set; }


        [ForeignKey("Feedlot")]
        public virtual int ? FeedlotID { get; set; }
        public virtual Feedlot Feedlot { get; set; }


        [ForeignKey("Employee")]
        public virtual int ? EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }



    }
}