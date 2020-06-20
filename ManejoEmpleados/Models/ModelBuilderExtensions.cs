using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    Id = 1,
                    Nombre = "Juan",
                    Area = Area.IT,
                    Email = "juan@miempresa.com"
                },
                new Empleado() { Id = 2, Nombre = "Maria", Area = Area.HR, Email = "maria@miempresa.com" },
                new Empleado() { Id = 3, Nombre = "Pedro", Area = Area.Ventas, Email = "pedro@miempresa.com" }
                );
        }
    }
}
