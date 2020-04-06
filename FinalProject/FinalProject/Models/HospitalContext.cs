using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FinalProject.Models
{
    public class HospitalContext:DbContext
    {
        public HospitalContext()
            : base("cadena")
        { }

        public DbSet<patient> Patients { get; set; }
        public DbSet<consulta> Consultas { get; set; }
        public DbSet<doctor> doctors { get; set; }
        public DbSet<room> rooms { get; set; }
        public DbSet<ingresos> ingresos { get; set; }
        public DbSet<altas> altas { get; set; }
    }
}