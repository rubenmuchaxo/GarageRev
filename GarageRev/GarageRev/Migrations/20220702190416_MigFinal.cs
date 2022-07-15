using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace GarageRev.Migrations {
    public partial class MigFinal : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new {
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
                constraints: table => {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUtilizador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarrosCategorias",
                columns: table => new {
                    CarrosId = table.Column<int>(type: "int", nullable: false),
                    CategoriasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
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
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtilizadorFK = table.Column<int>(type: "int", nullable: false),
                    CarroFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
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
                    { "a", "e829b3a3-1937-473d-9f31-a8df6d1ced97", "Admin", "ADMIN" },
                    { "c", "400c6c8b-170b-452e-84ab-be9418092b57", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Carros",
                columns: new[] { "Id", "Ano", "CilindradaouCapacidadeBateria", "Combustivel", "Foto", "Marca", "Modelo", "Nportas", "Potencia", "TipoCaixa", "Versao" },
                values: new object[,]
                {
                    { 1, 2017, 42, "Electric", "bmw_i3_120ah.jpg", "BMW", "i3", "5", 170, "1 speed Auto CVT", "120Ah" },
                    { 2, 2018, 42, "Electric", "bmw_i3_s120ah.jpg", "BMW", "i3", "5", 184, "1 speed Auto CVT", "s 120Ah" },
                    { 3, 2021, 84, "Electric", "bmw_i4_M50.jpg", "BMW", "i4", "5", 544, "1 speed Auto CVT", "M50" },
                    { 4, 2021, 84, "Electric", "BMW_i4_eDrive40.jpg", "BMW", "i4", "5", 340, "1 speed Auto CVT", "edrive40" },
                    { 5, 2020, 1499, "Petrol", "bmw_F40 Serie 1_116i.jpg", "BMW", "F40 serie 1", "5", 109, "6 speed Manual", "116i" },
                    { 6, 2021, 1499, "Petrol", "bmw_F40 Serie 1_118i.jpg", "BMW", "F40 serie 1", "5", 136, "7 speed DualClutch Automatic", "118i Auto" },
                    { 7, 2020, 1998, "Petrol", "bmw_F40 Serie 1_128i.jpg", "BMW", "F40 serie 1", "5", 265, "7 speed DualClutch Automatic", "128ti" },
                    { 8, 2019, 1998, "Petrol", "bmw_F40 Serie 1_m135i.jpg", "BMW", "F40 serie 1", "5", 306, "8 speed Automatic", "M135i xDrive" },
                    { 9, 2021, 1998, "Petrol", "bmw_G02_X4 LCI.jpg", "BMW", "G02 X4 LCI", "5", 245, "8 speed Automatic", "xDrive30i" },
                    { 10, 2021, 1499, "Petrol", "bmw_f44 Serie2 gran Coupe_218i.jpg", "BMW", "F44 serie 2 Gran Coupe", "4", 136, "6 speed Manual", "218i" },
                    { 11, 2020, 1998, "Petrol", "bmw_g21 serie3 touring_318i auto.jpg", "BMW", "G21 serie 3 Touring", "5", 156, "8 speed Automatic", "318i Auto" },
                    { 12, 2021, 1998, "Petrol", "bmw g23 serie 4 cabrio.jpg", "BMW", "G23 serie 4 Cabrio", "2", 258, "8 speed Automatic", "430i" },
                    { 13, 2022, 999, "Petrol", "ford_fiesta.jpg", "Ford", "Fiesta", "5", 100, "6 speed Manual", "1.0 Ecoboost" },
                    { 14, 2017, 988, "Petrol", "honda_civic.jpg", "Honda", "Civic 10", "5", 129, "1 speed auto CVT", "1.0 Turbo VTEC" },
                    { 15, 2020, 2268, "Diesel", "mitsubishi_l200.jpg", "Mitsubishi", "L200 Club Cab ", "2", 150, "6 speed Manual", "2.2 DI-D ClearTec" },
                    { 16, 2020, 1193, "Petrol", "Mitsubishi-Space-Star.jpeg", "Mitsubishi", "Space Star ", "5", 80, "5 speed Manul", "1.2" },
                    { 17, 2019, 999, "Petrol", "nissan_micra k14.jpg", "Nissan", "Micra K14  ", "5", 100, "1 speed auto CVT", "I-GT 100" },
                    { 18, 2017, 40, "Electric", "nissan-leaf.jpg", "Nissan", "Leaf 2", "5", 150, "1 speed Auto CVT", "40kWh" },
                    { 19, 2021, 1332, "Petrol", "nissan_qashqai_J12.jpg", "Nissan", "Qashqai J12", "5", 158, "6 speed Manual", "DIG-T 158" },
                    { 20, 2018, 3799, "Petrol", "nissan_GTR_Nismo.jpg", "Nissan", "GT R", "3", 600, "6 speed DualClutch Automatic", "Nismo" },
                    { 21, 1998, 2568, "Petrol", "nissan_r33_Skyline.jpg", "Nissan", "R33 Skyline ", "4", 280, "5 speed Manual", "GT-R 40th Anniversary Autech" },
                    { 22, 2019, 1499, "Diesel", "opel_corsa_f.jpg", "Opel", "Corsa F", "5", 102, "6 speed Manual", "1.5 Diesel" },
                    { 23, 2018, 998, "Petrol", "peugeot_108.jpg", "Peugeot", "108", "3", 72, "5 speed Manual", "3-door 1.0 e-VTi 72" },
                    { 24, 2021, 1499, "Diesel", "peugeot_508 II sw.jpg", "Peugeot", "508 II SW", "5", 130, "8 speed Automatic", "BlueHDi 130 Auto" },
                    { 25, 2015, 999, "Petrol", "peugeot_208_facelift.jpg", "Peugeot", "208 Facelift", "5", 68, "5 speed Manual", "1.0 PureTech 68 " },
                    { 26, 2019, 1461, "Diesel", "renault_clio 5.jpg", "Renault", "Clio 5", "5", 85, "6 speed Manual", "Blue DCi 85" },
                    { 27, 2013, 6262, "Hybrid/Petrol", "ferrari_Laferrari_f70.jpg", "Ferrari", "La Ferrari", "2", 800, "7 speed Sequential", "F70 F150 HY-KERS System 963HP" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "NomeCat" },
                values: new object[,]
                {
                    { 1, "Elétrico" },
                    { 2, "Desportivo" },
                    { 3, "Citadino" },
                    { 4, "SUV" },
                    { 5, "Mota" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarrosCategorias");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
