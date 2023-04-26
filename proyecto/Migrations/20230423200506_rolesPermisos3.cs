using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class rolesPermisos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolPermiso_Permiso_PermisoIdPermiso",
                table: "RolPermiso");

            migrationBuilder.DropForeignKey(
                name: "FK_RolPermiso_Rol_RolIdRol",
                table: "RolPermiso");

            migrationBuilder.DropIndex(
                name: "IX_RolPermiso_PermisoIdPermiso",
                table: "RolPermiso");

            migrationBuilder.DropIndex(
                name: "IX_RolPermiso_RolIdRol",
                table: "RolPermiso");

            migrationBuilder.DropColumn(
                name: "PermisoIdPermiso",
                table: "RolPermiso");

            migrationBuilder.DropColumn(
                name: "RolIdRol",
                table: "RolPermiso");

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "RolPermiso",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PermisoId",
                table: "RolPermiso",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "RolId",
                table: "RolPermiso",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PermisoId",
                table: "RolPermiso",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PermisoIdPermiso",
                table: "RolPermiso",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolIdRol",
                table: "RolPermiso",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_PermisoIdPermiso",
                table: "RolPermiso",
                column: "PermisoIdPermiso");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_RolIdRol",
                table: "RolPermiso",
                column: "RolIdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_RolPermiso_Permiso_PermisoIdPermiso",
                table: "RolPermiso",
                column: "PermisoIdPermiso",
                principalTable: "Permiso",
                principalColumn: "IdPermiso");

            migrationBuilder.AddForeignKey(
                name: "FK_RolPermiso_Rol_RolIdRol",
                table: "RolPermiso",
                column: "RolIdRol",
                principalTable: "Rol",
                principalColumn: "idRol");
        }
    }
}
