using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageRev.Data.Migrations
{
    public partial class dbUpdateTesteFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Utilizadores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Versao",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.InsertData(
                table: "Carros",
                columns: new[] { "Id", "Ano", "CilindradaouCapacidadeBateria", "Combustivel", "Fotografia", "Marca", "Modelo", "Nportas", "Potencia", "TipoCaixa", "Versao" },
                values: new object[,]
                {
                    { 1, 2017, 42, "Electric", "123", "BMW", "i3", "5", 170, "1 speed Auto CVT", "120Ah" },
                    { 2, 2018, 42, "Electric", "123", "BMW", "i3", "5", 184, "1 speed Auto CVT", "s 120Ah" },
                    { 3, 2021, 84, "Electric", "123", "BMW", "i4", "5", 544, "1 speed Auto CVT", "M50" },
                    { 4, 2021, 84, "Electric", "123", "BMW", "i4", "5", 340, "1 speed Auto CVT", "edrive40" },
                    { 5, 2020, 1499, "Petrol", "123", "BMW", "F40 serie 1", "5", 109, "6 speed Manual", "116i" },
                    { 6, 2021, 1499, "Petrol", "123", "BMW", "F40 serie 1", "5", 136, "7 speed DualClutch Automatic", "118i Auto" },
                    { 7, 2020, 1998, "Petrol", "123", "BMW", "F40 serie 1", "5", 265, "7 speed DualClutch Automatic", "128ti" },
                    { 8, 2019, 1998, "Petrol", "123", "BMW", "F40 serie 1", "5", 306, "8 speed Automatic", "M135i xDrive" },
                    { 9, 2021, 1998, "Petrol", "123", "BMW", "G02 X4 LCI", "5", 245, "8 speed Automatic", "xDrive30i" },
                    { 10, 2021, 1499, "Petrol", "123", "BMW", "F44 serie 2 Gran Coupe", "4", 136, "6 speed Manual", "218i" },
                    { 11, 2020, 1998, "Petrol", "123", "BMW", "G21 serie 3 Touring", "5", 156, "8 speed Automatic", "318i Auto" },
                    { 12, 2021, 1998, "Petrol", "123", "BMW", "G23 serie 4 Cabrio", "2", 258, "8 speed Automatic", "430i" },
                    { 13, 2022, 999, "Petrol", "123", "Ford", "Fiesta", "5", 100, "6 speed Manual", "1.0 Ecoboost" },
                    { 14, 2017, 988, "Petrol", "123", "Honda", "Civic 10", "5", 129, "1 speed auto CVT", "1.0 Turbo VTEC" },
                    { 15, 2020, 2268, "Diesel", "123", "Mitsubishi", "L200 Club Cab ", "2", 150, "6 speed Manual", "2.2 DI-D ClearTec" },
                    { 16, 2020, 1193, "Petrol", "123", "Mitsubishi", "Space Star ", "5", 80, "5 speed Manul", "1.2" },
                    { 17, 2019, 999, "Petrol", "123", "Nissan", "Micra K14  ", "5", 100, "1 speed auto CVT", "I-GT 100" },
                    { 18, 2017, 40, "Electric", "123", "Nissan", "Leaf 2", "5", 150, "1 speed Auto CVT", "40kWh" },
                    { 19, 2021, 1332, "Petrol", "123", "Nissan", "Qashqai J12", "5", 158, "6 speed Manual", "DIG-T 158" },
                    { 20, 2018, 3799, "Petrol", "123", "Nissan", "GT R", "3", 600, "6 speed DualClutch Automatic", "Nismo" },
                    { 21, 1998, 2568, "Petrol", "123", "Nissan", "R33 Skyline ", "4", 280, "5 speed Manual", "GT-R 40th Anniversary Autech" },
                    { 22, 2019, 1499, "Diesel", "123", "Opel", "Corsa F", "5", 102, "6 speed Manual", "1.5 Diesel" },
                    { 23, 2018, 998, "Petrol", "123", "Peugeot", "108", "3", 72, "5 speed Manual", "3-door 1.0 e-VTi 72" },
                    { 24, 2021, 1499, "Diesel", "123", "Peugeot", "508 II SW", "5", 130, "8 speed Automatic", "BlueHDi 130 Auto" },
                    { 25, 2015, 999, "Petrol", "123", "Peugeot", "208 Facelift", "5", 68, "5 speed Manual", "1.0 PureTech 68 " },
                    { 26, 2019, 1461, "Diesel", "123", "Renault", "Clio 5", "5", 85, "6 speed Manual", "Blue DCi 85" },
                    { 27, 2013, 6262, "Hybrid/Petrol", "123", "Ferrari", "La Ferrari", "2", 800, "7 speed Sequential", "F70 F150 HY-KERS System 963HP" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Versao",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
