using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.Models
{
    public class EmpleadoTarea
    {
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }
    }
}
