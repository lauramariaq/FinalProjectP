using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models;
namespace FinalProject.Servicios
{

    public class MantenimientoServicios
    {
        private readonly HospitalContext context;

        public  MantenimientoServicios(HospitalContext _context) {

            context = _context;
        }

        public  List<doctor> TenerDoc() {
            var result = context.doctors.ToList();

            return result;
        }

        public bool AgregarDoctor(doctor doc) {

            try
            {
               var result = context.doctors.Where(x => x.ID == doc.ID).FirstOrDefault();  
                if (result == null)
                {
                    context.doctors.Add(doc);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;

                }
            } catch(Exception e)
            {
                return false;
            }
          
         }

        public bool EditarDoctor(doctor doc)
        {
            try
            {
                var result = context.doctors.Where(x => x.ID == doc.ID).FirstOrDefault();
                result.Name = doc.Name;
                result.cedula = doc.cedula;
                result.Especialidad = doc.Especialidad;
                result.exequatur = doc.exequatur;
                context.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false; 
            }
        }


    }


}