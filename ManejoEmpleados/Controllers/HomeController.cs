using Microsoft.AspNetCore.Mvc;
using ManejoEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManejoEmpleados.ViewModels.Home;

namespace ManejoEmpleados.Controllers
{
    public class HomeController : Controller
    {
        private IEmpleadoRepository _empleadoRepository;

        public HomeController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public IActionResult Index()
        {
            Empleado empleado = _empleadoRepository.GetEmpleado(2);
            var modelo = new IndexViewModel
            {
                Empleado = empleado,
                TituloPagina = "Detalle Empleado"
            };

            return View(modelo);
        }

        public IActionResult Empleados()
        {

            var modelo = new EmpleadosViewModel
            {
                Empleados = _empleadoRepository.GetAll(),
                TituloPagina = "Empleados",
                Subtitulo = "Tabla Empleados"
            };

            return View(modelo);
        }
    }
}
