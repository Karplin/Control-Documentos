using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion.Controllers
{
    public class DocumentosController : Controller
    {
        negociodocumento negocio = new negociodocumento();
        
        // GET: Documentos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewData["items"] = negocio.llenarlista();
            ViewData["item"] = negocio.llenarlistacedu();
            return View();
        }

        [HttpPost]
        public ActionResult Create(DOCUMENTO parametro)
        {
            ViewData["items"] = negocio.llenarlista();
            ViewData["item"] = negocio.llenarlistacedu();
            negocio.GuardarDocumento(parametro);

            return View();

        }

        public ActionResult redocumentos()
        {
            return View(negocio.MostrarDatos());
        }
    }
}