using ManejoEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.ViewModels.Home
{
    public class EmpleadoViewModel
    {
        public Empleado Empleado { get; set; }
        public string TituloPagina { get; set; }
    }
}
