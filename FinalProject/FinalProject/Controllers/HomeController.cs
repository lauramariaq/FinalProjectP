﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Servicios;
using FinalProject.Models;
namespace FinalProject.Controllers
{
    public class HomeController : Controller
    { 
        private readonly MantenimientoServicios servicios;

        public HomeController()
        {
            HospitalContext context = new HospitalContext();
            servicios = new MantenimientoServicios(context);
        }
        public HomeController(MantenimientoServicios _servicios)
        {
            servicios = _servicios;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPatient()
        {

            return Redirect("/patients/index");
        }

        public ActionResult AddDoctor()
        {
            return Redirect("/doctors/index");
        }

        public ActionResult AddRoom()
        {
            return Redirect("/rooms/index");
        }

        public ActionResult Consulta()
        {
            return Redirect("/consultas1/index");
        }

        //[HttpPost]
        //public ActionResult AddDoctor(doctor p)
        //{
        //    ViewBag.result = servicios.AgregarDoctor(p);
        //    ViewBag.listadoc = servicios.TenerDoc();   
        //    return View(p);
        //}
    }
}