using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GVB.Models
{
    [Table("State")]
    public class State
    {
        [Key]
        public int StateID { get; set; }

        [DisplayName("State")]
        public string StateName { get; set; }
    }
}