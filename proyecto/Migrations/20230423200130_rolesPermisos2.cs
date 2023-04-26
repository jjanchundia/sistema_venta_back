using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class rolesPermisos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePermiso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.IdPermiso);
                });

            migrationBuilder.CreateTable(
                name: "RolPermiso",
                columns: table => new
                {
                    IdRolPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermisoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermisoIdPermiso = table.Column<int>(type: "int", nullable: true),
                    RolIdRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermiso", x => x.IdRolPermiso);
                    table.ForeignKey(
                        name: "FK_RolPermiso_Permiso_PermisoIdPermiso",
                        column: x => x.PermisoIdPermiso,
                        principalTable: "Permiso",
                        principalColumn: "IdPermiso");
                    table.ForeignKey(
                        name: "FK_RolPermiso_Rol_RolIdRol",
                        column: x => x.RolIdRol,
                        principalTable: "Rol",
                        principalColumn: "idRol");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_PermisoIdPermiso",
                table: "RolPermiso",
                column: "PermisoIdPermiso");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_RolIdRol",
                table: "RolPermiso",
                column: "RolIdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolPermiso");

            migrationBuilder.DropTable(
                name: "Permiso");
        }
    }
}
