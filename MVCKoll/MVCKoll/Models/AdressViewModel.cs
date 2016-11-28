using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKoll.Models
{
    public class AdressViewModel
    {
        public Guid id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Telefonnr{ get; set; }
        public DateTime Date { get; set; }

    }
}