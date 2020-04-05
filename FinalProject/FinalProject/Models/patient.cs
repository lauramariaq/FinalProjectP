using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FinalProject.Models
{
    public class patient
    {
        [Required(ErrorMessage = "ID required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "cedula required")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "insurance required")]
        public bool insurance { get; set; }
    }
}