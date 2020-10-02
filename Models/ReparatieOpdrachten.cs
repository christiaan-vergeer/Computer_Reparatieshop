using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop.Models
{
    public class Reparatieopdrachten
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Startdate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Enddate { get; set; }

        public Status Status  { get;set; }


    }

    public enum Status
    {
        Pending,
        [Display(Name = "In Progress")]
        InProgress,
        [Display(Name = "Wating for parts")]
        WaitingForParts,
        Done
    } 
}