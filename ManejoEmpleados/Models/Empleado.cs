using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido.")]
        [MaxLength(50, ErrorMessage = "Nombre muy largo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Area Requerida")]
        public Area? Area { get; set; }


        [Required(ErrorMessage = "Email Requerido")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Formato correo no valido")]
        [Display(Name = "Correo Corporativo")]
        public string Email { get; set; }

        public int SedeUsadaId { get; set; }
        public Sede Sede { get; set; }

        public Direccion Direccion { get; set; }

        public IList<EmpleadoTarea> EmpleadoTareas { get; set; }
    }
}
