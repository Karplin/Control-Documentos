using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion.Controllers
{
    public class DepartamentoController : Controller
    {
        negociodepa negocio = new negociodepa();

        // GET: Departamento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Principal()
        {
            return View();
        }

     

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DEPARTAMENTO parametro)
        {
            negocio.GuardarDepartamento(parametro);

            return View();

        }

        public ActionResult Edit()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Edit(DEPARTAMENTO parametro)
        {
            negocio.ActualizarDepartamento(parametro);
            return View();
        }


        public ActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(DEPARTAMENTO parametro)
        {
            negocio.EliminarDepartamento(parametro);
            return View();

        }

        public ActionResult Details()
        {
            return View(negocio.MostrarDatos());
        }

        public ActionResult redepartas()
        {

            return View(negocio.MostrarDatos());
        }

    }
}