using Microsoft.EntityFrameworkCore.Migrations;

namespace ManejoEmpleados.Migrations
{
    public partial class AddMAny2Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareaId);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoTareas",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(nullable: false),
                    TareaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoTareas", x => new { x.EmpleadoId, x.TareaId });
                    table.ForeignKey(
                        name: "FK_EmpleadoTareas_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadoTareas_Tarea_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tarea",
                        principalColumn: "TareaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoTareas_TareaId",
                table: "EmpleadoTareas",
                column: "TareaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadoTareas");

            migrationBuilder.DropTable(
                name: "Tarea");
        }
    }
}
