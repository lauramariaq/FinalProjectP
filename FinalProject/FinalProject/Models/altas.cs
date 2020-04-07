using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class altas
    {
        [Required(ErrorMessage = "id required")]
        public int id { get; set; }


        public int ingresos_id { set; get; }
        [ForeignKey("ingresos_id")]
        public ingresos ingreso { get; set; }

        [Required(ErrorMessage = "monto required")]
        public int  monto { get; set; }

    }
}