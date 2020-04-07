using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class ingresos
    {
        [Required(ErrorMessage = "id required")]
        public int id { get; set; }


        public int pacientes_ID { set; get; }
        [ForeignKey("pacientes_ID")]
        public patient paciente { get; set; }


        public int room_id { set; get; }
        [ForeignKey("room_id")]
        public room room { get; set; }

        [Required(ErrorMessage = "FechaInicio required")]
        public DateTime FechaInicio { get; set; }

    }
}