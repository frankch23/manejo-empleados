using Microsoft.EntityFrameworkCore.Migrations;

namespace ManejoEmpleados.Migrations
{
    public partial class Add1to1ByConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    DireccionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DireccionCompleta = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    EmpleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.DireccionId);
                    table.ForeignKey(
                        name: "FK_Direccion_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_EmpleadoId",
                table: "Direccion",
                column: "EmpleadoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direccion");
        }
    }
}
