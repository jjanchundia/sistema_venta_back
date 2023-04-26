using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class rolesPermisosEditar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolPermiso_Permiso_PermisoId",
                table: "RolPermiso");

            migrationBuilder.DropForeignKey(
                name: "FK_RolPermiso_Rol_RolId",
                table: "RolPermiso");

            migrationBuilder.DropIndex(
                name: "IX_RolPermiso_PermisoId",
                table: "RolPermiso");

            migrationBuilder.DropIndex(
                name: "IX_RolPermiso_RolId",
                table: "RolPermiso");

            migrationBuilder.DropColumn(
                name: "PermisoId",
                table: "RolPermiso");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "RolPermiso");

            migrationBuilder.AddColumn<int>(
                name: "IdPermiso",
                table: "RolPermiso",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "RolPermiso",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_IdPermiso",
                table: "RolPermiso",
                column: "IdPermiso");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_IdRol",
                table: "RolPermiso",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_RolPermiso_Permiso_IdPermiso",
                table: "RolPermiso",
                column: "IdPermiso",
                principalTable: "Permiso",
                principalColumn: "IdPermiso");

            migrationBuilder.AddForeignKey(
                name: "FK_RolPermiso_Rol_IdRol",
                table: "RolPermiso",
                column: "IdRol",
                principalTable: "Rol",
                principalColumn: "idRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolPermiso_Permiso_IdPermiso",
                table: "RolPermiso");

            migrationBuilder.DropForeignKey(
                name: "FK_RolPermiso_Rol_IdRol",
                table: "RolPermiso");

            migrationBuilder.DropIndex(
                name: "IX_RolPermiso_IdPermiso",
                table: "RolPermiso");

            migrationBuilder.DropIndex(
                name: "IX_RolPermiso_IdRol",
                table: "RolPermiso");

            migrationBuilder.DropColumn(
                name: "IdPermiso",
                table: "RolPermiso");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "RolPermiso");

            migrationBuilder.AddColumn<int>(
                name: "PermisoId",
                table: "RolPermiso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "RolPermiso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_PermisoId",
                table: "RolPermiso",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_RolId",
                table: "RolPermiso",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolPermiso_Permiso_PermisoId",
                table: "RolPermiso",
                column: "PermisoId",
                principalTable: "Permiso",
                principalColumn: "IdPermiso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolPermiso_Rol_RolId",
                table: "RolPermiso",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "idRol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
