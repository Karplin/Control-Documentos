using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CapaDatos
{
    public class datosdocumento
    {
        documentobdEntities1 db = new documentobdEntities1();
        public void InsertarDocumento(DOCUMENTO docu)
        {
            //AÑO
            int anio = DateTime.Now.Year;
            var fe = DateTime.Now;
            var fecha = fe.ToShortDateString();


            var siglao = string.Empty;
            var siglad = string.Empty;

            // ORIGEN DE

            siglao = Regex.Replace(docu.OrigenDepartamento, @"[\p{P}\p{S}\p{C}\p{N}]+", "");
            siglao = Regex.Replace(siglao, @"\p{Z}+", " ");
            siglao = Regex.Replace(siglao.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);
            siglao = Regex.Replace(siglao, @"^(\p{L})[^\s]*(?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L}*)?)?$", "$1$2").Trim();


            if (siglao.Length > 2)
            {
                siglao = siglao.Substring(0, 2);
            }

            siglao = siglao.ToUpperInvariant();


            // DESTINO DE

            siglad = Regex.Replace(docu.DestinoDepartamento, @"[\p{P}\p{S}\p{C}\p{N}]+", "");
            siglad = Regex.Replace(siglad, @"\p{Z}+", " ");
            siglad = Regex.Replace(siglad.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);
            siglad = Regex.Replace(siglad, @"^(\p{L})[^\s]*(?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L}*)?)?$", "$1$2").Trim();


            if (siglad.Length > 2)
            {
                siglad = siglad.Substring(0, 2);
            }

            siglad = siglad.ToUpperInvariant();


            // SEUENCIA
                int ultimo = 0;

            try
            {
                ultimo = db.DOCUMENTOS
                .OrderByDescending(x => x.IdDocumento)
                .First().IdDocumento;

                int secuencia = 1 + ultimo;

                string codigo = anio + "-" + siglao + "-" + siglad + "-" + secuencia;
                docu.Codigo = codigo;
                docu.Fecha = Convert.ToString(fecha);


            }
            catch
            {

                ultimo = 0;

                int secuencia = 1 + ultimo;

                string codigo = anio + "-" + siglao + "-" + siglad + "-" + secuencia;
                docu.Codigo = codigo;
                docu.Fecha = Convert.ToString(fecha);

            }
       

            db.DOCUMENTOS.Add(docu);
            db.SaveChanges();

        }

        public List<DOCUMENTO> ListarDocumentos()
        {
            return db.DOCUMENTOS.ToList();
        }


        public List<SelectListItem> Listardepartamento()
        {
            List<DEPARTAMENTO> lst = null;

            using (documentobdEntities1 dbx = new documentobdEntities1())
            {
                lst = (from d in dbx.DEPARTAMENTOes.AsEnumerable()
                       select new DEPARTAMENTO
                       {
                           IdDepartamento = d.IdDepartamento,
                           Nombre = d.Nombre
                       }).ToList();
            }

            //--------------------------------------------------------------------------
            List<SelectListItem> itemz = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Nombre.ToString(),
                    Selected = false

                };

            });

            return itemz;

        }

        public List<SelectListItem> ListarCedula()
        {
            List<USUARIO> lst = null;

            using (documentobdEntities1 dbx = new documentobdEntities1())
            {
                lst = (from d in dbx.USUARIOS.AsEnumerable()
                       select new USUARIO
                       {
                           IdUsuario = d.IdUsuario,
                           Cedula = d.Cedula
                       }).ToList();
            }

            //--------------------------------------------------------------------------
            List<SelectListItem> itemz = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Cedula.ToString(),
                    Value = d.Cedula.ToString(),
                    Selected = false

                };

            });

            return itemz;

        }




        /*  public void ActualizarUsuario(USUARIO usu)
          {
              var actualiza = db.USUARIOS.First(a => a.IdUsuario == usu.IdUsuario);

              db.SaveChanges();

          }
          public void BorrarUsuario(USUARIO usu)
          {
              var borrar = db.USUARIOS.FirstOrDefault(z => z.IdUsuario == usu.IdUsuario);
              db.USUARIOS.Remove(borrar);
              db.SaveChanges();

          }*/

    }
}