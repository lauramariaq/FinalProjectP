using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class doctor
    {
        [Required(ErrorMessage = "ID required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "cedula required")]
        public string cedula { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = " exequatur required")]
        public String exequatur { get; set; }

        [Required(ErrorMessage = " Especialidad required")]
        public String Especialidad { get; set; }
    
    }
}