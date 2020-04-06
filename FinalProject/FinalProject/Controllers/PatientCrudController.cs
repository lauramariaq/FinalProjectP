using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class PatientCrudController : Controller
    {
        // GET: Crud
        public ActionResult EditarPaciente()
        {
            return View();
        }

        public ActionResult EliminarPaciente()
        {
            return View();
        }
    }
}