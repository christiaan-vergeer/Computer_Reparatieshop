using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Computer_Reparatieshop.Models
{
    public class Reparatieopdrachten
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Startdate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Enddate { get; set; }
        public string details { get; set; } 

        public Status Status { get; set; }

    }

    public enum Status
    {
        Pending,
        [Display(Name = "In Progress")]
        InProgress,
        [Display(Name = "Waiting for parts")]
        WaitingForParts,
        Done
    }
    


}