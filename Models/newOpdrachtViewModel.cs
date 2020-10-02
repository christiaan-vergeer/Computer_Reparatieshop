using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;

namespace Computer_Reparatieshop.Models
{
    public class newOpdrachtViewModel
    {

       
            [Required]
            [Display(Name = "Naam Opdracht")]
            public string Naam { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Startdatum")]
            public string Startdate { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Einddatum")]
            public string Enddate { get; set; }

            //[Required]
            //[DataType(DataType.Password)]
            //[Display(Name = "Confirm password")]
            //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            //public string ConfirmPassword { get; set; }
      



        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}