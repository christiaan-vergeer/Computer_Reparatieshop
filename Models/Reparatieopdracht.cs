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
    public class Reparatieopdracht
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
        public double price { get; set; }
        public string Details { get; set; } 

        public Status Status { get; set; }

        public virtual Klant Klant { get; set; }

        public virtual Reparateur Reparateur { get; set; }

        public virtual ICollection<ComputerPart> ComputerParts { get; set; }

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