using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageRev.Data.Migrations
{
    public partial class UpdatedosModels_AddDeleteRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Versao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Combustivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    CilindradaouCapacidadeBateria = table.Column<int>(type: "int", nullable: false),
                    Potencia = table.Column<int>(type: "int", nullable: false),
                    TipoCaixa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nportas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarroFavorito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilizadores_Carros_CarroFavorito",
                        column: x => x.CarroFavorito,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarrosCategorias",
                columns: table => new
                {
                    CarrosId = table.Column<int>(type: "int", nullable: false),
                    CategoriasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrosCategorias", x => new { x.CarrosId, x.CategoriasId });
                    table.ForeignKey(
                        name: "FK_CarrosCategorias_Carros_CarrosId",
                        column: x => x.CarrosId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarrosCategorias_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilizadorFK = table.Column<int>(type: "int", nullable: false),
                    CarroFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Carros_CarroFK",
                        column: x => x.CarroFK,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a", "ac754f69-cbd0-4dd7-892c-cc28aa0787b2", "Admin", "ADMIN" },
                    { "c", "07720fa9-ea18-4ecb-8ecf-b74fcc0ea521", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Carros",
                columns: new[] { "Id", "Ano", "CilindradaouCapacidadeBateria", "Combustivel", "Foto", "Marca", "Modelo", "Nportas", "Potencia", "TipoCaixa", "Versao" },
                values: new object[,]
                {
                    { 1, 2017, 42, "Electric", null, "BMW", "i3", "5", 170, "1 speed Auto CVT", "120Ah" },
                    { 2, 2018, 42, "Electric", null, "BMW", "i3", "5", 184, "1 speed Auto CVT", "s 120Ah" },
                    { 3, 2021, 84, "Electric", null, "BMW", "i4", "5", 544, "1 speed Auto CVT", "M50" },
                    { 4, 2021, 84, "Electric", null, "BMW", "i4", "5", 340, "1 speed Auto CVT", "edrive40" },
                    { 5, 2020, 1499, "Petrol", null, "BMW", "F40 serie 1", "5", 109, "6 speed Manual", "116i" },
                    { 6, 2021, 1499, "Petrol", null, "BMW", "F40 serie 1", "5", 136, "7 speed DualClutch Automatic", "118i Auto" },
                    { 7, 2020, 1998, "Petrol", null, "BMW", "F40 serie 1", "5", 265, "7 speed DualClutch Automatic", "128ti" },
                    { 8, 2019, 1998, "Petrol", null, "BMW", "F40 serie 1", "5", 306, "8 speed Automatic", "M135i xDrive" },
                    { 9, 2021, 1998, "Petrol", null, "BMW", "G02 X4 LCI", "5", 245, "8 speed Automatic", "xDrive30i" },
                    { 10, 2021, 1499, "Petrol", null, "BMW", "F44 serie 2 Gran Coupe", "4", 136, "6 speed Manual", "218i" },
                    { 11, 2020, 1998, "Petrol", null, "BMW", "G21 serie 3 Touring", "5", 156, "8 speed Automatic", "318i Auto" },
                    { 12, 2021, 1998, "Petrol", null, "BMW", "G23 serie 4 Cabrio", "2", 258, "8 speed Automatic", "430i" },
                    { 13, 2022, 999, "Petrol", null, "Ford", "Fiesta", "5", 100, "6 speed Manual", "1.0 Ecoboost" },
                    { 14, 2017, 988, "Petrol", null, "Honda", "Civic 10", "5", 129, "1 speed auto CVT", "1.0 Turbo VTEC" },
                    { 15, 2020, 2268, "Diesel", null, "Mitsubishi", "L200 Club Cab ", "2", 150, "6 speed Manual", "2.2 DI-D ClearTec" },
                    { 16, 2020, 1193, "Petrol", null, "Mitsubishi", "Space Star ", "5", 80, "5 speed Manul", "1.2" },
                    { 17, 2019, 999, "Petrol", null, "Nissan", "Micra K14  ", "5", 100, "1 speed auto CVT", "I-GT 100" },
                    { 18, 2017, 40, "Electric", null, "Nissan", "Leaf 2", "5", 150, "1 speed Auto CVT", "40kWh" },
                    { 19, 2021, 1332, "Petrol", null, "Nissan", "Qashqai J12", "5", 158, "6 speed Manual", "DIG-T 158" },
                    { 20, 2018, 3799, "Petrol", null, "Nissan", "GT R", "3", 600, "6 speed DualClutch Automatic", "Nismo" },
                    { 21, 1998, 2568, "Petrol", null, "Nissan", "R33 Skyline ", "4", 280, "5 speed Manual", "GT-R 40th Anniversary Autech" },
                    { 22, 2019, 1499, "Diesel", null, "Opel", "Corsa F", "5", 102, "6 speed Manual", "1.5 Diesel" },
                    { 23, 2018, 998, "Petrol", null, "Peugeot", "108", "3", 72, "5 speed Manual", "3-door 1.0 e-VTi 72" },
                    { 24, 2021, 1499, "Diesel", null, "Peugeot", "508 II SW", "5", 130, "8 speed Automatic", "BlueHDi 130 Auto" },
                    { 25, 2015, 999, "Petrol", null, "Peugeot", "208 Facelift", "5", 68, "5 speed Manual", "1.0 PureTech 68 " },
                    { 26, 2019, 1461, "Diesel", null, "Renault", "Clio 5", "5", 85, "6 speed Manual", "Blue DCi 85" },
                    { 27, 2013, 6262, "Hybrid/Petrol", null, "Ferrari", "La Ferrari", "2", 800, "7 speed Sequential", "F70 F150 HY-KERS System 963HP" }
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

            migrationBuilder.CreateIndex(
                name: "IX_CarrosCategorias_CategoriasId",
                table: "CarrosCategorias",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CarroFK",
                table: "Reviews",
                column: "CarroFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UtilizadorFK",
                table: "Reviews",
                column: "UtilizadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_CarroFavorito",
                table: "Utilizadores",
                column: "CarroFavorito");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarrosCategorias");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
