using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.Migrations
{
    public partial class initialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Usuario = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Autoridad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreYApellido = table.Column<string>(nullable: false),
                    RolAutoridad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autoridad", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreYApellido = table.Column<string>(nullable: false),
                    Especialidad = table.Column<string>(nullable: false),
                    RolEnEspecialidad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(nullable: false),
                    Cuerpo = table.Column<string>(nullable: false),
                    Fecha = table.Column<string>(nullable: false),
                    URLImagen = table.Column<string>(nullable: false),
                    URLNotaCompleta = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ObraSocial",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    PaginaWeb = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraSocial", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Mail = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false),
                    ObraSocial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Mail);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    ObraSocialID = table.Column<int>(nullable: true),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Plan_ObraSocial_ObraSocialID",
                        column: x => x.ObraSocialID,
                        principalTable: "ObraSocial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Paciente = table.Column<string>(nullable: false),
                    Medico = table.Column<string>(nullable: false),
                    FechaYHora = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    UsuarioMail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Turno_Usuario_UsuarioMail",
                        column: x => x.UsuarioMail,
                        principalTable: "Usuario",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plan_ObraSocialID",
                table: "Plan",
                column: "ObraSocialID");

            migrationBuilder.CreateIndex(
                name: "IX_Turno_UsuarioMail",
                table: "Turno",
                column: "UsuarioMail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Autoridad");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "ObraSocial");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
