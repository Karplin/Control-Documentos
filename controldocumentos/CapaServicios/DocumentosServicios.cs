using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaServicios
{
   public class DocumentosServicios
    {
        documentobdEntities1 db = new documentobdEntities1();
        public List<docu_empleado_Result> BuscaDcumento(string Cedula)
        {
            return db.docu_empleado(Cedula).ToList();
        }

        public List<docu_origen_Result> Buscardepaori(string departa)
        {
            return db.docu_origen(departa).ToList();
        }

        public List<docu_destino_Result> Buscardepadesti(string departadesti)
        {
            return db.docu_destino(departadesti).ToList();
        }

        public List<docu_fecha_Result> Buscarfecha(string fechainici, string fechafini)
        {
            return db.docu_fecha(fechainici, fechafini).ToList();
        }
    }
}
