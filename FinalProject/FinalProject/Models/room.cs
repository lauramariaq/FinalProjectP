using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class room
    {
        [Required(ErrorMessage = "ID required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "numero required")]
        public int numero { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string tipo { get; set; }

        [Required(ErrorMessage = " precio required")]
        public int precio { get; set; }
    }
}