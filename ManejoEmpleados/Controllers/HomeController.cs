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

        public IActionResult Index(int id)
        {

            if (id == 0)
            {
                Empleado empleado = _empleadoRepository.GetEmpleado(2);
                var modelo = new IndexViewModel
                {
                    Empleado = empleado,
                    TituloPagina = "Detalle Empleado"
                };

                return View(modelo);
            }

            Empleado empleadoGen = _empleadoRepository.GetEmpleado(id);
            var modelo2 = new IndexViewModel
            {
                Empleado = empleadoGen,
                TituloPagina = "Detalle Empleado"
            };

            return View(modelo2);
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
