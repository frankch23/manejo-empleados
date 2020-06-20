using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.Models
{
    public class Tarea
    {
        public int TareaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public IList<EmpleadoTarea> EmpleadoTareas { get; set; }
    }
}
