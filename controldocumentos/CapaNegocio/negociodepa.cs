using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class negociodepa
    {
        datosdepartamento ejecutar = new datosdepartamento();

        public void GuardarDepartamento(DEPARTAMENTO depa)
        {
            ejecutar.Insertardepartamento(depa);
        }

        public void ActualizarDepartamento(DEPARTAMENTO depa)
        {
            ejecutar.Actualizardepartamento(depa);
        }
        public void EliminarDepartamento(DEPARTAMENTO depa)
        {
            ejecutar.Borrardepartamento(depa);
        }

        public List<DEPARTAMENTO> MostrarDatos()
        {
            return ejecutar.ListarDepartamento().ToList();
        }

    }
}
