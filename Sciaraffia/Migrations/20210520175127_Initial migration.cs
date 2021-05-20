using Microsoft.EntityFrameworkCore.Migrations;

namespace Sciaraffia.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorarioC",
                columns: table => new
                {
                    serial = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    usuario = table.Column<string>(nullable: true),
                    fecha = table.Column<string>(nullable: true),
                    hora = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioC", x => x.serial);
                });

            migrationBuilder.CreateTable(
                name: "usuarioC",
                columns: table => new
                {
                    correo = table.Column<string>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    clave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioC", x => x.correo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioC");

            migrationBuilder.DropTable(
                name: "usuarioC");
        }
    }
}
