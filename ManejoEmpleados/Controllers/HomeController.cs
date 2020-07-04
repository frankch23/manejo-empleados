using Microsoft.AspNetCore.Mvc;
using ManejoEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManejoEmpleados.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ManejoEmpleados.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private IEmpleadoRepository _empleadoRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(IEmpleadoRepository empleadoRepository, 
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _empleadoRepository = empleadoRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //[AllowAnonymous]
        public IActionResult Index()
        {
            var user = new IdentityUser
            {
                UserName = "Usuario",
                Email = "Email"
            };
            userManager.CreateAsync(user, "pass");

            signInManager.SignInAsync(user, false);
            signInManager.SignOutAsync();
            /*if (id == 0)
            {
               Empleado empleado = _empleadoRepository.GetEmpleado(2);
                var modelo = new IndexViewModel
                {
                    Empleado = empleado,
                    TituloPagina = "Detalle Empleado"
                };

                return View(modelo);
                return View();
            }*/

            /*Empleado empleadoGen = _empleadoRepository.GetEmpleado(id);
            var modelo2 = new EmpleadoViewModel
            {
                Empleado = empleadoGen,
                TituloPagina = "Detalle Empleado"
            };

            return View(modelo2);*/
            return View();
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

        public ViewResult CrearEmpleado()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _empleadoRepository.Add(empleado);
                return RedirectToAction(nameof(Empleados), "Home");
            }

            return View(empleado);

        }

        public IActionResult Empleado(int id)
        {
            if (id == 0)
           {
                throw new Exception("Atributo no valido!");
           }

            Empleado empleadoGen = _empleadoRepository.GetEmpleado(id);
            var modelo2 = new EmpleadoViewModel
            {
                Empleado = empleadoGen,
                TituloPagina = "Detalle Empleado"
            };

            return View(modelo2);
        }
    }
}
