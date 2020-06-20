﻿// <auto-generated />
using ManejoEmpleados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManejoEmpleados.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200620180423_AddMAny2Many")]
    partial class AddMAny2Many
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManejoEmpleados.Models.Direccion", b =>
                {
                    b.Property<int>("DireccionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionCompleta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.HasKey("DireccionId");

                    b.HasIndex("EmpleadoId")
                        .IsUnique();

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("ManejoEmpleados.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SedeUsadaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SedeUsadaId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("ManejoEmpleados.Models.EmpleadoTarea", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("TareaId")
                        .HasColumnType("int");

                    b.HasKey("EmpleadoId", "TareaId");

                    b.HasIndex("TareaId");

                    b.ToTable("EmpleadoTareas");
                });

            modelBuilder.Entity("ManejoEmpleados.Models.Sede", b =>
                {
                    b.Property<int>("SedeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SedeId");

                    b.ToTable("Sedes");
                });

            modelBuilder.Entity("ManejoEmpleados.Models.Tarea", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TareaId");

                    b.ToTable("Tarea");
                });

            modelBuilder.Entity("ManejoEmpleados.Models.Direccion", b =>
                {
                    b.HasOne("ManejoEmpleados.Models.Empleado", "Empleado")
                        .WithOne("Direccion")
                        .HasForeignKey("ManejoEmpleados.Models.Direccion", "EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ManejoEmpleados.Models.Empleado", b =>
                {
                    b.HasOne("ManejoEmpleados.Models.Sede", "Sede")
                        .WithMany("Empleados")
                        .HasForeignKey("SedeUsadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ManejoEmpleados.Models.EmpleadoTarea", b =>
                {
                    b.HasOne("ManejoEmpleados.Models.Empleado", "Empleado")
                        .WithMany("EmpleadoTareas")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManejoEmpleados.Models.Tarea", "Tarea")
                        .WithMany("EmpleadoTareas")
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
