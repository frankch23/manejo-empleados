using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.Models
{
    public class Sede
    {
        public int SedeId { get; set; }
        public string Nombre { get; set; }

        public string Ciudad { get; set; }

        public IList<Empleado> Empleados { get; set; }

    }
}
