using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.Models
{
    public class MockEmpleadoRepository : IEmpleadoRepository
    {
        private List<Empleado> _empleadoLista;
        public MockEmpleadoRepository()
        {
            _empleadoLista = new List<Empleado>
            {
                new Empleado(){Id = 1, Nombre = "Juan", Area=Area.IT, Email="juan@miempresa.com"},
                new Empleado(){Id = 2, Nombre = "Maria", Area=Area.HR, Email="maria@miempresa.com"},
                new Empleado(){Id = 3, Nombre = "Pedro", Area=Area.Ventas, Email="pedro@miempresa.com"},
                new Empleado(){Id = 4, Nombre = "Luis", Area=Area.IT, Email="luis@miempresa.com"}
            };
        }

        public Empleado Add(Empleado empleado)
        {
            empleado.Id = _empleadoLista.Max(e => e.Id) + 1;
            _empleadoLista.Add(empleado);
            return empleado;
        }

        /// <summary>
        /// Obtiene todos los empleados.
        /// </summary>
        /// <returns>Lista de empleados.</returns>
        public IEnumerable<Empleado> GetAll()
        {
            return _empleadoLista;
        }

        /// <summary>
        /// Obtiene un empleado.
        /// </summary>
        /// <param name="id">Id del empleado.</param>
        /// <returns>Empleado filtrado.</returns>
        public Empleado GetEmpleado(int id)
        {
            return _empleadoLista.FirstOrDefault(e => e.Id == id);
        }
    }
}
