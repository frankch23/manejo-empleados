using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoEmpleados.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sede> Sedes { get; set; }

        public DbSet<EmpleadoTarea> EmpleadoTareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
            modelBuilder.Entity<Empleado>()
                .HasOne<Sede>(s => s.Sede)
                .WithMany(e => e.Empleados)
                .HasForeignKey(e => e.SedeUsadaId);
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmpleadoTarea>().HasKey(et => new { et.EmpleadoId, et.TareaId });
        }

    }
}
