using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
   public class datosdepartamento
    {
        documentobdEntities1 db = new documentobdEntities1();

        public void Insertardepartamento(DEPARTAMENTO depa)
        {

            string sigla = Regex.Replace(depa.Nombre, @"[\p{P}\p{S}\p{C}\p{N}]+", "");
            sigla = Regex.Replace(sigla, @"\p{Z}+", " ");
            sigla = Regex.Replace(sigla.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);
            sigla = Regex.Replace(sigla, @"^(\p{L})[^\s]*(?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L}*)?)?$", "$1$2").Trim();


            if (sigla.Length > 2)
            {
                sigla = sigla.Substring(0, 2);
            }

            sigla = sigla.ToUpperInvariant();

            depa.Siglas = sigla;

            db.DEPARTAMENTOes.Add(depa);
            db.SaveChanges();
        }

        public void Actualizardepartamento(DEPARTAMENTO depa)
        {
            var actualiza = db.DEPARTAMENTOes.First(a => a.IdDepartamento == depa.IdDepartamento);
            actualiza.Nombre = depa.Nombre;

            string sigla = Regex.Replace(actualiza.Nombre, @"[\p{P}\p{S}\p{C}\p{N}]+", "");
            sigla = Regex.Replace(sigla, @"\p{Z}+", " ");
            sigla = Regex.Replace(sigla.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);
            sigla = Regex.Replace(sigla, @"^(\p{L})[^\s]*(?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L}*)?)?$", "$1$2").Trim();


            if (sigla.Length > 2)
            {
                sigla = sigla.Substring(0, 2);
            }

            sigla = sigla.ToUpperInvariant();


            actualiza.Siglas = sigla;

            db.SaveChanges();

        }
        public void Borrardepartamento(DEPARTAMENTO depa)
        {
            var borrar = db.DEPARTAMENTOes.FirstOrDefault(z => z.IdDepartamento == depa.IdDepartamento);
            db.DEPARTAMENTOes.Remove(borrar);
            db.SaveChanges();

        }

        public List<DEPARTAMENTO> ListarDepartamento()
        {
            return db.DEPARTAMENTOes.ToList();
        }


    }
}
