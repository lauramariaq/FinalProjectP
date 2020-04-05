using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class consulta
    {
        [Required(ErrorMessage = "id required")]
        public int id { get; set; }

        [Required(ErrorMessage = "Nombre del paciente required")]
        public string nPaciente { get; set; }

        [Required(ErrorMessage = "cedula required")]
        public string CedulaPaciente { get; set; }

        [Required(ErrorMessage = "Nombre del doctor required")]
        public string nDoctor { get; set; }

        [Required(ErrorMessage = "FechaHora required")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "FechaHora required")]
        public DateTime Hora { get; set; }

    }
}