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
    public class negociodocumento
    {
        datosdocumento ejecutar = new datosdocumento();

        public void GuardarDocumento(DOCUMENTO docu)
        {
            ejecutar.InsertarDocumento(docu);
        }

        public List<DOCUMENTO> MostrarDatos()
        {
            return ejecutar.ListarDocumentos().ToList();
        }

        public List<SelectListItem> llenarlista()
        {
            return ejecutar.Listardepartamento().ToList();

        }

        public List<SelectListItem> llenarlistacedu()
        {
            return ejecutar.ListarCedula().ToList();

        }

    }
}