using Microsoft.EntityFrameworkCore.Migrations;

namespace ManejoEmpleados.Migrations
{
    public partial class AddForeignKeyEmpleadoSede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SedeUsadaId",
                table: "Empleados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    SedeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.SedeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_SedeUsadaId",
                table: "Empleados",
                column: "SedeUsadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Sedes_SedeUsadaId",
                table: "Empleados",
                column: "SedeUsadaId",
                principalTable: "Sedes",
                principalColumn: "SedeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Sedes_SedeUsadaId",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_SedeUsadaId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "SedeUsadaId",
                table: "Empleados");
        }
    }
}
