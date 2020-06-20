using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.Models
{
    public class Direccion
    {
        public int DireccionId { get; set; }
        public string DireccionCompleta { get; set; }
        public string Ciudad { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}
