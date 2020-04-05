using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class ingresos
    {
        [Required(ErrorMessage = "id required")]
        public int id { get; set; }

        [Required(ErrorMessage = "Nombre paciente required")]
        public int nPaciente { get; set; }

        [Required(ErrorMessage = "#habitacion required")]
        public int NHabitacion { get; set; }

        [Required(ErrorMessage = "FechaInicio required")]
        public DateTime FechaInicio { get; set; }

    }
}