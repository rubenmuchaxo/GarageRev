using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageRev.Migrations {
    public partial class altCarros : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrosCategorias_Categorias_CategoriasId",
                table: "CarrosCategorias");

            migrationBuilder.RenameColumn(
                name: "CategoriasId",
                table: "CarrosCategorias",
                newName: "ListaCategoriasId");

            migrationBuilder.RenameIndex(
                name: "IX_CarrosCategorias_CategoriasId",
                table: "CarrosCategorias",
                newName: "IX_CarrosCategorias_ListaCategoriasId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "2552283f-9dba-430f-a795-98ea5946820f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "a2d23442-8213-4608-b0df-9c2ddaab69e6");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrosCategorias_Categorias_ListaCategoriasId",
                table: "CarrosCategorias",
                column: "ListaCategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrosCategorias_Categorias_ListaCategoriasId",
                table: "CarrosCategorias");

            migrationBuilder.RenameColumn(
                name: "ListaCategoriasId",
                table: "CarrosCategorias",
                newName: "CategoriasId");

            migrationBuilder.RenameIndex(
                name: "IX_CarrosCategorias_ListaCategoriasId",
                table: "CarrosCategorias",
                newName: "IX_CarrosCategorias_CategoriasId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "e829b3a3-1937-473d-9f31-a8df6d1ced97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "400c6c8b-170b-452e-84ab-be9418092b57");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrosCategorias_Categorias_CategoriasId",
                table: "CarrosCategorias",
                column: "CategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
