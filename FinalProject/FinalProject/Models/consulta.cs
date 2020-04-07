using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class consulta
    {
        [Required(ErrorMessage = "id required")]
        public int id { get; set; }

        public int patient_ID { set; get; }
        [ForeignKey("patient_ID")]
        public patient patient { get; set; }

        [Required(ErrorMessage = "")]
        public int doctors_ID { set; get; }
        [ForeignKey("doctors_ID")]
        public doctor doctor { get; set; }

        [Required(ErrorMessage = "FechaHora required")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "FechaHora required")]
        public DateTime Hora { get; set; }



    }
}