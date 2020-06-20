using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.Models
{
    public class SqlEmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext context;

        public SqlEmpleadoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Empleado Add(Empleado empleado)
        {
            context.Empleados.Add(empleado);
            context.SaveChanges();
            return empleado;
        }

        public Empleado Delete(int id)
        {
            Empleado empleado = context.Empleados.Find(id);
            if(empleado != null)
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
            }

            return empleado;
        }

        public IEnumerable<Empleado> GetAll()
        {
            return context.Empleados;
        }

        public Empleado GetEmpleado(int id)
        {
            return context.Empleados.Find(id);
        }

        public Empleado Update(Empleado empleadoCambios)
        {
            var empleado = context.Empleados.Attach(empleadoCambios);
            empleado.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return empleadoCambios;
        }
    }
}
