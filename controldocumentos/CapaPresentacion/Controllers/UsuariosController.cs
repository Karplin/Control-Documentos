using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;


namespace CapaPresentacion.Controllers
{
    public class UsuariosController : Controller
    {

        negociousuario negocio = new negociousuario();
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string contrasena)
        {
            var user = negocio.verificar(correo, contrasena);
 

            if (user != null)
            {
                return View("Principal");
            }

            else
            {
                ViewBag.Mensaje = "Datos Incorrectos";
                return View();
            }

        }
      
        public ActionResult Create()
        {
            ViewData["items"] = negocio.llenarlista();

            return View();
        }

        [HttpPost]
        public ActionResult Create(USUARIO parametro)
        {
            ViewData["items"] = negocio.llenarlista();

            negocio.GuardarUsuario(parametro);
            return View();
        }

        public ActionResult config1()
        {
            ViewData["iteme"] = negocio.llenarlista();
            return View();
        }

        [HttpPost]
        public ActionResult config1(USUARIO parametro)
        {
            ViewData["iteme"] = negocio.llenarlista();
            negocio.GuardarUsuario(parametro);
            return View();

        }
   
        public ActionResult Principal()
        {
            return View();
        }

        public ActionResult Principal1()
        {
            return View();
        }

        public ActionResult Edit()
        {
          

            return View();
        }

    
        [HttpPost]
        public ActionResult Edit(USUARIO parametro)
        {
            negocio.ActualizarUsuario(parametro);
            return View();
        }


        public ActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(USUARIO parametro)
        {
            negocio.EliminarUsuario(parametro);
            return View();

        }

        public ActionResult Details()
        {
            return View(negocio.MostrarDatos());
        }

        public ActionResult GetDepartamento()
        {
            return View(negocio.MostrarDatos());
        }

        public ActionResult reusuarios()
        {
            return View(negocio.MostrarDatos());
        }

        public ActionResult Inicio()
        {
            return View();
        }

    }
}