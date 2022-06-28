using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageRev.Data.Migrations
{
    public partial class updatenonomeatrib : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fotografia",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Versão",
                table: "Carros");

            migrationBuilder.RenameColumn(
                name: "Cilindrada",
                table: "Carros",
                newName: "CilindradaouCapacidadeBateria");

            migrationBuilder.AlterColumn<string>(
                name: "TipoCaixa",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nportas",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Combustivel",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Versao",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a", "d8f27e0a-2d12-4e58-aa9a-029925a6b601", "Admin", "ADMIN" },
                    { "c", "d3c7af11-4598-4af5-aa3e-d99e65545d0e", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Carros",
                columns: new[] { "Id", "Ano", "CilindradaouCapacidadeBateria", "Combustivel", "Marca", "Modelo", "Nportas", "Potencia", "TipoCaixa", "Versao" },
                values: new object[,]
                {
                    { 1, 2017, 42, "Electric", "BMW", "i3", "5", 170, "1 speed Auto CVT", "120Ah" },
                    { 2, 2018, 42, "Electric", "BMW", "i3", "5", 184, "1 speed Auto CVT", "s 120Ah" },
                    { 3, 2021, 84, "Electric", "BMW", "i4", "5", 544, "1 speed Auto CVT", "M50" },
                    { 4, 2021, 84, "Electric", "BMW", "i4", "5", 340, "1 speed Auto CVT", "edrive40" },
                    { 5, 2020, 1499, "Petrol", "BMW", "F40 serie 1", "5", 109, "6 speed Manual", "116i" },
                    { 6, 2021, 1499, "Petrol", "BMW", "F40 serie 1", "5", 136, "7 speed DualClutch Automatic", "118i Auto" },
                    { 7, 2020, 1998, "Petrol", "BMW", "F40 serie 1", "5", 265, "7 speed DualClutch Automatic", "128ti" },
                    { 8, 2019, 1998, "Petrol", "BMW", "F40 serie 1", "5", 306, "8 speed Automatic", "M135i xDrive" },
                    { 9, 2021, 1998, "Petrol", "BMW", "G02 X4 LCI", "5", 245, "8 speed Automatic", "xDrive30i" },
                    { 10, 2021, 1499, "Petrol", "BMW", "F44 serie 2 Gran Coupe", "4", 136, "6 speed Manual", "218i" },
                    { 11, 2020, 1998, "Petrol", "BMW", "G21 serie 3 Touring", "5", 156, "8 speed Automatic", "318i Auto" },
                    { 12, 2021, 1998, "Petrol", "BMW", "G23 serie 4 Cabrio", "2", 258, "8 speed Automatic", "430i" },
                    { 13, 2022, 999, "Petrol", "Ford", "Fiesta", "5", 100, "6 speed Manual", "1.0 Ecoboost" },
                    { 14, 2017, 988, "Petrol", "Honda", "Civic 10", "5", 129, "1 speed auto CVT", "1.0 Turbo VTEC" },
                    { 15, 2020, 2268, "Diesel", "Mitsubishi", "L200 Club Cab ", "2", 150, "6 speed Manual", "2.2 DI-D ClearTec" },
                    { 16, 2020, 1193, "Petrol", "Mitsubishi", "Space Star ", "5", 80, "5 speed Manul", "1.2" },
                    { 17, 2019, 999, "Petrol", "Nissan", "Micra K14  ", "5", 100, "1 speed auto CVT", "I-GT 100" },
                    { 18, 2017, 40, "Electric", "Nissan", "Leaf 2", "5", 150, "1 speed Auto CVT", "40kWh" },
                    { 19, 2021, 1332, "Petrol", "Nissan", "Qashqai J12", "5", 158, "6 speed Manual", "DIG-T 158" },
                    { 20, 2018, 3799, "Petrol", "Nissan", "GT R", "3", 600, "6 speed DualClutch Automatic", "Nismo" },
                    { 21, 1998, 2568, "Petrol", "Nissan", "R33 Skyline ", "4", 280, "5 speed Manual", "GT-R 40th Anniversary Autech" },
                    { 22, 2019, 1499, "Diesel", "Opel", "Corsa F", "5", 102, "6 speed Manual", "1.5 Diesel" },
                    { 23, 2018, 998, "Petrol", "Peugeot", "108", "3", 72, "5 speed Manual", "3-door 1.0 e-VTi 72" },
                    { 24, 2021, 1499, "Diesel", "Peugeot", "508 II SW", "5", 130, "8 speed Automatic", "BlueHDi 130 Auto" },
                    { 25, 2015, 999, "Petrol", "Peugeot", "208 Facelift", "5", 68, "5 speed Manual", "1.0 PureTech 68 " },
                    { 26, 2019, 1461, "Diesel", "Renault", "Clio 5", "5", 85, "6 speed Manual", "Blue DCi 85" },
                    { 27, 2013, 6262, "Hybrid/Petrol", "Ferrari", "La Ferrari", "2", 800, "7 speed Sequential", "F70 F150 HY-KERS System 963HP" }
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
                table: "Carros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 27);

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
                name: "Versao",
                table: "Carros");

            migrationBuilder.RenameColumn(
                name: "CilindradaouCapacidadeBateria",
                table: "Carros",
                newName: "Cilindrada");

            migrationBuilder.AlterColumn<string>(
                name: "TipoCaixa",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nportas",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Combustivel",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Fotografia",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Versão",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
