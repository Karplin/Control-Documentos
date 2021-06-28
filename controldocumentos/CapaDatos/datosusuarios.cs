using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CapaDatos
{
    public class datosusuarios
    {
        documentobdEntities1 db = new documentobdEntities1();
        public void InsertarEstudiante(USUARIO usu)
        {
                db.USUARIOS.Add(usu);
                db.SaveChanges();
        }
        public List<USUARIO> ListarUsuarios()
        {
            return db.USUARIOS.ToList();
        }

        public USUARIO verificar(string correo, string contrasena)
        {
           var usuario = db.USUARIOS.FirstOrDefault(x=>x.Correo == correo && x.Contrasena == contrasena);

           return usuario;

        }

        public List<SelectListItem> Listardepartamento()
        {
            List<DEPARTAMENTO> lst = null;

            using(documentobdEntities1 dbx = new documentobdEntities1()) 
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

          public void ActualizarUsuario(USUARIO usu)
          {
              var actualiza = db.USUARIOS.First(a => a.IdUsuario == usu.IdUsuario);
              actualiza.Contrasena = usu.Contrasena;
              db.SaveChanges();

          }
          public void BorrarUsuario(USUARIO usu)
          {
              var borrar = db.USUARIOS.FirstOrDefault(z => z.IdUsuario == usu.IdUsuario);
              db.USUARIOS.Remove(borrar);
              db.SaveChanges();

          }

        public List<DEPARTAMENTO> GetDEPARTAMENTOs()
        {
            List<DEPARTAMENTO> lista = db.DEPARTAMENTOes.ToList();

            return lista;
        }


    }
}
