using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class altas
    {
        [Required(ErrorMessage = "id required")]
        public int id { get; set; }

        [Required(ErrorMessage = "IDIngreso required")]
        public int idIngreso { get; set; }

        [Required(ErrorMessage = "monto required")]
        public int  monto { get; set; }

    }
}