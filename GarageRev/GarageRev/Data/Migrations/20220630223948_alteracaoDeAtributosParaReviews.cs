using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageRev.Data.Migrations
{
    public partial class alteracaoDeAtributosParaReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUtilizador",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a", "96ef91f7-67cb-47ac-b1c8-af64228c70e0", "Admin", "ADMIN" },
                    { "c", "1ba9f7ab-a0ae-4189-9f0b-9e5851fe59ea", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "NomeCat" },
                values: new object[,]
                {
                    { 1, "Elétrico" },
                    { 2, "Desportivo" },
                    { 3, "Citadino" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c");

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Reviews");
        }
    }
}
