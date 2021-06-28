using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaServicios;



namespace CapaPresentacion.Controllers
{
    public class ReportesController : Controller
    {
        DocumentosServicios servicio = new DocumentosServicios();

        public ActionResult Index()
        {
            return View();
        }

 
        public ActionResult redepartas()
        {
            return View();
        }

        public ActionResult redocumentos()
        {
            return View();
        }

        //GENERADO POR EMPLEADO
        public ActionResult Busquedaemple()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Resultadoemple(string Cedula)
        {
            return View(servicio.BuscaDcumento(Cedula));
        }

        //Departamento - ORIGEN
        public ActionResult Busquedadepartaori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult resultadepartaori(string departa)
        {
            return View(servicio.Buscardepaori(departa));
        }

        public ActionResult Busquedadepartadesti()
        {
            return View();
        }

        [HttpPost]
        public ActionResult resultadepartadesti(string departadestino)
        {
            return View(servicio.Buscardepadesti(departadestino));
        }
        public ActionResult Busquedadepafecha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult resultadodepafecha(string fechaini, string fechafinal)
        {
            return View(servicio.Buscarfecha(fechaini, fechafinal));
        }



    }
}