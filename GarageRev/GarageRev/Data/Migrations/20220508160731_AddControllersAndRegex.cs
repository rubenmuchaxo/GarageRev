using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageRev.Data.Migrations
{
    public partial class AddControllersAndRegex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Versão = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Combustivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Cilindrada = table.Column<int>(type: "int", nullable: false),
                    Potencia = table.Column<int>(type: "int", nullable: false),
                    TipoCaixa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nportas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarroFav = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fotografias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarroFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotografias_Carros_CarroFK",
                        column: x => x.CarroFK,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrosCategorias_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrosCategorias_CategoriasId",
                table: "CarrosCategorias",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografias_CarroFK",
                table: "Fotografias",
                column: "CarroFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CarroFK",
                table: "Reviews",
                column: "CarroFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UtilizadorFK",
                table: "Reviews",
                column: "UtilizadorFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrosCategorias");

            migrationBuilder.DropTable(
                name: "Fotografias");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
