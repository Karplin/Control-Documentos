using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class negociousuario
    {
        documentobdEntities1 db = new documentobdEntities1();

        datosusuarios ejecutar = new datosusuarios();
       

        public void GuardarUsuario(USUARIO usu)
        {
            ejecutar.InsertarEstudiante(usu);
        }
        public List<USUARIO> MostrarDatos()
        {
            return ejecutar.ListarUsuarios().ToList();
        }

        public USUARIO verificar(string correo, string contrasena)
        {
            return ejecutar.verificar(correo, contrasena);

        }

        public List<SelectListItem> llenarlista()
        {
            return ejecutar.Listardepartamento().ToList();

        }
        public void ActualizarUsuario(USUARIO usu)
        {
            ejecutar.ActualizarUsuario(usu);
        }
        public void EliminarUsuario(USUARIO usu)
        {
            ejecutar.BorrarUsuario(usu);
        }


        public List<DEPARTAMENTO> Getdeparta()
        {
            return ejecutar.GetDEPARTAMENTOs().ToList();
        }
    }
}

